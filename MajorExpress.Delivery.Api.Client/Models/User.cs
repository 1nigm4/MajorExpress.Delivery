namespace MajorExpress.Delivery.Api.Client.Models
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Идентификатор пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        ///     Идентификатор
        /// </summary>
        public Guid Id { get; set; }

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

        /// <summary>
        ///     ФИО
        /// </summary>
        [JsonIgnore]
        public string FIO => $"{LastName} {FirstName}{(!string.IsNullOrWhiteSpace(Patronymic) ? ' ' + this.Patronymic : string.Empty)}";
    }
}
