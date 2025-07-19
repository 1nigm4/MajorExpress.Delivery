namespace MajorExpress.Delivery.Application.Dto
{
    using MajorExpress.Delivery.Domain.Models;

    /// <summary>
    ///     ДТО <see cref="User"/>
    /// </summary>
    public class UserDto
    {
        /// <summary>
        ///     Идентификатор
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
