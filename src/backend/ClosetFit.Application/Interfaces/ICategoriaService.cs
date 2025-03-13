namespace ClosetFit.Application.Interfaces;
public interface ICategoriaService
{
    Task<ResponseModel<CategoriaPostDTO>> CreateAsync(CategoriaPostDTO categoriaPostDTO);
    Task<ResponseModel<CategoriaDeleteDTO>> DeleteAsync(int categoriaId);
    Task<ResponseModel<CategoriaGetDTO>> GetByIdAsync(int categoriaId);
    Task<ResponseModel<List<CategoriaGetDTO>>> GetAllAsync();
    Task<ResponseModel<List<CategoriaGetDTO>>> SearchCategoriaAsync(string categoria);
    Task<ResponseModel<CategoriaUpdateDTO>> UpdateAsync(CategoriaUpdateDTO categoriaUpdateDTO);
}
