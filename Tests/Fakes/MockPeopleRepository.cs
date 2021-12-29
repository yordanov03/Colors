using Application.Features.People;
using Application.Features.People.Queries.Common;
using FakeItEasy;
using Moq;
using System.Collections.Generic;
using System.Threading;

namespace Tests.Fakes
{
    public static class MockPeopleRepository
    {
        public static Mock<IPeopleRepository> GetPeopleRepository()
        {
            var person = A.Dummy<PersonOutputModel>();
            var people = new List<PersonOutputModel>();
            people.Add(person);
            people.Add(person);

            var mockRepo = new Mock<IPeopleRepository>();

            mockRepo.Setup(r => r.GetAllPeople(CancellationToken.None)).ReturnsAsync(people);

            mockRepo.Setup(r => r.GerPersonById(It.IsAny<int>(), CancellationToken.None)).ReturnsAsync(person);

            mockRepo.Setup(r => r.GetPeopleByColor(It.IsAny<int>(), CancellationToken.None)).ReturnsAsync(people);

            return mockRepo;
        }
    }
}
