using Application.Features.Colors;
using Domain.Factories.PersonFactory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.People.Commands.Create
{
    public class CreatePersonCommand : IRequest<CreatePersonOutputModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Color { get; set; }

        public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, CreatePersonOutputModel>
        {
            private readonly IPersonFactory _personFactory;
            private readonly IPeopleRepository _peopleRepository;
            private readonly IColorsRepository _colorsRepository;

            public CreatePersonCommandHandler(
                IPersonFactory personFactory,
                IPeopleRepository peopleRepository,
                IColorsRepository colorsRepository)
            {
                this._personFactory = personFactory;
                this._peopleRepository = peopleRepository;
                this._colorsRepository = colorsRepository;
            }
            public async Task<CreatePersonOutputModel> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
            {
                var color = await this._colorsRepository.GetColorByName(request.Color, cancellationToken);
                var person = this._personFactory
                    .WithFirstName(request.FirstName)
                    .WithLastName(request.LastName)
                    .WithZipcode(request.Zipcode)
                    .WithCity(request.City)
                    .WithColorId(color.Id)
                    .Build();

                await this._peopleRepository.Save(person);
                return new CreatePersonOutputModel(person.Id);
            }
        }
    }
}
