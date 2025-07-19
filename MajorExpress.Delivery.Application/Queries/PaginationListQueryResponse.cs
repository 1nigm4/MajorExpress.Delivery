namespace MajorExpress.Delivery.Application.Queries
{
    using System.Collections.Generic;

    /// <summary>
    ///     Результат запроса списка с пагинацией
    /// </summary>
    /// <typeparam name="T">Тип списка</typeparam>
    public class PaginationListQueryResponse<T>
    {
        public PaginationListQueryResponse(
            IReadOnlyCollection<T> items,
            int pageIndex,
            int pageSize,
            int totalCount)
        {
            this.Items = items;
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
        }

        /// <summary>
        ///     Список
        /// </summary>
        public IReadOnlyCollection<T> Items { get; set; }

        /// <summary>
        ///     Страница
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        ///     Размер страницы
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        ///     Общее количество
        /// </summary>
        public int TotalCount { get; set; }
    }
}
