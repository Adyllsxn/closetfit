namespace ClosetFit.Ioc.DI;
public static class ServiceDI
{
    public static void AddServiceDI(this IServiceCollection services)
    {
        services.AddScoped<ICategoriaService, CategoriaService>();
    }
}
