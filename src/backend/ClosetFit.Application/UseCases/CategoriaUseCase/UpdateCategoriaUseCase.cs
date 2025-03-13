namespace ClosetFit.Application.UseCases.CategoriaUseCase;
public class UpdateCategoriaUseCase(ICategoriaRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<CategoriaUpdateDTO>> UpdateAsync(CategoriaUpdateDTO categoriaUpdateDTO)
    {
        try
        {
            if(categoriaUpdateDTO == null)
            {
                return new ResponseModel<CategoriaUpdateDTO>(null, 400, "Parêmetro vazio");
            }

            var mapper = _mapper.Map<CategoriaEntity>(categoriaUpdateDTO);
            var categoria = await _repository.UpdateAsync(mapper);
            return new ResponseModel<CategoriaUpdateDTO>(categoriaUpdateDTO, 200, "Categoria editado.");
        }
        catch (Exception ex)
        {
            return new ResponseModel<CategoriaUpdateDTO>(null, 500, $"Erro ao editar categoria. Erro {ex.Message}");
        }
    }
}
