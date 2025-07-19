namespace MajorExpress.Delivery.Api.Client.Responses
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Ответ список
    /// </summary>
    /// <typeparam name="T">Тип списка</typeparam>
    public class ListResponse<T>
    {
        /// <summary>
        ///     Список
        /// </summary>
        [JsonProperty("items")]
        public T[]? Items { get; set; }

        /// <summary>
        ///     Страница
        /// </summary>
        [JsonProperty("pageIndex")]
        public int PageIndex { get; set; }

        /// <summary>
        ///     Размер страницы
        /// </summary>
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        /// <summary>
        ///     Общее количество
        /// </summary>
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
    }
}
