using MediatR;
using ProjetoAdolescentes.Application.Commands.Usuario.CriarUsuario;
using ProjetoAdolescentes.Application.DTOs.Usuario;
using ProjetoAdolescentes.Application.Interfaces;

namespace ProjetoAdolescentes.Application.Services;

public class UsuarioAppService(ISender sender) : IUsuarioAppService
{
    public async Task<Guid> CriarUsuario(CriarUsuarioDTO dto, CancellationToken cancellationToken)
    {
        var result = await sender.Send(CriarUsuarioCommand.MapToCommand(dto), cancellationToken);
        return result;
    }
}
