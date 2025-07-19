namespace MajorExpress.Delivery.Api.Client.Models
{
    /// <summary>
    ///     Клиент
    /// </summary>
    public class Client
    {
        /// <summary>
        ///     Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Идентификатор пользователя
        /// </summary>
        public Guid UserId => this.User?.Id ?? default;

        /// <summary>
        ///     Пользователь
        /// </summary>
        public User User { get; set; }
    }
}
