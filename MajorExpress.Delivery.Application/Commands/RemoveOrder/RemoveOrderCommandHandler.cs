namespace MajorExpress.Delivery.Application.Commands.RemoveOrder
{
    using System.Threading;
    using System.Threading.Tasks;
    using MajorExpress.Delivery.Application.Exceptions;
    using MajorExpress.Delivery.Domain;
    using MajorExpress.Delivery.Domain.Repositories;
    using MediatR;

    /// <summary>
    ///     Обработчик команды <see cref="RemoveOrderCommand"/>
    /// </summary>
    public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveOrderCommandHandler(
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.Id, cancellationToken);
            if (order == null)
            {
                throw new OrderNotFoundException(orderId: request.Id);
            }

            await _orderRepository.RemoveAsync(order);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
