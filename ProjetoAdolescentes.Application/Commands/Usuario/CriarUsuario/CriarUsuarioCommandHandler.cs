using MediatR;
using Microsoft.AspNetCore.Identity;
using ProjetoAdolescentes.Domain.Interfaces.Repositories;

namespace ProjetoAdolescentes.Application.Commands.Usuario.CriarUsuario;

public class CriarUsuarioCommandHandler(IUsuarioRepository usuarioRepository) : IRequestHandler<CriarUsuarioCommand, Guid>
{
    private readonly PasswordHasher<Domain.Entities.Usuario> _passwordHasher = new();

    public async Task<Guid> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = new Domain.Entities.Usuario(request.Nome, request.Username);

        var senhaHash = _passwordHasher.HashPassword(usuario, request.Senha);
        usuario.DefinirSenhaHash(senhaHash);

        await usuarioRepository.Create(usuario);
        return usuario.Guid;
    }
}
