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
        private readonly List<Color> colors;

        public PeopleRepository(
            PeopleAndColorsDbContext db, 
            IMapper mapper) : base(db)
        {
            this._mapper = mapper;
            this.colors = this.Data.Colors.ToList();
        }


        public async Task<PersonOutputModel> GerPersonById(int id, CancellationToken cancellationToken)
        {
            var person = await this.Data.People.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            var personWithColor = GetColorById(person);
            return personWithColor;
        }

        public async Task<IEnumerable<PersonOutputModel>> GetAllPeople(CancellationToken cancellationToken)
        {
            var people = await this.Data.People.ToListAsync(cancellationToken);
            return MatchPeopleWithColors(people);
        }


        public async Task<IEnumerable<PersonOutputModel>> GetPeopleByColor(int colorId, CancellationToken cancellationToken)
        {
            var people = await this.Data.People.Where(p => p.ColorId == colorId).ToListAsync(cancellationToken);
            return MatchPeopleWithColors(people);
        }

        public PersonOutputModel GetColorById(Person person)
        {
            var color = this.colors.FirstOrDefault(c => c.Id == person.ColorId);
            var personOutput = this._mapper.Map<Person, PersonOutputModel>(person);
            personOutput.Color = color.Name;

            return personOutput;
        }
        public IEnumerable<PersonOutputModel> MatchPeopleWithColors(List<Person> people)
        {
            var peopleWithColors = new List<PersonOutputModel>();

            foreach (var person in people)
            {
                peopleWithColors.Add(GetColorById(person));
            }

            return peopleWithColors;
        }
    }
}
