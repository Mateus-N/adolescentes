using ProjetoAdolescentes.Domain.Entities;

namespace ProjetoAdolescentes.Domain.Interfaces.Repositories;

public interface IUsuarioRepository : ICriticalBaseRepository<Usuario>
{
    Task<bool> ExistsByUsername(string username);
}
