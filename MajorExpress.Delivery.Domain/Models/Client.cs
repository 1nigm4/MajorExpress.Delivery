namespace MajorExpress.Delivery.Domain.Models
{
    /// <summary>
    ///     Клиент
    /// </summary>
    public class Client : Entity
    {
        /// <summary>
        ///     Пользователь
        /// </summary>
        public User User { get; set; }
    }
}
