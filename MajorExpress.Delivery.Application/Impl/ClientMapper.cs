namespace MajorExpress.Delivery.Application.Impl
{
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Interfaces;
    using MajorExpress.Delivery.Domain.Models;

    public class ClientMapper : IMapper<Client, ClientDto>
    {
        private readonly IMapper<User, UserDto> _userMapper;

        public ClientMapper(IMapper<User, UserDto> userMapper)
        {
            _userMapper = userMapper;
        }

        public ClientDto Map(Client entity)
        {
            return new ClientDto
            {
                Id = entity.Id,
                User = _userMapper.Map(entity.User)
            };
        }
    }
}
