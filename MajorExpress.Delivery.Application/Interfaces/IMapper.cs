namespace MajorExpress.Delivery.Application.Interfaces
{
    using MajorExpress.Delivery.Domain.Models;

    /// <summary>
    ///     Маппер
    /// </summary>
    /// <typeparam name="TEntity">Сущность</typeparam>
    /// <typeparam name="TDto">ДТО</typeparam>
    public interface IMapper<TEntity, TDto> where TEntity : Entity where TDto : class
    {
        /// <summary>
        ///     Смапить
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <returns>ДТО</returns>
        TDto Map(TEntity entity);
    }
}
