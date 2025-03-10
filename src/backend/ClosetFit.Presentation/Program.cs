var builder = WebApplication.CreateBuilder(args);
    builder.AddInfrastructureExtensions();
var app = builder.Build();
    app.UseInfrastructureExtensions();
