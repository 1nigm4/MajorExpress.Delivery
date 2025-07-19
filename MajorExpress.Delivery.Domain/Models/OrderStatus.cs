namespace MajorExpress.Delivery.Domain.Models
{
    /// <summary>
    ///     Статус заявки
    /// </summary>
    public class OrderStatus
    {
        /// <summary>
        ///     Новая
        /// </summary>
        public static readonly OrderStatus New = new OrderStatus("Новая", 1);

        /// <summary>
        ///     Передано на выполнение
        /// </summary>
        public static readonly OrderStatus SubmittedForExecution = new OrderStatus("Передано на выполнение", 2);

        /// <summary>
        ///     Выполнено
        /// </summary>
        public static readonly OrderStatus Completed = new OrderStatus("Выполнено", 3);

        /// <summary>
        ///     Отменена
        /// </summary>
        public static readonly OrderStatus Canceled = new OrderStatus("Отменена", 4);

        private OrderStatus(string title, byte value)
        {
            this.Title = title;
            this.Value = value;
        }

        /// <summary>
        ///     Название
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        ///     Значение
        /// </summary>
        public byte Value { get; private set; }

        /// <summary>
        ///     Получить все  статусы
        /// </summary>
        public static IEnumerable<OrderStatus> GetAllStatuses()
        {
            yield return OrderStatus.New;
            yield return OrderStatus.SubmittedForExecution;
            yield return OrderStatus.Completed;
            yield return OrderStatus.Canceled;
        }

        /// <summary>
        ///     Получить статус по названию
        /// </summary>
        /// <param name="title">Название</param>
        public static OrderStatus? FromTitle(string title)
        {
            return OrderStatus.GetAllStatuses()
                .SingleOrDefault(os => os.Title == title);
        }

        /// <summary>
        ///     Получить статус по значению
        /// </summary>
        /// <param name="value">Значение</param>
        /// <returns></returns>
        public static OrderStatus? FromValue(byte value)
        {
            return OrderStatus.GetAllStatuses()
                .SingleOrDefault(os => os.Value == value);
        }
    }
}
