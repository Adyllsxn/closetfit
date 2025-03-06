namespace ClosetFit.Infrastructure.Context;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<CategoriaEntity> Categorias { get; set; } = null!;
    public DbSet<ProdutoEntity> Produtos { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}
