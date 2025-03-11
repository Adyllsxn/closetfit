namespace ClosetFit.Ioc.DI;
public static class DbContextDI
{
    public static void AddDbContextDI(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionsDb = configuration.GetConnectionString(ConnectionStringContext.ConnectionString);
        services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(connectionsDb, m => m.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
    }
}
