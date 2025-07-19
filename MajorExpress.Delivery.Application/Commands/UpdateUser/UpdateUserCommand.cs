namespace MajorExpress.Delivery.Application.Commands.UpdateUser
{
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MediatR;

    /// <summary>
    ///     Команда "Редактировать" пользователя
    /// </summary>
    public class UpdateUserCommand : IRequest<UserDto>
    {
        public UpdateUserCommand(Guid id, string lastName, string firstName, string? patronymic, string phoneNumber)
        {
            if (id == default)
            {
                throw new MajorException(new ArgumentException("Необходимо передать идентификатор пользователя", nameof(id)));
            }

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

            this.Id = id;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Patronymic = patronymic;
            this.PhoneNumber = phoneNumber;
        }

        /// <summary>
        ///     Идентификатор пользователя
        /// </summary>
        public Guid Id { get; set; }

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
