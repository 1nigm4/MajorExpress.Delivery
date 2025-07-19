namespace MajorExpress.Delivery.Application.Dto
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public ClientDto Client { get; set; }

        public CargoDto Cargo { get; set; }

        public CourierDto? Courier { get; set; }

        public DateTime CreatedAt { get; set; }

        public byte Status { get; set; }

        public string? CancelComment { get; set; }

        public DateTime PickupTime { get; set; }

        public string PickupAddress { get; set; }

        public string DeliveryAddress { get; set; }
    }
}
