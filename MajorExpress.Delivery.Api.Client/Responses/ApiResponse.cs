namespace MajorExpress.Delivery.Api.Client.Responses
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Ответ сервера
    /// </summary>
    /// <typeparam name="T">Тип данных</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        ///     Данные
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; }

        /// <summary>
        ///     Успешно
        /// </summary>
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        /// <summary>
        ///     Сообщение ошибки
        /// </summary>
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     Код
        /// </summary>
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
    }
}
