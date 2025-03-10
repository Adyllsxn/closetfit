namespace ClosetFit.Presentation.Infrastructures.Extensions;
public static class BuildExtensions
{
    public static void AddInfrastructureExtensions(this WebApplicationBuilder builder)
    {
        builder.AddArchitectureExtensions();
    }
}