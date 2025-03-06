namespace ClosetFit.Infrastructure.Repositories;
public class CategoriaRepository(AppDbContext _context) : ICategoriaRepository
{
    #region </Create>
        public async Task<ResponseModel<CategoriaEntity>?> CreateAsync(CategoriaEntity entity)
        {
            try
            {
                if(entity == null)
                {
                    return new ResponseModel<CategoriaEntity>(null, 400, "Parâmetros não pode ser nulo");
                }
                var result = await _context.Categorias.AddAsync(entity);
                await _context.SaveChangesAsync();
                if(result == null)
                {
                    return new ResponseModel<CategoriaEntity>(null, 401, "Categoria não foi criado");
                }
                return new ResponseModel<CategoriaEntity>(entity, 201, "Categoria criado.");
            }
            catch(Exception ex)
            {
                return new ResponseModel<CategoriaEntity>(null, 500, $"Erro ao criar categoria. Erro {ex.Message}");
            }
        }

    #endregion

    #region </Delete>
        public async Task<ResponseModel<CategoriaEntity>?> DeleteAsync(int entityId)
        {
            try
            {
                if (entityId <= 0 )
                {
                    return new ResponseModel<CategoriaEntity>(null, 400, "ID não pode ser menor ou igual a zero");
                }
                var categoria = await _context.Categorias.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
                if (categoria == null)
                {
                    return new ResponseModel<CategoriaEntity>(null, 404, $"Categoria com ID {entityId}, não encontrado.");
                }
                var result = _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                if(result == null)
                {
                    return new ResponseModel<CategoriaEntity>(null, 400, "Categoria não foi deletado.");
                }
                return new ResponseModel<CategoriaEntity>(categoria, 200, "Categoria deletado");
            }
            catch(Exception ex)
            {
                return new ResponseModel<CategoriaEntity>(null, 500, $"Erro ao deletar categoria. Erro {ex.Message}");
            }
        }

    #endregion
    
    #region </GetAll>
        public async Task<ResponseModel<List<CategoriaEntity>?>> GetAllAsync()
        {
            try
            {
                var result = await _context.Categorias.AsNoTracking().ToListAsync();
                if(result == null)
                {
                    return new ResponseModel<List<CategoriaEntity>?>(null, 404, "Lista de categoria não encontrado.");
                }
                return new ResponseModel<List<CategoriaEntity>?>(result, 200, "Lista de categoria.");
            }
            catch(Exception ex)
            {
                return new ResponseModel<List<CategoriaEntity>?>(null, 500, $"Erro ao listar categoria. Erro {ex.Message}");
            }
        }

    #endregion
    
    #region </GetById>
        public async Task<ResponseModel<CategoriaEntity>?> GetByIdAsync(int entityId)
        {
            try
            {
                if(entityId <= 0)
                {
                    return new ResponseModel<CategoriaEntity>(null, 400, "ID não pode ser nulo ou menor que zero.");
                }
                var categoria = await _context.Categorias.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
                if(categoria == null)
                {
                    return new ResponseModel<CategoriaEntity>(null, 404, $"Categoria com ID {entityId}, não encontrado.");
                }
                return new ResponseModel<CategoriaEntity>(categoria, 200, $"Categoria com ID {entityId}, encontrado.");

            }
            catch(Exception ex)
            {
                return new ResponseModel<CategoriaEntity>(null, 500, $"Erro ao obter categoria. Erro {ex.Message}");
            }
        }

    #endregion
    
    #region </Search>
        public async Task<ResponseModel<List<CategoriaEntity>?>> SearchAsync(Expression<Func<CategoriaEntity, bool>> expression, string entity)
        {
            try
            {
                if (entity == null)
                {
                    return new ResponseModel<List<CategoriaEntity>?>(null, 400, "Parâmetro vazio.");
                }
                var result = await _context.Categorias.AsNoTracking().Where(expression).ToListAsync();
                if(result == null)
                {
                    return new ResponseModel<List<CategoriaEntity>?>(null, 404, $"{entity} não existe.");
                }
                return new ResponseModel<List<CategoriaEntity>?>(result, 200, $"{entity} encontrado.");
            }
            catch(Exception ex)
            {
                return new ResponseModel<List<CategoriaEntity>?>(null, 500, $"Erro ao pesquisar categoria. Erro {ex.Message}");
            }
        }

    #endregion
    
    #region </Update>
        public async Task<ResponseModel<CategoriaEntity>?> UpdateAsync(CategoriaEntity entity)
        {
            try
            {
                if(entity == null)
                {
                    return new ResponseModel<CategoriaEntity>(null, 400, "Parêmetro não deve ser vazio.");
                }
                var exist = await _context.Categorias.FindAsync(entity);
                if(exist == null)
                {
                    return new ResponseModel<CategoriaEntity>(null, 404, $"Categoria com ID {entity.Id}, não encontrado.");
                }
                _context.Entry(exist).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return new ResponseModel<CategoriaEntity>(exist, 200, "Categoria editado.");
            }
            catch(Exception ex)
            {
                return new ResponseModel<CategoriaEntity>(null, 500, $"Erro ao editar categoria. Erro {ex.Message}.");
            }
        }

    #endregion
}
