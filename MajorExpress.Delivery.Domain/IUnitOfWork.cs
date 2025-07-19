namespace MajorExpress.Delivery.Domain
{
    /// <summary>
    ///     Контекст
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        ///     Сохранить изменения
        /// </summary>
        /// <param name="ct">Токен отмены</param>
        Task<int> SaveChangesAsync(CancellationToken ct);
    }
}
