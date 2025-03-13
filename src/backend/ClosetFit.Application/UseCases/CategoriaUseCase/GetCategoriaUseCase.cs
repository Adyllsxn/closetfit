namespace ClosetFit.Application.UseCases.CategoriaUseCase;
public class GetCategoriaUseCase(ICategoriaRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<List<CategoriaGetDTO>>> GetAllAsync()
    {
        try
        {
            var categoria = await _repository.GetAllAsync();
            var mapper = _mapper.Map<List<CategoriaGetDTO>>(categoria);
            return new ResponseModel<List<CategoriaGetDTO>>(mapper, 200, "Categoria Encontrado.");
        }
        catch (Exception ex)
        {
            return new ResponseModel<List<CategoriaGetDTO>>(null, 500, $"Erro ao obter categoria. Erro {ex.Message}");
        }
    } 
}
