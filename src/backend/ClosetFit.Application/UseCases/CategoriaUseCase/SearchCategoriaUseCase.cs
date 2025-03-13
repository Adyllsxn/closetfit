namespace ClosetFit.Application.UseCases.CategoriaUseCase;
public class SearchCategoriaUseCase(ICategoriaRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<List<CategoriaGetDTO>>> SearchCategoriaAsync(string categoria)
    {
        try
        {
            var categorias = await _repository.SearchAsync(x => x.Nome.Contains(categoria), categoria);
            var mapper = _mapper.Map<List<CategoriaGetDTO>>(categorias);
            return new ResponseModel<List<CategoriaGetDTO>>(mapper, 200, $"{categoria} Encontrdo");
        }
        catch (Exception ex)
        {
            return new ResponseModel<List<CategoriaGetDTO>>(null, 500, $"Erro ao pesquisar categoria. Erro {ex.Message}");
        }
    }
}
