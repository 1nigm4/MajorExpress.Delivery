namespace MajorExpress.Delivery.Application.Queries.GetCourierList
{
    using MajorExpress.Delivery.Application.Dto;
    using MediatR;

    /// <summary>
    ///     Запрос на получение списка курьеров
    /// </summary>
    public class GetCourierListQuery : PaginationListQuery, IRequest<PaginationListQueryResponse<CourierDto>>
    {
        public GetCourierListQuery(int pageIndex, int pageSize) : base(pageIndex, pageSize)
        {
        }
    }
}
