namespace MajorExpress.Delivery.Application.Extensions
{
    using System.Reflection;
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Impl;
    using MajorExpress.Delivery.Application.Interfaces;
    using MajorExpress.Delivery.Domain.Models;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtension
    {
        /// <summary>
        ///     Зарегистрировать приложение
        /// </summary>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMappers()
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }

        /// <summary>
        ///     Добавить мапперы
        /// </summary>
        private static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddTransient<IMapper<Cargo, CargoDto>, CargoMapper>();
            services.AddTransient<IMapper<Client, ClientDto>, ClientMapper>();
            services.AddTransient<IMapper<Courier, CourierDto>, CourierMapper>();
            services.AddTransient<IMapper<Order, OrderDto>, OrderMapper>();
            services.AddTransient<IMapper<User, UserDto>, UserMapper>();
            return services;
        }
    }
}
