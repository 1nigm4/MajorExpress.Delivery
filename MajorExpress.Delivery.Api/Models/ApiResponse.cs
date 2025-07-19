namespace MajorExpress.Delivery.Api.Models
{
    /// <summary>
    ///     Ответ сервера
    /// </summary>
    /// <typeparam name="T">Данные</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        ///     Данные
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        ///     Успешно
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        ///     Сообщение ошибки
        /// </summary>
        public string? ErrorMessage { get; set; }
        
        /// <summary>
        ///     Код ошибки
        /// </summary>
        public int StatusCode { get; set; }
    }
}
