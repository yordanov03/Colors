using Application.Features.People.Queries.Common;
using Application.Features.People.Queries.GetAllPeople;
using MediatR;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Specs
{
    public class PeopleControllerSpecs
    {
        [Fact]
        public async Task ControllerShouldReturnCollectionOfPersonOutputModel()
        {
            //Arrange
            var fakeMediator = new Mock<IMediator>();
            var query = new GetAllPeopleQuery();

            //Act
            var result = await fakeMediator.Object.Send(query);

            //Assert
            Assert.IsType<PersonOutputModel[]>(result);
            fakeMediator.Verify(x => x.Send(It.IsAny<GetAllPeopleQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

    }
}
