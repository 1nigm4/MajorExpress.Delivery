namespace MajorExpress.Delivery.Domain.Repositories
{
    using System.Linq.Expressions;
    using MajorExpress.Delivery.Domain.Models;

    /// <summary>
    ///     Базовый интерфейс репозитория CRUD операций
    /// </summary>
    /// <typeparam name="TEntity">Сущность</typeparam>
    /// <typeparam name="TId">Идентификатор</typeparam>
    public interface IRepository<TEntity> where TEntity : Entity
    {
        /// <summary>
        ///     Получить все записи
        /// </summary>
        /// <param name="includes">Включить связи</param>
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        ///     Получить по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="ct">Токен отмены</param>
        /// <param name="includes">Включить связи</param>
        Task<TEntity?> GetAsync(Guid id, CancellationToken ct = default, params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        ///     Добавить
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="ct">Токен отмены</param>
        Task CreateAsync(TEntity entity, CancellationToken ct = default);

        /// <summary>
        ///     Обновить
        /// </summary>
        /// <param name="entity">Сущность</param>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        ///     Удалить
        /// </summary>
        /// <param name="entity">Сущность</param>
        Task RemoveAsync(TEntity entity);
    }
}
