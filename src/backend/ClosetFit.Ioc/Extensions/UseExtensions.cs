namespace ClosetFit.Ioc.Extensions;
public static class UseExtensions
{
    public static void UseArchitecture(this WebApplication app)
    {
        app.UseCorsDI();
        app.UseHttpsRedirection();
        app.UseSwaggerDI();
        app.MapControllers();
        app.Run();
    }
}
