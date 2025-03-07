namespace ClosetFit.UnitTest.Entities;
public class CategoriaEntityTest
{
    #region <Constants>
        private const int InvalidNumberZero = 0;
        private const int InvalidNumber = -1;
        private const string ValidName = "Test0";
    #endregion
    
    #region <Id>
        [Theory]
        [InlineData(InvalidNumber, ValidName)]
        [InlineData(InvalidNumberZero, ValidName)]
        public void ShouldFailIfIdIsNegative(int id, string nome)
        {
            Assert.True(true); 
            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var acount = new CategoriaEntity(id, nome);
            });
        }
    #endregion

    #region <CategoriaNome>
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void ShouldFailIfCategoryNameIsNullOrEmptyOrWhiteSpace(string nome)
        {
            Assert.True(true); 
            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var acount = new CategoriaEntity(nome);
            });
        }
    #endregion

    #region <LongLenght>
        [Fact]
        public void ShouldFailIfIsHaveLongLenght()
        {
            var LongLenght = new string('B', 56);
            Assert.True(true); 
            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var acount = new CategoriaEntity(LongLenght);
            });
        }
    #endregion

    #region <Criar>
        [Theory]
        [InlineData(ValidName)]
        public void ShouldCreate(string nome)
        {
            var count = new CategoriaEntity(nome);
            Assert.NotNull(count);
        }
    #endregion <Create>

    #region <Editar>
        [Theory]
        [InlineData(ValidName)]
        public void ShouldEdit(string nome)
        {
            var count = new CategoriaEntity(nome);
            count.Update("Test");
            Assert.Equal("Test", count.Nome);
        }
    #endregion </Editar>

}
