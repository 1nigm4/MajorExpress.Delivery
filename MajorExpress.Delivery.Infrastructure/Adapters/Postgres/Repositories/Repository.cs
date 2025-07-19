namespace MajorExpress.Delivery.Infrastructure.Adapters.Postgres.Repositories
{
    using System.Linq.Expressions;
    using MajorExpress.Delivery.Domain.Models;
    using MajorExpress.Delivery.Domain.Repositories;
    using Microsoft.EntityFrameworkCore;

    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected ApplicationDbContext Context { get; }

        protected Repository(ApplicationDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task RemoveAsync(TEntity entity)
        {
            this.Context.Remove(entity);
            return Task.CompletedTask;
        }

        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = this.Context.Set<TEntity>()
                .AsQueryable();

            if (includes.Length > 0)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }

        public async Task<TEntity?> GetAsync(Guid id, CancellationToken ct = default, params Expression<Func<TEntity, object>>[] includes)
        {
            return await this.GetAll(includes)
                .FirstOrDefaultAsync(e => e.Id == id, ct);
        }

        public async Task CreateAsync(TEntity entity, CancellationToken ct = default)
        {
            await this.Context.AddAsync(entity, ct);
        }

        public Task UpdateAsync(TEntity entity)
        {
            this.Context.Update(entity);
            return Task.CompletedTask;
        }
    }
}
