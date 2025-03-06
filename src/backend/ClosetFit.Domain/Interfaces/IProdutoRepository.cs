namespace ClosetFit.Domain.Interfaces;
public interface IProdutoRepository : Interfaces<ProdutoEntity>
{
    Task<ResponseModel<ProdutoEntity>?> CreateAsync(ProdutoEntity entity);
    Task<ResponseModel<ProdutoEntity>?> DeleteAsync(int entityId);
    Task<PagedList<List<ProdutoEntity>?>> GetAllAsync(PagedRequest request);
    Task<ResponseModel<ProdutoEntity>?> GetByIdAsync(int entityId);
    Task<ResponseModel<ProdutoEntity>?> GetFileAsync(int entityId);
    Task<ResponseModel<List<ProdutoEntity>?>> SearchAsync(Expression<Func<ProdutoEntity, bool>> expression, string entity);
    Task<ResponseModel<ProdutoEntity>?> UpdateAsync(ProdutoEntity entity);
}
