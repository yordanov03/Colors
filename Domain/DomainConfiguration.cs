using Colors.Domain.Factories;
using Domain.Common;
using Domain.Factories.PersonFactory;
using Domain.InitialData;
using Domain.Models.Common;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
namespace Colors.Domain
{
    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IFactory<>)))
                    .AsMatchingInterface()
                    .WithTransientLifetime())
            .AddTransient<IPeopleDataParser, PeopleDataParser>()
            .AddTransient<IInitialData, ColorData>()
            .AddTransient<IInitialData, PersonData>();
    }
}
