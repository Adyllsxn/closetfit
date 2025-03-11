namespace ClosetFit.Ioc.DI;
public static class CorsDI
{
    public static void AddCorsDI(this IServiceCollection services)
    {
        services.AddCors(
            x => x.AddPolicy(
                ConfigurationUrl.CorsPolicyName,
                policy => policy.
                        WithOrigins([ConfigurationUrl.BackendUrl, ConfigurationUrl.FrontendUrl]).
                        AllowAnyHeader().
                        AllowAnyMethod().
                        AllowCredentials()
            )
        );
    }
    public static void UseCorsDI (this WebApplication app)
    {
        app.UseCors(ConfigurationUrl.CorsPolicyName);
    }
}
