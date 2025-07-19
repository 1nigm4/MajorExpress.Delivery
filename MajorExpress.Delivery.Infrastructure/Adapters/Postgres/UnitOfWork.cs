namespace MajorExpress.Delivery.Infrastructure.Adapters.Postgres
{
    using System.Threading;
    using System.Threading.Tasks;
    using MajorExpress.Delivery.Domain;

    /// <summary>
    ///     <inheritdoc cref="IUnitOfWork"/>
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct)
        {
            return await _context.SaveChangesAsync(ct);
        }
    }
}
