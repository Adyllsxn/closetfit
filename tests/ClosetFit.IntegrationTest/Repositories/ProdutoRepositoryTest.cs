using ClosetFit.Domain.Pagination;

namespace ClosetFit.IntegrationTest.Repositories;
public class ProdutoRepositoryTest
{
    #region </Configuration>
        
        private readonly AppDbContext _context;
        private readonly ProdutoRepository _repository;
        public ProdutoRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().
                        UseInMemoryDatabase(databaseName: "TestDatabase").
                        Options;
            _context = new AppDbContext(options);
            _repository = new ProdutoRepository(_context);
        }
        
    #endregion

    #region </Create>
        [Fact]
        public async Task CreateAsync_ShouldCreateProduto()
        {
            var produto = new ProdutoEntity("Ar Force", "Tenis da Nike", 2000, 1, "nike.png");

            var response = await _repository.CreateAsync(produto);

            Assert.NotNull(response);
            Assert.True(response.IsSuccess);
            Assert.Equal(201, response._Code);
            Assert.Equal("Produto criado.",response.Message);
        }
    #endregion

    #region </GetById>
        [Fact]
        public async Task GetById_ShouldGetProdutoById()
        {
            var produto = new ProdutoEntity("Ar Force", "Tenis da Nike", 2000, 1, "nike.png");
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            var response = await _repository.GetByIdAsync(produto.Id);

            Assert.NotNull(response);
            Assert.True(response.IsSuccess);
            Assert.Equal(200, response._Code);
            Assert.Equal("Produto com ID "+produto.Id+", encontrado.",response.Message);
        }
    #endregion

    #region </GetAll>
        [Fact]
        public async Task GetAllAsyn_ShouldGetAllProduto()
        {
            _context.Produtos.AddRange(
                new ProdutoEntity("Ar Force", "Tenis da Nike", 2000, 1, "nike.png"),
                new ProdutoEntity("Ar Force 1", "Tenis da Nike", 2000, 1, "nike.png")
            );
            await _context.SaveChangesAsync();

            PagedRequest request = new PagedRequest{
                pageNumber = 1,
                pageSize = 10,
            };
            var response = _repository.GetAllAsync(request);

            Assert.NotNull(response);
            Assert.True(response.IsCompleted);

        }
    #endregion

    #region <GetFile>
        [Fact]
        public async Task GetFile_ShouldGetAllFiles()
        {
            var produto = new ProdutoEntity("Ar Force", "Tenis da Nike", 2000, 1, "nike.png");
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            var response = await _repository.GetFileAsync(produto.Id);

            Assert.NotNull(response);
            Assert.True(response.IsSuccess);
            Assert.Equal(200, response._Code);
            Assert.Equal("Imagam encontrado.", response.Message);
        }
    #endregion

    #region </Delete>
        [Fact]
        public async Task DeleteAsyn_ShouldDeleteAsyn()
        {
            var produto = new ProdutoEntity("Ar Force", "Tenis da Nike", 2000, 1, "nike.png");
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            _context.Entry(produto).State = EntityState.Detached;

            var response = await _repository.DeleteAsync(produto.Id);

            Assert.NotNull(produto);
            Assert.True(response?.IsSuccess);
            Assert.Equal(200, response?._Code);
            Assert.Equal("Produto deletado", response?.Message);
        }
    #endregion

    #region </Update>
        [Fact]
        public async Task UpdateAsyn_ShouldUpdateProduto()
        {
            var produto = new ProdutoEntity("Ar Force", "Tenis da Nike", 2000, 1, "nike.png");
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            var produtoDB = await _context.Produtos.FindAsync(produto.Id);
            Assert.NotNull(produtoDB);
            produtoDB.Update("Test", "Test", 1000, 1, "imagem.png");

            var response = await _repository.UpdateAsync(produtoDB);

            Assert.NotNull(response);
            Assert.True(response?.IsSuccess);
            Assert.Equal(200, response?._Code);
            Assert.Equal("Produto editado.", response?.Message);
        }
    #endregion

    #region </Search>
        [Fact]
        public async Task SearchAsync_ShouldReturnMatchiProdutos()
        {
            _context.Produtos.AddRange(
                new ProdutoEntity("Ar Force", "Tenis da Nike", 2000, 1, "nike.png"),
                new ProdutoEntity("Ar Force 1", "Tenis da Nike", 2000, 1, "nike.png")
            );
            await _context.SaveChangesAsync();

            var response = await _repository.SearchAsync(x => x.Nome.Contains("Ar"), "Produto");

            Assert.NotNull(response);
            Assert.True(response.IsSuccess);
            Assert.Equal(200, response._Code);
            Assert.Equal("Ar Force", response.Data?[0].Nome);
        }   
    #endregion
}
