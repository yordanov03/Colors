using CarRentalSystem.Domain.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts
{
    //restrict the access of the non-domain layers to aggregate roots only. It serves as an anti-corruption layer to our domain
    public interface IRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
        Task Save(TEntity entity, CancellationToken cancellationToken = default);
    }
}
