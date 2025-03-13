namespace ClosetFit.Application.UseCases.CategoriaUseCase;
public class CreateCategoriaUseCase(ICategoriaRepository _repository, IMapper _mapper)
{
    public async Task<ResponseModel<CategoriaPostDTO>> CreateAsync(CategoriaPostDTO categoriaPostDTO)
    {
        try
        {
            if(categoriaPostDTO == null)
            {
                return new ResponseModel<CategoriaPostDTO>(null, 400, "Parêmetro não deve ser vazio");
            }
            var mapper = _mapper.Map<CategoriaEntity>(categoriaPostDTO);
            var categoria = await _repository.CreateAsync(mapper);
            
            return new ResponseModel<CategoriaPostDTO>(categoriaPostDTO, 200, "Categoria adicionado." );
        }
        catch (Exception ex)
        {
            return new ResponseModel<CategoriaPostDTO>(null, 500, $"Erro ao criar categoria. Erro {ex.Message}");
        }
    }
}
