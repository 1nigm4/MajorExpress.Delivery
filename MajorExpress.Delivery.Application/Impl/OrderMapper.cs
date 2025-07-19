namespace MajorExpress.Delivery.Application.Impl
{
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Interfaces;
    using MajorExpress.Delivery.Domain.Models;

    public class OrderMapper : IMapper<Order, OrderDto>
    {
        private readonly IMapper<Client, ClientDto> _clientMapper;
        private readonly IMapper<Cargo, CargoDto> _cargoMapper;
        private readonly IMapper<Courier, CourierDto> _courierMapper;

        public OrderMapper(
            IMapper<Client, ClientDto> clientMapper,
            IMapper<Cargo, CargoDto> cargoMapper,
            IMapper<Courier, CourierDto> courierMapper)
        {
            _clientMapper = clientMapper;
            _cargoMapper = cargoMapper;
            _courierMapper = courierMapper;
        }

        public OrderDto Map(Order entity)
        {
            return new OrderDto
            {
                Id = entity.Id,
                Client = _clientMapper.Map(entity.Client),
                Cargo = _cargoMapper.Map(entity.Cargo),
                Courier = _courierMapper.Map(entity.Courier),
                CreatedAt = entity.CreatedAt,
                PickupTime = entity.PickupTime,
                PickupAddress = entity.PickupAddress,
                DeliveryAddress = entity.DeliveryAddress,
                Status = entity.Status.Value,
                CancelComment = entity.CancelComment,
            };
        }
    }
}
