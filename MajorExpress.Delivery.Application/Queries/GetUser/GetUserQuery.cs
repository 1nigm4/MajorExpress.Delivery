namespace MajorExpress.Delivery.Application.Queries.GetUser
{
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MediatR;

    /// <summary>
    ///     Запрос на получение пользователя
    /// </summary>
    public class GetUserQuery : IRequest<UserDto>
    {
        public GetUserQuery(Guid id)
        {
            if (id == default)
            {
                throw new MajorException(new ArgumentException("Необходимо передать идентификатор пользователя", nameof(id)));
            }

            this.Id = id;
        }

        /// <summary>
        ///     Идентификатор пользователя
        /// </summary>
        public Guid Id { get; set; }
    }
}
