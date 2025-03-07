namespace ClosetFit.IntegrationTest.Repositories;
public class CategoriaRepositoryTest
{
    #region </Configuration>
        private readonly AppDbContext _context;
        private readonly CategoriaRepository _repository;

        public CategoriaRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            
            _context = new AppDbContext(options);
            _repository = new CategoriaRepository(_context);
        }
    #endregion

    #region </Create>
        [Fact]
        public async Task CreateAsync_ShouldCreateCategoria()
        {
            // Arrange
            var categoria = new CategoriaEntity("Roupas");
            
            // Act
            var response = await _repository.CreateAsync(categoria);
            
            // Assert
            Assert.NotNull(response);
            Assert.True(response.IsSuccess);
            Assert.Equal(201, response._Code);
            Assert.Equal("Categoria criado.", response.Message);
        }
    #endregion

    #region </GetById>
        [Fact]
        public async Task GetByIdAsync_ShouldReturnCategoria_WhenExists()
        {
            // Arrange
            var categoria = new CategoriaEntity("Calçados");
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            
            // Act
            var response = await _repository.GetByIdAsync(categoria.Id);
            
            // Assert
            Assert.NotNull(response);
            Assert.True(response.IsSuccess);
            Assert.Equal(200, response._Code);
            Assert.Equal("Categoria com ID " + categoria.Id + ", encontrado.", response.Message);
        }
    #endregion

    #region </GetAll>
        [Fact]
        public async Task GetAllAsync_ShouldReturnAllCategorias()
        {
            // Arrange
            _context.Categorias.AddRange(
                new CategoriaEntity("Eletrônicos"),
                new CategoriaEntity("Casa e Decoração")
            );
            await _context.SaveChangesAsync();
            
            // Act
            var response = await _repository.GetAllAsync();
            
            // Assert
            Assert.NotNull(response);
            Assert.True(response.IsSuccess);
            Assert.Equal(200, response._Code);
            Assert.NotNull(response.Data);
            Assert.Equal(2, response.Data.Count);
        }
    #endregion

    #region </Search>
        [Fact]
        public async Task SearchAsync_ShouldReturnMatchingCategorias()
        {
            // Arrange
            _context.Categorias.AddRange(
                new CategoriaEntity("Esportes"),
                new CategoriaEntity("Jogos"),
                new CategoriaEntity("Brinquedos")
            );
            await _context.SaveChangesAsync();
            
            // Act
            var response = await _repository.SearchAsync(c => c.Nome.Contains("Jog"), "Categoria");
            
            // Assert
            Assert.NotNull(response);
            Assert.True(response.IsSuccess);
            Assert.Equal(200, response._Code);
            Assert.Single(response.Data);
            Assert.Equal("Jogos", response.Data[0].Nome);
        }
    #endregion

    #region </Delete>
        [Fact]
        public async Task DeleteAsync_ShouldRemoveCategoria_WhenExists()
        {
            // Arrange
            var categoria = new CategoriaEntity("Gadgets");
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            _context.Entry(categoria).State = EntityState.Detached; // Simula um cenário real

            // Act
            var response = await _repository.DeleteAsync(categoria.Id);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.IsSuccess);
            Assert.Equal(200, response._Code);
            Assert.Equal("Categoria deletado", response.Message);

            var categoriaDb = await _context.Categorias.FindAsync(categoria.Id);
            Assert.Null(categoriaDb);
        }
    #endregion
    
    #region </Update>
        [Fact]
        public async Task UpdateAsync_ShouldUpdateCategoria_WhenExists()
        {
            // Arrange
            var categoria = new CategoriaEntity("Acessórios");
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            // Buscar a categoria existente e modificar o nome
            var categoriaDb = await _context.Categorias.FindAsync(categoria.Id);
            Assert.NotNull(categoriaDb);
            categoriaDb.Update("Moda"); // Método no Entity para alterar o nome

            // Act
            var response = await _repository.UpdateAsync(categoriaDb);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.IsSuccess);
            Assert.Equal(200, response._Code);
            Assert.Equal("Categoria editado.", response.Message);

            var updatedCategoriaDb = await _context.Categorias.FindAsync(categoria.Id);
            Assert.NotNull(updatedCategoriaDb);
            Assert.Equal("Moda", updatedCategoriaDb.Nome);
        }
    #endregion

}
