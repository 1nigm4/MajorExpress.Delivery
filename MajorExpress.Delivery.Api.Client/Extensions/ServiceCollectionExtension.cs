namespace MajorExpress.Delivery.Api.Client.Extensions
{
    using MajorExpress.Delivery.Api.Client.Interfaces;
    using MajorExpress.Delivery.Api.Client.Models;
    using MajorExpress.Delivery.Api.Client.Services;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtension
    {
        /// <summary>
        ///     Зарегистрировать клиента сервиса доставки MajorExpress
        /// </summary>
        /// <param name="configure">Настройки сервиса</param>
        public static IServiceCollection AddDeliveryClient(this IServiceCollection services, Action<ApiConfiguration> configure)
        {
            var configuration = new ApiConfiguration();
            configure?.Invoke(configuration);

            services.AddSingleton(configuration);
            services.AddHttpClient<IHttpService, HttpService>();
            services.AddScoped<IDeliveryApiClient, DeliveryApiClient>();
            return services;
        }
    }
}
