namespace MajorExpress.Delivery.Application.Impl
{
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Interfaces;
    using MajorExpress.Delivery.Domain.Models;

    public class CargoMapper : IMapper<Cargo, CargoDto>
    {
        public CargoDto Map(Cargo entity)
        {
            return new CargoDto
            {
                Id = entity.Id,
                Description = entity.Description,
                Weight = entity.Weight,
                Size = entity.Size,
            };
        }
    }
}
