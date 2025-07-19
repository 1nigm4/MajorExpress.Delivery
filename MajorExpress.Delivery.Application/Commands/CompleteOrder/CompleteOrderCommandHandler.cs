namespace MajorExpress.Delivery.Application.Commands.CompleteOrder
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
    ///     Обработчик команды <see cref="CompleteOrderCommand"/>
    /// </summary>
    public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommand, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Order, OrderDto> _mapper;

        public CompleteOrderCommandHandler(
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork,
            IMapper<Order, OrderDto> mapper)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(CompleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.Id, cancellationToken, order => order.Client.User, order => order.Cargo, order => order.Courier.User);
            if (order == null)
            {
                throw new OrderNotFoundException(orderId: request.Id);
            }

            if (order.Status != OrderStatus.SubmittedForExecution)
            {
                throw new OrderNotInStatusExecutionException(orderId: request.Id);
            }

            order.Status = OrderStatus.Completed;
            await _orderRepository.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map(order);
        }
    }
}
