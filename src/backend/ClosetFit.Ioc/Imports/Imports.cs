#region </Microsoft>
    global using Microsoft.Extensions.DependencyInjection;
    global using Microsoft.AspNetCore.Builder;
    global using Microsoft.EntityFrameworkCore;
    global using Microsoft.Extensions.Configuration;
    global using Microsoft.Extensions.Hosting;
#endregion

#region </Domain>
    global using ClosetFit.Domain.Interfaces;
#endregion

#region </Infrastructure>
    global using ClosetFit.Infrastructure.Repositories;
    global using ClosetFit.Infrastructure.Context;
#endregion

#region </Ioc>
    global using ClosetFit.Ioc.Configurations;
    global using ClosetFit.Ioc.DI;
#endregion