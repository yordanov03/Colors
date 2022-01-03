using Application.Contracts;
using Colors.Domain.Common;
<<<<<<< HEAD
using System.Linq;
=======
>>>>>>> development
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

<<<<<<< HEAD
        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        public async Task Save(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            this.Data.Update(entity);

=======
        public async Task Save(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            this.Data.Update(entity);

>>>>>>> development
            await this.Data.SaveChangesAsync(cancellationToken);
        }
    }
}
