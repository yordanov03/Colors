﻿using Colors.Domain.Factories;
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
/*                .AddTransient<IInitialData, CategoryData>()*/;
    }
}
