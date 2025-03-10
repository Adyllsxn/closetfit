namespace ClosetFit.Presentation.Infrastructures.Extensions;
public static class AppExtensions
{
    public static void UseInfrastructureExtensions(this WebApplication app)
    {
        app.UseArchitecture();
    }
}
