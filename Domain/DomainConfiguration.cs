using Colors.Domain.Factories;
using Domain.Common;
using Domain.InitialData;
using Domain.Models;
using Domain.Models.Common;
using Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Colors.Domain
{
    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration)
            => services
            .Configure<FileLocation>(
                    configuration.GetSection(nameof(FileLocation)),
                    options => options.BindNonPublicProperties = true)
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
