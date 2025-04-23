using Microsoft.EntityFrameworkCore;
using ProjetoAdolescentes.Domain.Entities;
using ProjetoAdolescentes.Domain.Interfaces.Repositories;
using ProjetoAdolescentes.Infra.Data.Contexts;

namespace ProjetoAdolescentes.Infra.Data.Repositories;

public class UsuarioRepository(AdolescentesContext context) : CriticalBaseRepository<Usuario>(context), IUsuarioRepository
{
    public async Task<bool> ExistsByUsername(string username)
    {
        return await _dbSet.AsNoTracking().AnyAsync(x => x.Username == username);
    }
}
