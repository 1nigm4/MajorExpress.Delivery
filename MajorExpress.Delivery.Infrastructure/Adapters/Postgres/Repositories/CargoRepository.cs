namespace MajorExpress.Delivery.Infrastructure.Adapters.Postgres.Repositories
{
    using MajorExpress.Delivery.Domain.Models;
    using MajorExpress.Delivery.Domain.Repositories;

    public class CargoRepository : Repository<Cargo>, ICargoRepository
    {
        public CargoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
