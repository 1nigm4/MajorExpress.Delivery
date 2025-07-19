namespace MajorExpress.Delivery.Domain.Repositories
{
    using MajorExpress.Delivery.Domain.Models;

    /// <summary>
    ///     Интерфейс репозитория сущности <see cref="Order"/>
    /// </summary>
    public interface IOrderRepository : IRepository<Order>
    {
        /// <summary>
        ///     Фильтрация по всем полям
        /// </summary>
        /// <param name="query">Запрос</param>
        /// <param name="filter">Фильтр</param>
        IQueryable<Order> Filter(IQueryable<Order> query, string filter);
    }
}
