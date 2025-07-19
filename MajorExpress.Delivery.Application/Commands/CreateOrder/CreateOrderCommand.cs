namespace MajorExpress.Delivery.Application.Commands.CreateOrder
{
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MediatR;

    /// <summary>
    ///     Команда "Создать" заявку
    /// </summary>
    public class CreateOrderCommand : IRequest<OrderDto>
    {
        public CreateOrderCommand(Guid clientId, Guid cargoId, string pickupAddress, string deliveryAddress, DateTime pickupTime)
        {
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

            this.ClientId = clientId;
            this.CargoId = cargoId;
            this.PickupAddress = pickupAddress;
            this.DeliveryAddress = deliveryAddress;
            this.PickupTime = pickupTime;
        }

        public Guid ClientId { get; set; }

        public Guid CargoId { get; set; }

        public string PickupAddress { get; set; }

        public string DeliveryAddress { get; set; }

        public DateTime PickupTime { get; set; }
    }
}
