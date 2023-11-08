using Ad.TradeIn.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ad.TradeIn.Infrastructure.Extensions;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //  Dependency Injectin of DbContext Class
        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<APIDbContext>(options => options.UseInMemoryDatabase(InmemoryCache.TradeIn.ToString()));
        }
        else
        {
            //  Dependency Injectin of DbContext Class
            //builder.Services.AddDbContext<APIDbContext>(
            //    Options => Options
            //    .UseSqlServer(builder.Configuration
            //    .GetConnectionString("DevConnection")));

            services.AddDbContext<APIDbContext>(
                options => options
            //.UseLazyLoadingProxies()
            .UseSqlServer(configuration
            .GetConnectionString("DevConnection"),
                    b => b
                    .MigrationsAssembly(typeof(APIDbContext).Assembly.FullName)));
        }

        //services.AddScoped<IMediator, Mediator>();
        services.AddScoped<IUserRepository, UserRepository>();

        //services.AddMediatR(typeof(CreateUserCommand));
        services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return null;

    }
}
