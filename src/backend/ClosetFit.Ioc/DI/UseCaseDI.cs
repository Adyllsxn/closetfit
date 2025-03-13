namespace ClosetFit.Ioc.DI;
public static class UseCaseDI
{
    public static void AddUseCaseDI(this IServiceCollection services)
    {
        #region </Categoria>
            services.AddScoped<CreateCategoriaUseCase>();
            services.AddScoped<DeleteCategoriaUseCase>();
            services.AddScoped<GetCategoriaUseCase>();
            services.AddScoped<GetCategoriaByIdUseCase>();
            services.AddScoped<SearchCategoriaUseCase>();
            services.AddScoped<UpdateCategoriaUseCase>();
        #endregion

    }
}
