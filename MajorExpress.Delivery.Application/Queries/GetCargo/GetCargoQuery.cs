namespace MajorExpress.Delivery.Application.Queries.GetCargo
{
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MediatR;

    /// <summary>
    ///     Запрос на получение товара
    /// </summary>
    public class GetCargoQuery : IRequest<CargoDto>
    {
        public GetCargoQuery(Guid id)
        {
            if (id == default)
            {
                throw new MajorException(new ArgumentException("Необходимо передать идентификатор товара", nameof(id)));
            }

            this.Id = id;
        }

        /// <summary>
        ///     Идентификатор товара
        /// </summary>
        public Guid Id { get; set; }
    }
}
