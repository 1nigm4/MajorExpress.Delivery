namespace MajorExpress.Delivery.Application.Commands.CreateUser
{
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MediatR;

    /// <summary>
    ///     Команда "Создать" пользователя
    /// </summary>
    public class CreateUserCommand : IRequest<UserDto>
    {
        public CreateUserCommand(string lastName, string firstName, string? patronymic, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new MajorException(new ArgumentException("Необходимо указать фамилию", nameof(lastName)));
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new MajorException(new ArgumentException("Необходимо указать имя", nameof(lastName)));
            }

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new MajorException(new ArgumentException("Необходимо указать номер телефона", nameof(lastName)));
            }


            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        ///     Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Отчество
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        ///     Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
