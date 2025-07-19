namespace MajorExpress.Delivery.Domain.Models
{
    /// <summary>
    ///     Груз
    /// </summary>
    public class Cargo : Entity
    {
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
