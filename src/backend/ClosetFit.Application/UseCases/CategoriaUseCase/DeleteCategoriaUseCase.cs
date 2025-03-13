namespace ClosetFit.Application.UseCases.CategoriaUseCase;
public class DeleteCategoriaUseCase(ICategoriaRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<CategoriaDeleteDTO>> DeleteAsync(int categoriaId)
    {
        try
        {
            var categoria = await _repository.DeleteAsync(categoriaId);
            var mapper = _mapper.Map<CategoriaDeleteDTO>(categoria);
            
            return new ResponseModel<CategoriaDeleteDTO>(mapper, 200, "Categoria deletado.");
        }
        catch (Exception ex)
        {
            return new ResponseModel<CategoriaDeleteDTO>(null, 500, $"Erro ao deletar categoria. Erro {ex.Message}");
        }
    }
}
