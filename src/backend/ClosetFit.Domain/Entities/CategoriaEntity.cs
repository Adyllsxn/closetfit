namespace ClosetFit.Domain.Entities;
public sealed class CategoriaEntity : EntityBase, IAgragateRoot
{
    public string Nome { get; private set; } = null!;

    [JsonIgnore]
    public ICollection<CategoriaEntity> Categorias { get; private set; } = new List<CategoriaEntity>();
    public CategoriaEntity(){}
    public CategoriaEntity(int id, string nome)
    {
        DomainExceptionValidation.When(id <= 0, "ID da categoria deve ser maior que zero.");
        Id = id;
        ValidationDomain(nome);
    }
    public CategoriaEntity(string nome)
    {
        ValidationDomain(nome);
    }
    public void Update(string nome)
    {
        ValidationDomain(nome);
    }
    public void ValidationDomain(string nome)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(nome), "Nome da categoria é obrigatório.");
        DomainExceptionValidation.When(nome.Length >= 50, "Nome da categoria deve ser menor de 50 caracteres.");
        Nome = nome;
    }
}
