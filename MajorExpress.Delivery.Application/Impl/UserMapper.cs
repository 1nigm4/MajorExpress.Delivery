namespace MajorExpress.Delivery.Application.Impl
{
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Interfaces;
    using MajorExpress.Delivery.Domain.Models;

    public class UserMapper : IMapper<User, UserDto>
    {
        public UserDto Map(User entity)
        {
            return new UserDto
            {
                Id = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Patronymic = entity.Patronymic,
                PhoneNumber = entity.PhoneNumber,
            };
        }
    }
}
