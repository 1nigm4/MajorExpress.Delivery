namespace MajorExpress.Delivery.Application.Commands.CancelOrder
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
    ///     Обработчик команды <see cref="CancelOrderCommand"/>
    /// </summary>
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Order, OrderDto> _mapper;

        public CancelOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IMapper<Order, OrderDto> mapper)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.Id, cancellationToken, order => order.Client.User, order => order.Cargo, order => order.Courier.User);
            if (order == null)
            {
                throw new OrderNotFoundException(orderId: request.Id);
            }

            if (order.Status == OrderStatus.Completed)
            {
                throw new OrderInStatusCompletedException(orderId: request.Id);
            }

            order.Status = OrderStatus.Canceled;
            order.CancelComment = request.CancelComment;
            await _orderRepository.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map(order);
        }
    }
}
