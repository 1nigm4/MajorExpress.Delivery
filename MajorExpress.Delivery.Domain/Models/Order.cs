namespace MajorExpress.Delivery.Domain.Models
{
    /// <summary>
    ///     Заявка
    /// </summary>
    public class Order : Entity
    {
        /// <summary>
        ///     Клиент
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        ///     Груз
        /// </summary>
        public Cargo Cargo { get; set; }

        /// <summary>
        ///     Исполнитель
        /// </summary>
        public Courier? Courier { get; set; }

        /// <summary>
        ///     Статус
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        ///     Дата создания
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        ///     Адрес отправления
        /// </summary>
        public string PickupAddress { get; set; }

        /// <summary>
        ///     Адрес получателя
        /// </summary>
        public string DeliveryAddress { get; set; }

        /// <summary>
        ///     Дата получения
        /// </summary>
        public DateTime PickupTime { get; set; }

        /// <summary>
        ///     Причина отмены
        /// </summary>
        public string? CancelComment { get; set; }
    }
}
