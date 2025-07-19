namespace MajorExpress.Delivery.Application.Queries.GetClientList
{
    using MajorExpress.Delivery.Application.Dto;
    using MediatR;

    /// <summary>
    ///     Запрос на получение списка клиентов
    /// </summary>
    public class GetClientListQuery : PaginationListQuery, IRequest<PaginationListQueryResponse<ClientDto>>
    {
        public GetClientListQuery(int pageIndex, int pageSize) : base(pageIndex, pageSize)
        {
        }
    }
}
