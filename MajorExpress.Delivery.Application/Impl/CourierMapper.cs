namespace MajorExpress.Delivery.Application.Impl
{
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Interfaces;
    using MajorExpress.Delivery.Domain.Models;

    public class CourierMapper : IMapper<Courier, CourierDto>
    {
        private readonly IMapper<User, UserDto> _userMapper;

        public CourierMapper(IMapper<User, UserDto> userMapper)
        {
            _userMapper = userMapper;
        }

        public CourierDto Map(Courier entity)
        {
            if (entity == null) return null;
            return new CourierDto
            {
                Id = entity.Id,
                User = _userMapper.Map(entity.User)
            };
        }
    }
}
