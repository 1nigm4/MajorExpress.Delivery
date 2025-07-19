namespace MajorExpress.Delivery.Api.Client.Services
{
    using MajorExpress.Delivery.Api.Client.Interfaces;
    using MajorExpress.Delivery.Api.Client.Models;
    using MajorExpress.Delivery.Api.Client.Requests;
    using MajorExpress.Delivery.Api.Client.Responses;

    public class DeliveryApiClient : IDeliveryApiClient
    {
        private readonly IHttpService _httpService;

        public DeliveryApiClient(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<ApiResponse<Courier>> GetCourierAsync(Guid courierId, CancellationToken ct = default)
        {
            return await _httpService.GetAsync<Courier>($"/api/Courier/Get/{courierId}", ct);
        }

        public async Task<ApiResponse<Courier>> CreateCourierAsync(Courier courier, CancellationToken ct = default)
        {
            return await _httpService.PostAsync<Courier, Courier>("/api/Courier/Create", courier, ct);
        }

        public async Task<ApiResponse<Client>> GetClientAsync(Guid clientId, CancellationToken ct = default)
        {
            return await _httpService.GetAsync<Client>($"/api/Client/Get/{clientId}", ct);
        }

        public async Task<ApiResponse<Client>> CreateClientAsync(Client client, CancellationToken ct = default)
        {
            return await _httpService.PostAsync<Client, Client>("/api/Client/Create", client, ct);
        }

        public async Task<ApiResponse<Cargo>> GetCargoAsync(Guid cargoId, CancellationToken ct = default)
        {
            return await _httpService.GetAsync<Cargo>($"/api/Cargo/Get/{cargoId}", ct);
        }

        public async Task<ApiResponse<Cargo>> CreateCargoAsync(Cargo cargo, CancellationToken ct = default)
        {
            return await _httpService.PostAsync<Cargo, Cargo>("/api/Cargo/Create", cargo, ct);
        }

        public async Task<ApiResponse<User>> GetUserAsync(Guid userId, CancellationToken ct = default)
        {
            return await _httpService.GetAsync<User>($"/api/User/Get/{userId}", ct);
        }

        public async Task<ApiResponse<User>> CreateUserAsync(User user, CancellationToken ct = default)
        {
            return await _httpService.PostAsync<User, User>("/api/User/Create", user, ct);
        }

        public async Task<ApiResponse<User>> UpdateUserAsync(User user, CancellationToken ct = default)
        {
            return await _httpService.PutAsync<User, User>("/api/User/Update", user, ct);
        }

        public async Task<ApiResponse<Order>> GetOrderAsync(Guid orderId, CancellationToken ct = default)
        {
            return await _httpService.GetAsync<Order>($"/api/Order/Get/{orderId}", ct);
        }

        public async Task<ApiResponse<Order>> CreateOrderAsync(Order order, CancellationToken ct = default)
        {
            return await _httpService.PostAsync<Order, Order>("/api/order/Register", order, ct);
        }

        public async Task<ApiResponse<Order>> ExecuteOrderAsync(Order order, CancellationToken ct = default)
        {
            return await _httpService.PostAsync<Order, Order>("/api/order/Execute", order, ct);
        }

        public async Task<ApiResponse<Order>> CompleteOrderAsync(Order order, CancellationToken ct = default)
        {
            return await _httpService.PostAsync<Order, Order>("/api/order/Complete", order, ct);
        }

        public async Task<ApiResponse<Order>> CancelOrderAsync(Order order, CancellationToken ct = default)
        {
            return await _httpService.PostAsync<Order, Order>("/api/order/Cancel", order, ct);
        }


        public async Task<ApiResponse<Order>> UpdateOrderAsync(Order order, CancellationToken ct = default)
        {
            return await _httpService.PutAsync<Order, Order>("/api/Order/Update", order, ct);
        }

        public async Task<ApiResponse<Guid>> RemoveOrderAsync(Guid orderId, CancellationToken ct = default)
        {
            return await _httpService.DeleteAsync<Guid>($"/api/Order/Remove/{orderId}", ct);
        }

        public async Task<ApiResponse<ListResponse<Order>>> ListOrdersAsync(ListRequest request, CancellationToken ct = default)
        {
            var endpoint = $"/api/Order/List?pageIndex={request.PageIndex}&pageSize={request.PageSize}";
            if (!string.IsNullOrWhiteSpace(request.Filter))
            {
                endpoint += $"&filter={request.Filter}";
            }

            return await _httpService.GetAsync<ListResponse<Order>>(endpoint, ct);
        }

        public async Task<ApiResponse<ListResponse<User>>> ListUsersAsync(ListRequest request, CancellationToken ct = default)
        {
            return await _httpService.GetAsync<ListResponse<User>>($"/api/User/List?pageIndex={request.PageIndex}&pageSize={request.PageSize}", ct);
        }

        public async Task<ApiResponse<ListResponse<Cargo>>> ListCargosAsync(ListRequest request, CancellationToken ct = default)
        {
            return await _httpService.GetAsync<ListResponse<Cargo>>($"/api/Cargo/List?pageIndex={request.PageIndex}&pageSize={request.PageSize}", ct);
        }

        public async Task<ApiResponse<ListResponse<Client>>> ListClientsAsync(ListRequest request, CancellationToken ct = default)
        {
            return await _httpService.GetAsync<ListResponse<Client>>($"/api/Client/List?pageIndex={request.PageIndex}&pageSize={request.PageSize}", ct);
        }

        public async Task<ApiResponse<ListResponse<Courier>>> ListCouriersAsync(ListRequest request, CancellationToken ct = default)
        {
            return await _httpService.GetAsync<ListResponse<Courier>>($"/api/Courier/List?pageIndex={request.PageIndex}&pageSize={request.PageSize}", ct);
        }
    }
}
