using Application.Features.Colors;
using Application.Features.People;
using Application.Features.People.Queries.Common;
using Application.Features.People.Queries.GetAllPeople;
using Application.Features.People.Queries.GetPeopleByColor;
using Application.Features.People.Queries.GetPersonById;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Tests.Fakes;
using Xunit;
using static Application.Features.People.Queries.GetAllPeople.GetAllPeopleQuery;
using static Application.Features.People.Queries.GetPeopleByColor.GetPeopleByColorQuery;
using static Application.Features.People.Queries.GetPersonById.GetPersonByIdQuery;

namespace Tests.Specs
{
    public class Handlers
    {
        private readonly Mock<IPeopleRepository> _peopleRepository;
        private readonly Mock<IColorsRepository> _colorsRepository;

        public Handlers()
        {
            _peopleRepository = MockPeopleRepository.GetPeopleRepository();
            _colorsRepository = MockColorsRepository.GetColorsrepository();
        }
        [Fact]
        public async Task GetAllPeopleSHouldReturnCollectionOfOutputModels()
        {
            //Arrange
            var handler = new GetAllPeopleQueryHandler(
                _peopleRepository.Object, _colorsRepository.Object);

            //Act
            var result = await handler.Handle(new GetAllPeopleQuery(), CancellationToken.None);

            //Assert
            result.Should().BeOfType<List<PersonOutputModel>>();
            result.Count().Should().Be(2);
        }

        [Fact]
        public async Task GetPersonByColorShouldReturnTwoPeople()
        {
            //Arrange
            var handler = new GetPeopleByColorQueryHandler(
                _peopleRepository.Object, _colorsRepository.Object);

            //Act
            var result =  await handler.Handle(new GetPeopleByColorQuery(), CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(2);
        }

        [Fact]
        public async Task GetPersonByIdShouldReturnPerson()
        {
            //Arrange
            var handler = new GetPersonByIdQueryHandler(_peopleRepository.Object);

            //Act
            var result = await handler.Handle(new GetPersonByIdQuery(), CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().BeOfType<PersonOutputModel>();
        }
    }
}
