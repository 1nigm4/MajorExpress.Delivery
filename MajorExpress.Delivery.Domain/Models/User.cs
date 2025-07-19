namespace MajorExpress.Delivery.Domain.Models
{
    /// <summary>
    ///     Контактная информация
    /// </summary>
    public class User : Entity
    {
        /// <summary>
        ///     Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Фамилия
        /// </summary>
        public string LastName { get; set; }

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
