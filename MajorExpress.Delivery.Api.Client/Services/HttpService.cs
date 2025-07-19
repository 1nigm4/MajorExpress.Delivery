namespace MajorExpress.Delivery.Api.Client.Services
{
    using System.Net.Http.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using MajorExpress.Delivery.Api.Client.Exceptions;
    using MajorExpress.Delivery.Api.Client.Interfaces;
    using MajorExpress.Delivery.Api.Client.Models;
    using MajorExpress.Delivery.Api.Client.Responses;
    using Newtonsoft.Json;

    internal class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiConfiguration _configuration;

        public HttpService(HttpClient httpClient, ApiConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

            httpClient.BaseAddress = new Uri(configuration.BaseUrl);
        }

        public async Task<ApiResponse<TResponse>> GetAsync<TResponse>(string endpoint, CancellationToken ct = default)
        {
            return await this.SendRequestAsync<TResponse>(HttpMethod.Get, endpoint, cancellationToken: ct);
        }

        public async Task<ApiResponse<TResponse>> PostAsync<TRequest, TResponse>(string endpoint, TRequest request, CancellationToken ct = default)
        {
            return await this.SendRequestAsync<TResponse>(HttpMethod.Post, endpoint, request, ct);
        }

        public async Task<ApiResponse<TResponse>> PutAsync<TRequest, TResponse>(string endpoint, TRequest request, CancellationToken ct = default)
        {
            return await this.SendRequestAsync<TResponse>(HttpMethod.Put, endpoint, request, ct);
        }

        public async Task<ApiResponse<TResponse>> DeleteAsync<TResponse>(string endpoint, CancellationToken ct = default)
        {
            return await this.SendRequestAsync<TResponse>(HttpMethod.Delete, endpoint, cancellationToken: ct);
        }

        private async Task<ApiResponse<TResponse>> SendRequestAsync<TResponse>(
            HttpMethod method,
            string endpoint,
            object? data = null,
            CancellationToken cancellationToken = default)
        {
            try
            {
                using var request = new HttpRequestMessage(method, endpoint);

                if (data != null)
                {
                    request.Content = JsonContent.Create(data);
                }

                var response = await _httpClient.SendAsync(request, cancellationToken);
                var content = await response.Content.ReadAsStringAsync(cancellationToken);

                var result = JsonConvert.DeserializeObject<ApiResponse<TResponse>>(content)!;

                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse<TResponse>
                {
                    IsSuccess = false,
                    ErrorMessage = ex is ApiException ? ex.Message : "Произошла непредвиденная ошибка, обратитесь к администратору системы",
                    StatusCode = ex is ApiException apiEx ? apiEx.StatusCode : 500
                };
            }
        }
    }
}
