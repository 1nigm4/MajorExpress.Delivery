namespace MajorExpress.Delivery.Application.Queries.GetOrder
{
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MediatR;

    /// <summary>
    ///     Запрос на получение заявки
    /// </summary>
    public class GetOrderQuery : IRequest<OrderDto>
    {
        public GetOrderQuery(Guid id)
        {
            if (id == default)
            {
                throw new MajorException(new ArgumentException("Необходимо передать идентификатор заявки", nameof(id)));
            }

            this.Id = id;
        }

        /// <summary>
        ///     Идентификатор заявки
        /// </summary>
        public Guid Id { get; set; }
    }
}
