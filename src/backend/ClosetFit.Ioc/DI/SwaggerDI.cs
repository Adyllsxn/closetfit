namespace ClosetFit.Ioc.DI;
public static class SwaggerDI
{
    public static void AddSwaggerDI(this IServiceCollection services)
    {
        services.AddSwaggerGen();
    }

    public static void UseSwaggerDI(this WebApplication app)
    {
        if(app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerDI();
        }
    }
}
