namespace MajorExpress.Delivery.Application.Queries.GetUserList
{
    using MajorExpress.Delivery.Application.Dto;
    using MediatR;

    /// <summary>
    ///     Запрос на получение списка пользователей
    /// </summary>
    public class GetUserListQuery : PaginationListQuery, IRequest<PaginationListQueryResponse<UserDto>>
    {
        public GetUserListQuery(int pageIndex, int pageSize) : base(pageIndex, pageSize)
        {
        }
    }
}
