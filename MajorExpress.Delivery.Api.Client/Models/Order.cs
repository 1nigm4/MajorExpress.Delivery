namespace MajorExpress.Delivery.Api.Client.Models
{
    /// <summary>
    ///     Заявка
    /// </summary>
    public class Order
    {
        /// <summary>
        ///     Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Идентификатор клиента
        /// </summary>
        public Guid ClientId => this.Client?.Id ?? default;

        /// <summary>
        ///     Клиент
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        ///     Идентификатор товара
        /// </summary>
        public Guid CargoId => this.Cargo?.Id ?? default;

        /// <summary>
        ///     Груз
        /// </summary>
        public Cargo Cargo { get; set; }

        /// <summary>
        ///     Идентификатор курьера
        /// </summary>
        public Guid CourierId => this.Courier?.Id ?? default;

        /// <summary>
        ///     Курьер
        /// </summary>
        public Courier Courier { get; set; }

        /// <summary>
        ///     Дата создания
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        ///     Дата погрузки
        /// </summary>
        public DateTime PickupTime { get; set; }

        /// <summary>
        ///     Адрес погрузки
        /// </summary>
        public string PickupAddress { get; set; }

        /// <summary>
        ///     Адрес выгрузки
        /// </summary>
        public string DeliveryAddress { get; set; }

        /// <summary>
        ///     Статус
        /// </summary>
        public byte Status { get; set; }

        /// <summary>
        ///     Причина отмены
        /// </summary>
        public string? CancelComment { get; set; }
    }
}
