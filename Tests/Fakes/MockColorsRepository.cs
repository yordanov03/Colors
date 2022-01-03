using Application.Features.Colors;
using Domain.Models;
using FakeItEasy;
using Moq;
using System.Collections.Generic;
using System.Threading;

namespace Tests.Fakes
{
    public static class MockColorsRepository
    {
        public static Mock<IColorsRepository> GetColorsrepository()
        {
            var color = A.Dummy<Color>();
            var colors = new List<Color> { color, color };

            var mockRepo = new Mock<IColorsRepository>();

            mockRepo.Setup(r => r.GetAllColors(CancellationToken.None)).ReturnsAsync(colors);

            mockRepo.Setup(r => r.GetColorByName(It.IsAny<string>(), CancellationToken.None)).ReturnsAsync(color);

            return mockRepo;
        }
    }
}
