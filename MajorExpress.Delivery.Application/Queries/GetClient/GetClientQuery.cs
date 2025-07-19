namespace MajorExpress.Delivery.Application.Queries.GetClient
{
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MediatR;

    /// <summary>
    ///     Запрос на получение клиента
    /// </summary>
    public class GetClientQuery : IRequest<ClientDto>
    {
        public GetClientQuery(Guid id)
        {
            if (id == default)
            {
                throw new MajorException(new ArgumentException("Необходимо передать идентификатор клиента", nameof(id)));
            }

            this.Id = id;
        }

        /// <summary>
        ///     Идентификатор клиента
        /// </summary>
        public Guid Id { get; set; }
    }
}
