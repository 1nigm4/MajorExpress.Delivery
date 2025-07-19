namespace MajorExpress.Delivery.Infrastructure.Adapters.Postgres.Repositories
{
    using MajorExpress.Delivery.Domain.Models;
    using MajorExpress.Delivery.Domain.Repositories;

    public class CourierRepository : Repository<Courier>, ICourierRepository
    {
        public CourierRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
