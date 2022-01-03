using Application.Features.Colors;
using Application.Features.People.Queries.Common;
using Colors.Application.Exceptions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.People.Queries.GetPeopleByColor
{
    public class GetPeopleByColorQuery : IRequest<IEnumerable<PersonOutputModel>>
    {
        public string Color { get; set; }

        public class GetPeopleByColorQueryHandler : IRequestHandler<GetPeopleByColorQuery, IEnumerable<PersonOutputModel>>
        {
            private readonly IPeopleRepository _peopleRepository;
            private readonly IColorsRepository _colorsRepository;

            public GetPeopleByColorQueryHandler(
                IPeopleRepository peopleRepository,
                IColorsRepository colorsRepository)
            {
                this._peopleRepository = peopleRepository;
                this._colorsRepository = colorsRepository;
            }
            public async Task<IEnumerable<PersonOutputModel>> Handle(GetPeopleByColorQuery request, CancellationToken cancellationToken)
            {
                var color = await this._colorsRepository.GetColorByName(request.Color, cancellationToken);
                return await this._peopleRepository.GetPeopleByColor(color.Id, cancellationToken);
            }
        }
    }
}
