namespace MajorExpress.Delivery.Application.Queries.GetOrderList
{
    using MajorExpress.Delivery.Application.Dto;
    using MediatR;

    /// <summary>
    ///     Запрос на получение списка заявок
    /// </summary>
    public class GetOrderListQuery : PaginationListQuery, IRequest<PaginationListQueryResponse<OrderDto>>
    {
        public GetOrderListQuery(int pageIndex, int pageSize, string? filter = null) : base(pageIndex, pageSize, filter)
        {
        }
    }
}
