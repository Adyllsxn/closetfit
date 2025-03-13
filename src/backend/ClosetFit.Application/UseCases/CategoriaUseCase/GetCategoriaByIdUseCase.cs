namespace ClosetFit.Application.UseCases.CategoriaUseCase;
public class GetCategoriaByIdUseCase(ICategoriaRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<CategoriaGetDTO>> GetByIdAsync(int categoriaId)
    {
        try
        {
            var categorias = await _repository.GetByIdAsync(categoriaId);
            var mapper = _mapper.Map<CategoriaGetDTO>(categorias);
            return new ResponseModel<CategoriaGetDTO>(mapper, 200, $"Categoria Obtido com ID {categoriaId}");
        }
        catch (Exception ex)
        {
            return new ResponseModel<CategoriaGetDTO>(null, 500, $"Erro ao obter categoria. Erro {ex.Message}");
        }
    }
}
