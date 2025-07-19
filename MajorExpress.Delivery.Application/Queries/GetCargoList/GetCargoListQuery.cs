namespace MajorExpress.Delivery.Application.Queries.GetCargoList
{
    using MajorExpress.Delivery.Application.Dto;
    using MediatR;

    /// <summary>
    ///     Запрос на получение списка товаров
    /// </summary>
    public class GetCargoListQuery : PaginationListQuery, IRequest<PaginationListQueryResponse<CargoDto>>
    {
        public GetCargoListQuery(int pageIndex, int pageSize) : base(pageIndex, pageSize)
        {
        }
    }
}
