namespace MajorExpress.Delivery.Api.Client.Models
{
    /// <summary>
    ///     Товар
    /// </summary>
    public class Cargo
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
        public ushort Weight { get; set; }

        /// <summary>
        ///     Размер
        /// </summary>
        public ushort Size { get; set; }
    }
}
