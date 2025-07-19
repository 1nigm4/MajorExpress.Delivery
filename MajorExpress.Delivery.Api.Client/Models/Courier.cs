namespace MajorExpress.Delivery.Api.Client.Models
{
    /// <summary>
    ///     Курьер
    /// </summary>
    public class Courier
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
