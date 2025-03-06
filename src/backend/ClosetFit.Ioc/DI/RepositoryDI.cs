namespace ClosetFit.Ioc.DI;
public static class RepositoryDI
{
    public static void AddRepositoryDI(this IServiceCollection services)
    {
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
    }
}
