using Application.Contracts;
using CarRentalSystem.Domain.Common;

namespace Infrastructure.Persistence.Repositories
{
    internal abstract class DataRepository<TEntity> 
        //: IRepository<TEntity>
        //where TEntity : class, IAggregateRoot
    {
        //protected DataRepository(CarRentalDbContext db) => this.Data = db;

        //protected CarRentalDbContext Data { get; }

        //protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        //public async Task Save(
        //    TEntity entity,
        //    CancellationToken cancellationToken = default)
        //{
        //    this.Data.Update(entity);

        //    await this.Data.SaveChangesAsync(cancellationToken);
        //}
    }
}
