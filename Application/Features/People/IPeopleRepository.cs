using Application.Contracts;
using Application.Features.People.Queries.Common;
using Domain.Models;
using System.Collections.Generic;
using System.Threading;

namespace Application.Features.People
{
    public interface IPeopleRepository : IRepository<Person>
    {
        IEnumerable<PersonOutputModel> GetAllPeople(CancellationToken cancellationToken);
        PersonOutputModel GerPersonById(int id, CancellationToken cancellationToken);
        IEnumerable<PersonOutputModel> GetPeopleByColor(int colorId, CancellationToken cancellationToken);
    }
}
