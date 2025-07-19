namespace MajorExpress.Delivery.Application.Commands.UpdateOrder
{
    using System.Threading;
    using System.Threading.Tasks;
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MajorExpress.Delivery.Application.Interfaces;
    using MajorExpress.Delivery.Domain;
    using MajorExpress.Delivery.Domain.Models;
    using MajorExpress.Delivery.Domain.Repositories;
    using MediatR;

    /// <summary>
    ///     Обработчик команды <see cref="UpdateOrderCommand"/>
    /// </summary>
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderDto>
    {
        private readonly IClientRepository _clientRepository;
        private readonly ICargoRepository _cargoRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Order, OrderDto> _mapper;

        public UpdateOrderCommandHandler(
            IClientRepository clientRepository,
            ICargoRepository cargoRepository,
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork,
            IMapper<Order, OrderDto> mapper)
        {
            _clientRepository = clientRepository;
            _cargoRepository = cargoRepository;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.Id, cancellationToken, order => order.Client.User, order => order.Cargo, order => order.Courier.User);
            if (order == null)
            {
                throw new OrderNotFoundException(orderId: request.Id);
            }

            if (order.Status != OrderStatus.New)
            {
                throw new OrderNotInStatusNewException(orderId: request.Id);
            }

            if (order.Client.Id != request.ClientId)
            {
                var client = await _clientRepository.GetAsync(request.ClientId, cancellationToken);
                if (client == null)
                {
                    throw new ClientNotFoundException(request.ClientId);
                }

                order.Client = client;
            }

            if (order.Cargo.Id != request.CargoId)
            {
                var cargo = await _cargoRepository.GetAsync(request.CargoId, cancellationToken);
                if (cargo == null)
                {
                    throw new CargoNotFoundException(request.CargoId);
                }

                order.Cargo = cargo;
            }

            order.PickupTime = DateTime.SpecifyKind(request.PickupTime, DateTimeKind.Utc);
            order.PickupAddress = request.PickupAddress;
            order.DeliveryAddress = request.DeliveryAddress;

            await _orderRepository.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map(order);
        }
    }
}
