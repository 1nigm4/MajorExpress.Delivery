namespace MajorExpress.Delivery.Application.Queries.GetOrderList
{
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Interfaces;
    using MajorExpress.Delivery.Domain.Models;
    using MajorExpress.Delivery.Domain.Repositories;
    using MediatR;

    /// <summary>
    ///     Обработчик запроса <see cref="GetOrderListQuery"/>
    /// </summary>
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, PaginationListQueryResponse<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper<Order, OrderDto> _mapper;

        public GetOrderListQueryHandler(
            IOrderRepository orderRepository,
            IMapper<Order, OrderDto> mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public Task<PaginationListQueryResponse<OrderDto>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var orders = _orderRepository.GetAll(order => order.Client.User, order => order.Cargo, order => order.Courier.User);
            if (!string.IsNullOrWhiteSpace(request.Filter))
            {
                orders = _orderRepository.Filter(orders, request.Filter);
            }

            var totalCount = orders.Count();
            var result = orders.Skip(request.PageSize * (request.PageIndex - 1))
                .Take(request.PageSize)
                .Select(_mapper.Map)
                .ToArray();

            return Task.FromResult(new PaginationListQueryResponse<OrderDto>(result, request.PageIndex, request.PageSize, totalCount));
        }
    }
}
