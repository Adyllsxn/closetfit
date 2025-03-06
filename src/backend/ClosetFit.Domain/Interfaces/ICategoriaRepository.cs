namespace ClosetFit.Domain.Interfaces;
public interface ICategoriaRepository : Interfaces<CategoriaEntity>
{
    Task<ResponseModel<CategoriaEntity>?> CreateAsync(CategoriaEntity entity);
    Task<ResponseModel<CategoriaEntity>?> DeleteAsync(int entityId);
    Task<ResponseModel<List<CategoriaEntity>?>> GetAllAsync();
    Task<ResponseModel<CategoriaEntity>?> GetByIdAsync(int entityId);
    Task<ResponseModel<List<CategoriaEntity>?>> SearchAsync(Expression<Func<CategoriaEntity, bool>> expression, string entity);
    Task<ResponseModel<CategoriaEntity>?> UpdateAsync(CategoriaEntity entity);
}
