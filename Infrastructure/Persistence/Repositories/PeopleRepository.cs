using Application.Features.Colors;
using Application.Features.People;
using Application.Features.People.Queries.Common;
using AutoMapper;
using Colors.Application.Exceptions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    internal class PeopleRepository : DataRepository<Person>, IPeopleRepository
    {
        private readonly IColorsRepository _colorsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PeopleRepository> _logger;

        public PeopleRepository(
            PeopleAndColorsDbContext db,
            IColorsRepository colorsRepository,
            IMapper mapper,
            ILogger<PeopleRepository> logger) : base(db)
        {
            this._colorsRepository = colorsRepository;
            this._mapper = mapper;
            this._logger = logger;
        }

        public async Task<PersonOutputModel> GerPersonById(int id, CancellationToken cancellationToken)
        {
            var person = await this.Data.People.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            if(person == null)
            {
                this._logger.LogError($"Person with id {id} does not exist");
                throw new NotFoundException("person with id", id );
            }
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
            var color = this._colorsRepository.GetColorById(person.ColorId, CancellationToken.None);
            var personOutput = this._mapper.Map<Person, PersonOutputModel>(person);
            personOutput.Color = color.Result.Name;

            this._logger.LogDebug("Mapping to output model is done");
            return personOutput;
        }
        public IEnumerable<PersonOutputModel> MatchPeopleWithColors(List<Person> people)
        {
            var peopleWithColors = new List<PersonOutputModel>();

            foreach (var person in people)
            {
                peopleWithColors.Add(GetColorById(person));
            }

            this._logger.LogDebug("Successfully matched people with existent colors");
            return peopleWithColors;
        }
    }
}
