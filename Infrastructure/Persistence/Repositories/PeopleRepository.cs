using Application.Features.People;
using Application.Features.People.Queries.Common;
using AutoMapper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    internal class PeopleRepository : DataRepository<Person>, IPeopleRepository
    {
        private readonly IMapper _mapper;

        public PeopleRepository(PeopleAndColorsDbContext db, IMapper mapper) : base(db)
        => this._mapper = mapper;


        public async Task<Person> GerPersonById(int id, CancellationToken cancellationToken)
        => await this.Data.People.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        public async Task<IEnumerable<PersonOutputModel>> GetAllPeople(CancellationToken cancellationToken)
        => await this._mapper.ProjectTo<PersonOutputModel>(this.Data.People).ToListAsync(cancellationToken);

        public async Task<IEnumerable<PersonOutputModel>> GetPeopleByColor(int colorId, CancellationToken cancellationToken)
        => await this._mapper
            .ProjectTo<PersonOutputModel>
            (this.Data.People.Where(p=>p.ColorId == colorId))
            .ToListAsync(cancellationToken);
    }
}
