using Application.Contracts;
using Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.People
{
    public interface IPeopleRepository : IRepository<Person>
    {
        Task<List<Person>> GetAllPeople(CancellationToken cancellationToken);
        Task<Person> GerPersonById(int id, CancellationToken cancellationToken);
        Task<List<Person>> GetPeopleByColor(int colorId, CancellationToken cancellationToken);
    }
}
