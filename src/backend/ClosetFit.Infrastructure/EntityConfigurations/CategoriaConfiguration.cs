namespace ClosetFit.Infrastructure.EntityConfigurations;
public class CategoriaConfiguration : IEntityTypeConfiguration<CategoriaEntity>
{
    public void Configure(EntityTypeBuilder<CategoriaEntity> builder)
    {
        builder.ToTable("Tbl_Categoria");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome).
                IsRequired(true).
                HasColumnType("Varchar").
                HasMaxLength(50);
        
        builder.HasData(
            new CategoriaEntity(1, "Calçado"),
            new CategoriaEntity(2, "Chinela")
        );
    }
}
