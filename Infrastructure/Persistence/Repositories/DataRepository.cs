using Application.Contracts;
using Colors.Domain.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    internal abstract class DataRepository<TEntity>
        : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        protected DataRepository(PeopleAndColorsDbContext db) => this.Data = db;

        protected PeopleAndColorsDbContext Data { get; }

        public async Task Save(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            this.Data.Update(entity);

            await this.Data.SaveChangesAsync(cancellationToken);
        }
    }
}
