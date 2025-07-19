namespace MajorExpress.Delivery.Application.Commands.CreateCargo
{
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MediatR;

    /// <summary>
    ///     Команда "Создать" груз
    /// </summary>
    public class CreateCargoCommand : IRequest<CargoDto>
    {
        public CreateCargoCommand(string description, decimal weight, decimal size)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new MajorException(new ArgumentException("Необходимо указать описание товара", nameof(description)));
            }

            if (weight == default)
            {
                throw new MajorException(new ArgumentException("Необходимо указать вес товара", nameof(weight)));
            }

            if (size == default)
            {
                throw new MajorException(new ArgumentException("Необходимо указать размер товара", nameof(size)));
            }

            this.Description = description;
            this.Weight = weight;
            this.Size = size;
        }

        /// <summary>
        ///     Описание
        /// </summary>
        public string Description { get; }

        /// <summary>
        ///     Вес
        /// </summary>
        public decimal Weight { get; }

        /// <summary>
        ///     Размер
        /// </summary>
        public decimal Size { get; }
    }
}
