using Application.Features.People.Queries.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.People.Queries.GetPersonById
{
    public class GetPersonByIdQuery : IRequest<PersonOutputModel>
    {
        public int Id { get; set; }

        public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonOutputModel>
        {
            private readonly IPeopleRepository _peoplerepository;

            public GetPersonByIdQueryHandler(IPeopleRepository peoplerepository)
            {
                this._peoplerepository = peoplerepository;
            }
            public Task<PersonOutputModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
            => this._peoplerepository.GerPersonById(request.Id, cancellationToken);
        }
    }
}
