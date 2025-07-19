namespace MajorExpress.Delivery.Application.Queries
{
    using MajorExpress.Delivery.Application.Exceptions;

    /// <summary>
    ///     Базовый запрос спискка с пагинацией
    /// </summary>
    public class PaginationListQuery
    {
        public PaginationListQuery(int pageIndex, int pageSize, string? filter = null)
        {
            if (pageIndex < 1) throw new MajorException(new ArgumentException("Страница должна быть больше 1", nameof(pageIndex)));
            if (pageSize < 1) throw new MajorException(new ArgumentException("Размер страницы должен быть больше 1", nameof(pageSize)));

            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.Filter = filter;
        }

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
