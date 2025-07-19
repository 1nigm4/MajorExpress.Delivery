namespace MajorExpress.Delivery.Api.Client.DesktopApp.Interfaces
{
    /// <summary>
    ///     Сервис уведомлений
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        ///     Показать всплывающее уведомление
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="title">Заголовок</param>
        void Alert(string text, string? title = null);
    }
}
