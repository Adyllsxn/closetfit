namespace ClosetFit.Domain.Entities
{
    public sealed class ProdutoEntity : EntityBase, IAgragateRoot
    {
        public string Nome { get; private set; } = null!;
        public string Descricao { get; private set; } = null!;
        public int Preco { get; private set; }
        public int CategoriaId { get; private set; }
        public string Imagem { get; private set; } = null!;

        [JsonIgnore]
        public ProdutoEntity Produto { get; private set; } = null!;

        [JsonConstructor]
        public ProdutoEntity(){}
        public ProdutoEntity(int id, string nome, string descricao, int preco, int categoriaId, string imagem)
        {
            DomainExceptionValidation.When(id <=0, "ID do produto deve ser maior que zero");
            Id = id;
            ValidationDomain(nome, descricao, preco, categoriaId, imagem);
        }
        public ProdutoEntity(string nome, string descricao, int preco, int categoriaId, string imagem)
        {
            ValidationDomain(nome, descricao, preco, categoriaId, imagem);
        }
        public void Update(string nome, string descricao, int preco, int categoriaId, string imagem)
        {
            ValidationDomain(nome, descricao, preco, categoriaId, imagem);
        }
        public void ValidationDomain(string nome, string descricao, int preco, int categoriaId, string imagem)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(nome), "Nome é obrigatório.");
            DomainExceptionValidation.When(nome.Length >= 50, "Nome deve ter menos de 50 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(descricao), "Descrição é obrigatório");
            DomainExceptionValidation.When(descricao.Length >= 100, "Descrição deve ter menos de 100 caracteres.");

            DomainExceptionValidation.When(preco <=0, "Preço é obrigatório.");

            DomainExceptionValidation.When(categoriaId <=0 , "Categoria é obrigatório.");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(imagem), "Imagem é obrigatório.");

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            CategoriaId = categoriaId;
            Imagem = imagem;
        }
    }
}