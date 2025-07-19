namespace MajorExpress.Delivery.Application.Commands.UpdateOrder
{
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MediatR;

    /// <summary>
    ///     Команда "Редактировать" заявку
    /// </summary>
    public class UpdateOrderCommand : IRequest<OrderDto>
    {
        public UpdateOrderCommand(
            Guid id,
            Guid clientId,
            Guid cargoId,
            DateTime pickupTime,
            string pickupAddress,
            string deliveryAddress)
        {
            if (id == default)
            {
                throw new MajorException(new ArgumentException("Необходимо передать идентификатор заявки", nameof(id)));
            }

            if (clientId == default)
            {
                throw new MajorException(new ArgumentException("Необходимо передать идентификатор клиента", nameof(clientId)));
            }

            if (cargoId == default)
            {
                throw new MajorException(new ArgumentException("Необходимо передать идентификатор товара", nameof(clientId)));
            }

            if (pickupTime == default)
            {
                throw new MajorException(new ArgumentException("Необходимо передать дату погрузки", nameof(clientId)));
            }

            if (string.IsNullOrWhiteSpace(pickupAddress))
            {
                throw new MajorException(new ArgumentException("Необходимо передать адрес погрузки", nameof(pickupAddress)));
            }

            if (string.IsNullOrWhiteSpace(deliveryAddress))
            {
                throw new MajorException(new ArgumentException("Необходимо передать адрес выгрузки", nameof(deliveryAddress)));
            }

            this.Id = id;
            this.ClientId = clientId;
            this.CargoId = cargoId;
            this.PickupTime = pickupTime;
            this.PickupAddress = pickupAddress;
            this.DeliveryAddress = deliveryAddress;
        }

        /// <summary>
        ///     Идентификатор заявки
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Идентификатор клиента
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        ///     Идентификатор товара
        /// </summary>
        public Guid CargoId { get; set; }

        /// <summary>
        ///     Время погрузки
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
    }
}
