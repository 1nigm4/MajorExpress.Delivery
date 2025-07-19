namespace MajorExpress.Delivery.Api.Client.Interfaces
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MajorExpress.Delivery.Api.Client.Models;
    using MajorExpress.Delivery.Api.Client.Requests;
    using MajorExpress.Delivery.Api.Client.Responses;

    public interface IDeliveryApiClient
    {
        Task<ApiResponse<Order>> CancelOrderAsync(Order order, CancellationToken ct = default);
        Task<ApiResponse<Order>> CompleteOrderAsync(Order order, CancellationToken ct = default);
        Task<ApiResponse<Cargo>> CreateCargoAsync(Cargo cargo, CancellationToken ct = default);
        Task<ApiResponse<Client>> CreateClientAsync(Client client, CancellationToken ct = default);
        Task<ApiResponse<Courier>> CreateCourierAsync(Courier courier, CancellationToken ct = default);
        Task<ApiResponse<Order>> CreateOrderAsync(Order order, CancellationToken ct = default);
        Task<ApiResponse<User>> CreateUserAsync(User user, CancellationToken ct = default);
        Task<ApiResponse<Order>> ExecuteOrderAsync(Order order, CancellationToken ct = default);
        Task<ApiResponse<Guid>> RemoveOrderAsync(Guid orderId, CancellationToken ct = default);
        Task<ApiResponse<Order>> UpdateOrderAsync(Order order, CancellationToken ct = default);
        Task<ApiResponse<User>> UpdateUserAsync(User user, CancellationToken ct = default);
        Task<ApiResponse<Cargo>> GetCargoAsync(Guid cargoId, CancellationToken ct = default);
        Task<ApiResponse<Client>> GetClientAsync(Guid clientId, CancellationToken ct = default);
        Task<ApiResponse<Courier>> GetCourierAsync(Guid courierId, CancellationToken ct = default);
        Task<ApiResponse<Order>> GetOrderAsync(Guid orderId, CancellationToken ct = default);
        Task<ApiResponse<User>> GetUserAsync(Guid userId, CancellationToken ct = default);
        Task<ApiResponse<ListResponse<Cargo>>> ListCargosAsync(ListRequest request, CancellationToken ct = default);
        Task<ApiResponse<ListResponse<Client>>> ListClientsAsync(ListRequest request, CancellationToken ct = default);
        Task<ApiResponse<ListResponse<Courier>>> ListCouriersAsync(ListRequest request, CancellationToken ct = default);
        Task<ApiResponse<ListResponse<Order>>> ListOrdersAsync(ListRequest request, CancellationToken ct = default);
        Task<ApiResponse<ListResponse<User>>> ListUsersAsync(ListRequest request, CancellationToken ct = default);
    }
}
