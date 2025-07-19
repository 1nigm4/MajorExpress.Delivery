namespace MajorExpress.Delivery.Application.Queries.GetCourier
{
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MediatR;

    /// <summary>
    ///     Запрос на получение курьера
    /// </summary>
    public class GetCourierQuery : IRequest<CourierDto>
    {
        public GetCourierQuery(Guid id)
        {
            if (id == default)
            {
                throw new MajorException(new ArgumentException("Необходимо передать идентификатор курьера", nameof(id)));
            }

            this.Id = id;
        }

        /// <summary>
        ///     Идентификатор курьера
        /// </summary>
        public Guid Id { get; set; }
    }
}
