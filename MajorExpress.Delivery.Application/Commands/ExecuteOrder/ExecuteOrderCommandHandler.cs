namespace MajorExpress.Delivery.Application.Commands.ExecuteOrder
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
    ///     Обработчик команды <see cref="ExecuteOrderCommand"/>
    /// </summary>
    public class ExecuteOrderCommandHandler : IRequestHandler<ExecuteOrderCommand, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICourierRepository _courierRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Order, OrderDto> _mapper;

        public ExecuteOrderCommandHandler(
            IOrderRepository orderRepository,
            ICourierRepository courierRepository,
            IUnitOfWork unitOfWork,
            IMapper<Order, OrderDto> mapper)
        {
            _orderRepository = orderRepository;
            _courierRepository = courierRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(ExecuteOrderCommand request, CancellationToken cancellationToken)
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

            var courier = await _courierRepository.GetAsync(request.CourierId, cancellationToken);
            if (courier == null)
            {
                throw new CourierNotFoundException(request.CourierId);
            }

            order.Status = OrderStatus.SubmittedForExecution;
            order.Courier = courier;

            await _orderRepository.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map(order);
        }
    }
}
