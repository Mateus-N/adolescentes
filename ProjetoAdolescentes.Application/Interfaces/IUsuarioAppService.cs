using ProjetoAdolescentes.Application.DTOs.Usuario;

namespace ProjetoAdolescentes.Application.Interfaces;

public interface IUsuarioAppService
{
    Task<Guid> CriarUsuario(CriarUsuarioDTO dto, CancellationToken cancellationToken);
}
