namespace ClosetFit.Ioc.DI;
public static class AutoMapperDI
{
    public static void AddAutoMapperDI(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
