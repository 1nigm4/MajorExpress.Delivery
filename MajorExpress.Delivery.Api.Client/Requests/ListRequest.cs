namespace MajorExpress.Delivery.Api.Client.Requests
{
    /// <summary>
    ///     Запрос на получение списка
    /// </summary>
    public class ListRequest
    {
        /// <summary>
        ///     Страница
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        ///     Размер страницы
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        ///     Фильтр
        /// </summary>
        public string? Filter { get; set; }
    }
}
