namespace MajorExpress.Delivery.Domain.Models
{
    /// <summary>
    ///     Курьер
    /// </summary>
    public class Courier : Entity
    {
        /// <summary>
        ///     Пользователь
        /// </summary>
        public User User { get; set; }
    }
}
