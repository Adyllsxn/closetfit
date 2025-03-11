namespace ClosetFit.Ioc.Extensions;
public static class BuilderExtensions
{
    public static void AddArchitectureExtensions(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerDI();
        builder.Services.AddDbContextDI(builder.Configuration);
        builder.Services.AddCorsDI();
        builder.Services.AddRepositoryDI();
        builder.Services.AddServiceDI();
        builder.Services.AddUseCaseDI();
        builder.Services.AddAutoMapperDI();
    }
}
