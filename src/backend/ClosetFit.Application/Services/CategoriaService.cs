namespace ClosetFit.Application.Services;
public class CategoriaService(CreateCategoriaUseCase create, DeleteCategoriaUseCase delete, GetCategoriaByIdUseCase getById, GetCategoriaUseCase get, SearchCategoriaUseCase search, UpdateCategoriaUseCase update) : ICategoriaService
{
    public async Task<ResponseModel<CategoriaPostDTO>> CreateAsync(CategoriaPostDTO categoriaPostDTO)
    {
        return await create.CreateAsync(categoriaPostDTO);
    }

    public async Task<ResponseModel<CategoriaDeleteDTO>> DeleteAsync(int categoriaId)
    {
        return await delete.DeleteAsync(categoriaId);
    }

    public async Task<ResponseModel<List<CategoriaGetDTO>>> GetAllAsync()
    {
        return await get.GetAllAsync();
    }

    public async Task<ResponseModel<CategoriaGetDTO>> GetByIdAsync(int categoriaId)
    {
        return await getById.GetByIdAsync(categoriaId);
    }

    public Task<ResponseModel<List<CategoriaGetDTO>>> SearchCategoriaAsync(string categoria)
    {
        return search.SearchCategoriaAsync(categoria);
    }

    public async Task<ResponseModel<CategoriaUpdateDTO>> UpdateAsync(CategoriaUpdateDTO categoriaUpdateDTO)
    {
        return await update.UpdateAsync(categoriaUpdateDTO);
    }
}
