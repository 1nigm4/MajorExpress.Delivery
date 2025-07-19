namespace MajorExpress.Delivery.Application.Queries.GetOrder
{
    using System.Threading;
    using System.Threading.Tasks;
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MajorExpress.Delivery.Application.Interfaces;
    using MajorExpress.Delivery.Domain.Models;
    using MajorExpress.Delivery.Domain.Repositories;
    using MediatR;

    /// <summary>
    ///     Обработчик запроса <see cref="GetOrderQuery"/>
    /// </summary>
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper<Order, OrderDto> _mapper;

        public GetOrderQueryHandler(
            IOrderRepository orderRepository,
            IMapper<Order, OrderDto> mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(
                request.Id,
                cancellationToken,
                order => order.Client.User, order => order.Cargo, order => order.Courier.User);
            if (order == null)
            {
                throw new OrderNotFoundException(orderId: request.Id);
            }

            return _mapper.Map(order);
        }
    }
}
