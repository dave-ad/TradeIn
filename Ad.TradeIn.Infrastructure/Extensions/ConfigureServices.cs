namespace Ad.TradeIn.Infrastructure.Extensions;

public static class ConfigureServices
{
    //public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    //{
    //    if (configuration.GetValue<bool>("UseInMemoryDatabase"))
    //    {
    //        services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("TradeIn"));
    //    }
    //    else
    //    {
    //        services.AddDbContext<ApplicationDbContext>(options => options
    //        //.UseLazyLoadingProxies()
    //        .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
    //                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
    //    }

    //    services.AddDefaultIdentity<ApplicationUser>()
    //    .AddEntityFrameworkStores<ApplicationDbContext>();

    //    services.AddIdentityServer()
    //        .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

    //}
}
