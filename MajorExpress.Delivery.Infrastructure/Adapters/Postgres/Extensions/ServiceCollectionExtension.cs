namespace MajorExpress.Delivery.Infrastructure.Adapters.Postgres.Extensions
{
    using MajorExpress.Delivery.Domain;
    using MajorExpress.Delivery.Domain.Repositories;
    using MajorExpress.Delivery.Infrastructure.Adapters.Postgres.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtension
    {
        /// <summary>
        ///     Добавить СУБД Postgres
        /// </summary>
        /// <param name="connectionString">Строка подключения к БД</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static IServiceCollection AddPostgresAdapter(this IServiceCollection services, string? connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
            return services.AddRepositories();
        }

        /// <summary>
        ///     Добавить репозитории Postgres
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICourierRepository, CourierRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
