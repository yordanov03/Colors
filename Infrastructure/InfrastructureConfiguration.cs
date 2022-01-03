using Application.Contracts;
using Colors.Infrastructure;
using Colors.Infrastructure.Persistence;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
<<<<<<< HEAD
using Serilog;
using Serilog.Core;
=======
>>>>>>> development
using System.Reflection;

namespace Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
<<<<<<< HEAD
            .AddSingleton<ILogger>(
                Log.Logger =
                AddLoggerConfiguration(configuration))
=======
>>>>>>> development
                .AddDatabase(configuration)
                .AddRepositories()
            .AddAutoMapper(Assembly.GetExecutingAssembly());

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<PeopleAndColorsDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer
                            .MigrationsAssembly(typeof(PeopleAndColorsDbContext)
                                .Assembly.FullName)))
                .AddTransient<IInitializer, PeopleAndColorsDbInitializer>();

        internal static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IRepository<>)))
                    .AsMatchingInterface()
                    .WithTransientLifetime());
<<<<<<< HEAD

        internal static ILogger AddLoggerConfiguration(IConfiguration configuration)
            => new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
=======
>>>>>>> development
    }
}
