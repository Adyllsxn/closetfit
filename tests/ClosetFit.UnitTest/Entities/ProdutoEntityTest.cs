namespace ClosetFit.UnitTest.Entities;
public class ProdutoEntityTest
{
    #region </Constants>
        private const int InvalidNumberZero = 0;
        private const int InvalidNumber = -1;
        private const string ValidName = "Test";
        private const string ValidDescricao = "Test";
        private const int ValidPreco = 112;
        private const int ValidCategoria = 1;
        private const string ValidImagem = "Test";
    #endregion
    
    #region </Id>
        [Theory]
        [InlineData(InvalidNumber, ValidName, ValidDescricao, ValidPreco, ValidCategoria, ValidImagem)]
        [InlineData(InvalidNumberZero, ValidName, ValidDescricao, ValidPreco, ValidCategoria, ValidImagem)]
        public void ShoudFailIfIdIsNegative(int id, string nome, string descricao, int preco, int categoriaId, string imagem)
        {
            Assert.True(true);
            Assert.Throws<DomainExceptionValidation>(()=>{
                new ProdutoEntity(id,nome,descricao,preco,categoriaId,imagem);
            });
        }
    #endregion
    
    #region </ProdutoNome>
        [Theory]
        [InlineData(null, ValidDescricao, ValidPreco, ValidCategoria, ValidImagem)]
        [InlineData("", ValidDescricao, ValidPreco, ValidCategoria, ValidImagem)]
        [InlineData(" ", ValidDescricao, ValidPreco, ValidCategoria, ValidImagem)]
        public void ShoudFailIfNomeIsNullEmptyOrSpace(string nome, string descricao, int preco, int categoriaId, string imagem)
        {
            Assert.True(true);
            Assert.Throws<DomainExceptionValidation>(()=>{
                new ProdutoEntity(nome, descricao, preco, categoriaId, imagem);
            });
        }
    #endregion

    #region </Descricao
        [Theory]
        [InlineData(ValidName, null, ValidPreco, ValidCategoria, ValidImagem)]
        [InlineData(ValidName, "", ValidPreco, ValidCategoria, ValidImagem)]
        [InlineData(ValidName, " ", ValidPreco, ValidCategoria, ValidImagem)]
        public void ShouldFailIfDescricaoIsNullEmptyOrSpace(string nome, string descricao, int preco, int categoriaId, string imagem)
        {
            Assert.True(true);
            Assert.Throws<DomainExceptionValidation>(()=>{
                new ProdutoEntity(nome, descricao, preco, categoriaId, imagem);
            });
        }
    #endregion

    #region </Preco>
        [Theory]
        [InlineData(ValidName, ValidDescricao, InvalidNumber, ValidCategoria, ValidImagem)]
        [InlineData(ValidName, ValidDescricao, InvalidNumberZero, ValidCategoria, ValidImagem)]
        public void ShouldFailIfPrecoIsNullOrNegative(string nome, string descricao, int preco, int categoriaId, string imagem)
        {
            Assert.True(true);
            Assert.Throws<DomainExceptionValidation>(()=>
            {
                new ProdutoEntity(nome, descricao, preco, categoriaId, imagem);
            });
        }

    #endregion

    #region </CategoriaId>
        [Theory]
        [InlineData(ValidName, ValidDescricao, ValidPreco, InvalidNumber, ValidImagem)]
        [InlineData(ValidName, ValidDescricao, ValidPreco, InvalidNumberZero, ValidImagem)]
        public void ShouldFailIfCategoriaIdIsNullOrNegative(string nome, string descricao, int preco, int categoriaId, string imagem)
        {
            Assert.True(true);
            Assert.Throws<DomainExceptionValidation>(()=> {
                new ProdutoEntity(nome, descricao, preco, categoriaId, imagem);
            });
        }
    #endregion

    #region </Imagem>
        [Theory]
        [InlineData(ValidName, ValidDescricao, ValidPreco, ValidCategoria, null)]
        [InlineData(ValidName, ValidDescricao, ValidPreco, ValidCategoria, "")]
        [InlineData(ValidName, ValidDescricao, ValidPreco, ValidCategoria, " ")]
        public void ShouldFailIfImagemIsNullEmptyOrSpace(string nome, string descricao, int preco, int categoriaId, string imagem)
        {
            Assert.True(true);
            Assert.Throws<DomainExceptionValidation>(()=>{
                new ProdutoEntity(nome, descricao, preco, categoriaId, imagem);
            });
        }
    #endregion

    #region </LongLenght>
        [Fact]
        public void ShouldFailIfIsHaveLongLenght()
        {
            var LongLenght = new string('B', 206);
            Assert.True(true); 
            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var acount = new ProdutoEntity(LongLenght, LongLenght, ValidPreco, ValidCategoria, ValidImagem);
            });
        }
    #endregion 

    #region </Criar>
        [Theory]
        [InlineData(ValidName, ValidDescricao, ValidPreco ,ValidCategoria, ValidImagem)]
        public void ShouldCreate(string nome, string descricao, int preco, int categoriaId, string imagem)
        {
            var count = new ProdutoEntity(nome, descricao, preco, categoriaId, imagem);
            Assert.NotNull(count);
        }
    #endregion

    #region </Editar>
        [Theory]
        [InlineData(ValidName, ValidDescricao, ValidPreco ,ValidCategoria, ValidImagem)]
        public void ShouldEdit(string nome, string descricao, int preco, int categoriaId, string imagem)
        {
            var count = new ProdutoEntity(nome, descricao, preco, categoriaId, imagem);
            count.Update("test", "test", 2, 2, "test");
            Assert.Equal("test", count.Nome);
            Assert.Equal("test", count.Descricao);
            Assert.Equal(2, count.Preco);
            Assert.Equal(2, count.CategoriaId);
            Assert.Equal("test", count.Imagem);
        }
    #endregion

}
