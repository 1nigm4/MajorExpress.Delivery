namespace MajorExpress.Delivery.Infrastructure.Adapters.Postgres
{
    using MajorExpress.Delivery.Domain.Models;
    using MajorExpress.Delivery.Infrastructure.Adapters.Postgres.EntityConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Diagnostics;

    /// <summary>
    ///     Контекст БД
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Courier> Couriers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Cargo> Cargos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(options => options.Ignore(RelationalEventId.PendingModelChangesWarning));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ClientEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CourierEntityTypeConfiguration());
            this.ApplyTestData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        ///     Заполнение тестовыми данными
        /// </summary>
        private void ApplyTestData(ModelBuilder modelBuilder)
        {
            var users = new User[]
            {
                new User
                {
                    Id = Guid.Parse("23244377-D294-46B4-9245-5DF4AF5D1D9F"),
                    LastName = "Сияносова",
                    FirstName = "Вера",
                    Patronymic = "Прокловна",
                    PhoneNumber = "+7 (978) 409-31-96"
                },
                new User
                {
                    Id = Guid.Parse("0EAA9E2A-EED0-4619-946C-AA91C320210E"),
                    LastName = "Кушкин",
                    FirstName = "Гавриил",
                    Patronymic = "Николаевич",
                    PhoneNumber = "+7 (970) 422-97-49"
                },
                new User
                {
                    Id = Guid.Parse("37FCE3F7-3C45-4117-A88D-204C2E931A76"),
                    LastName = "Кулатов",
                    FirstName = "Филипп",
                    Patronymic = "Маркович",
                    PhoneNumber = "+7 (959) 964-23-76"
                },
                new User
                {
                    Id = Guid.Parse("F23F844B-FFE5-4C13-9BE0-78997C289DE8"),
                    LastName = "Кинжаев",
                    FirstName = "Тимофей",
                    Patronymic = "Николаевич",
                    PhoneNumber = "+7 (913) 161-14-77"
                },
                new User
                {
                    Id = Guid.Parse("5B453A8E-C239-42ED-8B2D-AC04CE43C33B"),
                    LastName = "Батурина",
                    FirstName = "Ева",
                    Patronymic = "Афанасьевна",
                    PhoneNumber = "+7 (974) 364-82-60"
                },
                new User
                {
                    Id = Guid.Parse("E1A1DAF4-0F83-4358-919D-75C9C34280BF"),
                    LastName = "Уттеркло",
                    FirstName = "Людмила",
                    Patronymic = "Тимофеевна",
                    PhoneNumber = "+7 (921) 346-18-59"
                },
                new User
                {
                    Id = Guid.Parse("166A99B2-7ED0-4B41-87FB-AFFBDA39119D"),
                    LastName = "Дудко",
                    FirstName = "Александра",
                    Patronymic = "Егоровна",
                    PhoneNumber = "+7 (936) 742-93-76"
                },
                new User
                {
                    Id = Guid.Parse("6124C5DD-155E-453A-90D7-401F08B8F376"),
                    LastName = "Ярошевский",
                    FirstName = "Савва",
                    Patronymic = "Петрович",
                    PhoneNumber = "+7 (953) 595-58-95"
                },
            };

            modelBuilder.Entity<User>().HasData(users);

            var clients = new Guid[]
            {
                Guid.Parse("D5F3F9F7-8D6C-4100-AECF-4AF6E4969EB2"),
                Guid.Parse("F5CEA0F2-1BC8-402F-9E02-7E4512DE4FEA"),
                Guid.Parse("E6CA25F2-6691-410E-8C1B-7BE47B109995"),
                Guid.Parse("E83CCF84-DC67-45FD-8FB7-6D82B5319EE8"),
            }
                .Select((id, index) => new {
                    Id = id,
                    UserId = users[index].Id,
                });

            modelBuilder.Entity<Client>().HasData(clients);

            var couriers = new Guid[]
            {
                Guid.Parse("83108FB9-1177-4D2E-AE59-6B4C86B014BA"),
                Guid.Parse("95420664-AA3C-45BC-8170-2F60C4D8F697"),
                Guid.Parse("68A6A604-2B38-4376-95F9-B06652543E05"),
                Guid.Parse("EF391859-A5CC-4B04-AA7E-C43D8D8EF2F5"),
            }
                .Select((id, index) => new {
                    Id = id,
                    UserId = users[index + 4].Id,
                });

            modelBuilder.Entity<Courier>().HasData(couriers);

            var cargos = new Cargo[]
            {
                new Cargo
                {
                    Id = Guid.Parse("72A0B771-9CAF-41CA-B1E5-142C3A584CC6"),
                    Description = "Компьютер",
                    Weight = 5,
                    Size = 90,
                },
                new Cargo
                {
                    Id = Guid.Parse("B8AB0BA0-6067-4B85-ABC8-BE3236D40A78"),
                    Description = "Стол",
                    Weight = 7,
                    Size = 360,
                },
                new Cargo
                {
                    Id = Guid.Parse("14A3D5B1-FBC6-4300-8D5F-42AD13F5BFB9"),
                    Description = "Кресло",
                    Weight = 25,
                    Size = 240,
                },
                new Cargo
                {
                    Id = Guid.Parse("73B3DCD2-9FD9-427E-9257-29C5F28CEA5E"),
                    Description = "Шкаф",
                    Weight = 50,
                    Size = 600,
                },
            };

            modelBuilder.Entity<Cargo>().HasData(cargos);

            var orders = new Guid[]
            {
                Guid.Parse("22A11DAA-7534-4D0F-AB6B-766A4AC855F0"),
                Guid.Parse("BB3D699A-381C-49DB-A97F-A87CC55D7325"),
                Guid.Parse("EEF68D46-5959-422F-B782-09722C4D483F"),
                Guid.Parse("D51B4B9E-0E70-4E9C-82C1-C96C69C1C769"),
            }
                .Select((id, index) => new
                {
                    Id = id,
                    CreatedAt = new DateTime(2025, 7, 10 + index, 10 + index, 20 + index, 0).ToUniversalTime(),
                    PickupTime = new DateTime(2025, 7, 24 + index, 17 + index, 40 + index, 0).ToUniversalTime(),
                    PickupAddress = $"Адрес погрузки {index}",
                    DeliveryAddress = $"Адрес выгрузки {index}",
                    ClientId = clients.ElementAt(index).Id,
                    CourierId = couriers.ElementAt(index).Id,
                    CargoId = cargos.ElementAt(index).Id,
                    Status = OrderStatus.GetAllStatuses().ElementAt(index),
                    CancelComment = OrderStatus.GetAllStatuses().ElementAt(index) == OrderStatus.Canceled ? "Тест" : null,
                });

            modelBuilder.Entity<Order>().HasData(orders);
        }
    }
}
