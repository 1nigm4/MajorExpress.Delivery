namespace MajorExpress.Delivery.Application.Commands.CreateOrder
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
    ///     Обработчик команды <see cref="CreateOrderCommand"/>
    /// </summary>
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IClientRepository _clientRepository;
        private readonly ICargoRepository _cargoRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Order, OrderDto> _mapper;

        public CreateOrderCommandHandler(
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

        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetAsync(request.ClientId, cancellationToken, client => client.User);
            if (client == null)
            {
                throw new ClientNotFoundException(request.ClientId);
            }

            var cargo = await _cargoRepository.GetAsync(request.CargoId);
            if (cargo == null)
            {
                throw new CargoNotFoundException(request.CargoId);
            }

            var order = new Order
            {
                CreatedAt = DateTime.UtcNow,
                Status = OrderStatus.New,
                Client = client,
                Cargo = cargo,
                PickupTime = request.PickupTime.ToUniversalTime(),
                PickupAddress = request.PickupAddress,
                DeliveryAddress = request.DeliveryAddress,
            };

            await _orderRepository.CreateAsync(order, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map(order);
        }
    }
}
