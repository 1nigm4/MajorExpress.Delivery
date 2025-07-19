namespace MajorExpress.Delivery.Application.Dto
{
    using MajorExpress.Delivery.Domain.Models;

    /// <summary>
    ///     ДТО <see cref="Cargo"/>
    /// </summary>
    public class CargoDto
    {
        /// <summary>
        ///     Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Вес
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        ///     Размер
        /// </summary>
        public decimal Size { get; set; }
    }
}
