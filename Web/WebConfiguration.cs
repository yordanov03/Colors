using Colors.Application.Common;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Web
{
    public static class WebConfiguration
    {
        public static IServiceCollection AddWebComponents(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddFluentValidation(validation => validation
                    .RegisterValidatorsFromAssemblyContaining<Result>())
                .AddNewtonsoftJson();

            return services;
        }
    }
}
