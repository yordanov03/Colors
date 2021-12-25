using Application.Features.People;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    internal class PeopleRepository : IPeopleRepository
    {
        private readonly PeopleAndColorsDbContext _db;

        public PeopleRepository(PeopleAndColorsDbContext db)
        {
            this._db = db;
        }

        public async Task<Person> GerPersonById(int id, CancellationToken cancellationToken)
        => await this._db.People.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        public async Task<List<Person>> GetAllPeople(CancellationToken cancellationToken)
        => await this._db.People.ToListAsync(cancellationToken);

        public async Task<List<Person>> GetPeopleByColor(int colorId, CancellationToken cancellationToken)
        => await this._db.People.Where(p => p.ColorId == colorId).ToListAsync(cancellationToken);

        public async Task Save(Person person, CancellationToken cancellationToken)
        {
            await this._db.People.AddAsync(person, cancellationToken);
            await this._db.SaveChangesAsync(cancellationToken);
        }
    }
}
