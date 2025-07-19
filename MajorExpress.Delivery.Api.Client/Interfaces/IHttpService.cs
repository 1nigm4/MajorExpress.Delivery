namespace MajorExpress.Delivery.Api.Client.Interfaces
{
    using MajorExpress.Delivery.Api.Client.Responses;

    /// <summary>
    ///     Сервис запросов
    /// </summary>
    public interface IHttpService
    {
        /// <summary>
        ///     GET-запрос
        /// </summary>
        Task<ApiResponse<TResponse>> GetAsync<TResponse>(string endpoint, CancellationToken ct = default);

        /// <summary>
        ///     POST-запрос
        /// </summary>
        Task<ApiResponse<TResponse>> PostAsync<TRequest, TResponse>(string endpoint, TRequest request, CancellationToken ct = default);

        /// <summary>
        ///     PUT-запрос
        /// </summary>
        Task<ApiResponse<TResponse>> PutAsync<TRequest, TResponse>(string endpoint, TRequest request, CancellationToken ct = default);

        /// <summary>
        ///     DELETE-запрос
        /// </summary>
        Task<ApiResponse<TResponse>> DeleteAsync<TResponse>(string endpoint, CancellationToken ct = default);
    }
}
