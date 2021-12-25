using Application.Features.Colors;
using Application.Features.People.Queries.Common;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.People.Queries.GetAllPeople
{
    public class GetAllPeopleQuery : IRequest<IEnumerable<PersonOutputModel>>
    {
        public class GetAllPeopleQueryHandler : IRequestHandler<GetAllPeopleQuery, IEnumerable<PersonOutputModel>>
        {
            private readonly IPeopleRepository _peopleRepository;
            private readonly IColorsRepository _colorsRepository;

            public GetAllPeopleQueryHandler(
                IPeopleRepository peopleRepository,
                IColorsRepository colorsRepository)
            {
                this._peopleRepository = peopleRepository;
                this._colorsRepository = colorsRepository;
            }
            public async Task<IEnumerable<PersonOutputModel>> Handle(GetAllPeopleQuery request, CancellationToken cancellationToken)
            {
                var people = await this._peopleRepository.GetAllPeople(cancellationToken);
                return people;
            }
        }
    }
}
