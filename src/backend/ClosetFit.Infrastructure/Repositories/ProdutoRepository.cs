namespace ClosetFit.Infrastructure.Repositories;
public class ProdutoRepository(AppDbContext _context) : IProdutoRepository
{
    #region </Create>
        public async Task<ResponseModel<ProdutoEntity>?> CreateAsync(ProdutoEntity entity)
        {
            try
            {
                if(entity == null)
                {
                    return new ResponseModel<ProdutoEntity>(null, 500, "Parâmetro não deve ser nulo.");
                }
                var result = await _context.Produtos.AddAsync(entity);
                await _context.SaveChangesAsync();
                if(result == null)
                {
                    return new ResponseModel<ProdutoEntity>(null, 400, "Produto não foi criado.");
                }
                return new ResponseModel<ProdutoEntity>(entity, 201, "Produto criado.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<ProdutoEntity>(null, 500, $"Erro ao criar produto. Erro {ex.Message}");
            }
        }

    #endregion
    
    #region </Delete>
        public async Task<ResponseModel<ProdutoEntity>?> DeleteAsync(int entityId)
        {
            try
            {
                if( entityId <= 0 )
                {
                    return new ResponseModel<ProdutoEntity>(null, 400, "ID não pose ser menor ou igual a zero.");
                }
                var produto = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
                if( produto == null )
                {
                    return new ResponseModel<ProdutoEntity>(null, 404, $"Produto com ID {entityId}, não encontrado.");
                }
                var result = _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
                if( result == null )
                {
                    return new ResponseModel<ProdutoEntity>(null, 400, "Produto não foi deletado");
                }
                return new ResponseModel<ProdutoEntity>(produto, 200, "Produto deletado");
            }
            catch (Exception ex)
            {
                return new ResponseModel<ProdutoEntity>(null, 500, $"Erro ao deletar produto. Erro {ex.Message}");
            }
        }

    #endregion
    
    #region </GetAll>
        public async Task<PagedList<List<ProdutoEntity>?>> GetAllAsync(PagedRequest request)
        {
            try
            {
                var query = _context.Produtos.AsNoTracking().AsQueryable();
                var produtos = await query.Skip((request.pageNumber -1) / request.pageSize).Take(request.pageSize).ToListAsync();
                var count = await query.CountAsync();

                return new PagedList<List<ProdutoEntity>?>(produtos, count,request.pageNumber,request.pageSize);
            }
            catch (Exception ex)
            {
                return new PagedList<List<ProdutoEntity>?>(null, 500, $"Erro ao listar produto. Erro {ex.Message}");
            }
        }
    
    #endregion
    
    #region </GetById>
        public async Task<ResponseModel<ProdutoEntity>?> GetByIdAsync(int entityId)
        {
            try
            {
                if(entityId <= 0)
                {
                    return new ResponseModel<ProdutoEntity>(null, 400, "ID não pose ser menor ou igula a zero.");
                }
                var produto = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
                if(produto == null)
                {
                    return new ResponseModel<ProdutoEntity>(null, 404, $"Produto com ID {entityId}, não encontrado");
                }
                return new ResponseModel<ProdutoEntity>(produto, 200, $"Produto com ID {entityId}, encontrado.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<ProdutoEntity>(null, 500, $"Erro ao obter produto. Erro {ex.Message}");
            }
        }
    
    #endregion
    
    #region <GetFile>
        public async Task<ResponseModel<ProdutoEntity>?> GetFileAsync(int entityId)
        {
            try
            {   
                if(entityId <= 0)
                {
                    return new ResponseModel<ProdutoEntity>(null, 400, "ID não pode ser menor ou igual a zero.");
                }
                var file = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
                if(file == null)
                {
                    return new ResponseModel<ProdutoEntity>(null, 404, $"Imagem com ID {entityId}, não encontrado.");
                }
                return new ResponseModel<ProdutoEntity>(file, 200, "Imagam encontrado.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<ProdutoEntity>(null, 500, $"Erro ao obter a imagem. Erro {ex.Message}");
            }
        }
    
    #endregion
    
    #region <Search>
        public async Task<ResponseModel<List<ProdutoEntity>?>> SearchAsync(Expression<Func<ProdutoEntity, bool>> expression, string entity)
        {
            try
            {
                if(entity == null)
                {
                    return new ResponseModel<List<ProdutoEntity>?>(null, 400, "Parâmetro vazio");
                }
                var result = await _context.Produtos.Where(expression).AsNoTracking().ToListAsync();
                if(result == null)
                {
                    return new ResponseModel<List<ProdutoEntity>?>(null, 404, $"{entity} não encontrado");
                }    
                return new ResponseModel<List<ProdutoEntity>?>(result, 200, $"{result} encontrado.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<List<ProdutoEntity>?>(null, 500, $"Erro ao pesquisar produto. Erro {ex.Message}");
            }
        }
    
    #endregion
    
    #region </Update>
        public async Task<ResponseModel<ProdutoEntity>?> UpdateAsync(ProdutoEntity entity)
        {
            try
            {
                if(entity == null)
                {
                    return new ResponseModel<ProdutoEntity>(null, 400, "Parâmento não pode ser vazio.");
                }
                var exist = await _context.Produtos.FindAsync(entity.Id);
                if(exist == null)
                {
                    return new ResponseModel<ProdutoEntity>(null, 404, $"Produto com ID {entity.Id}, não encontrado.");
                }
                _context.Entry(exist).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return new ResponseModel<ProdutoEntity>(entity, 200, "Produto editado.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<ProdutoEntity>(null, 500, $"Erro ao editar produto. Erro {ex.Message}");
            }
        }

    #endregion
}
