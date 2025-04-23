using ProjetoAdolescentes.Application.DTOs.Usuario;

namespace ProjetoAdolescentes.Application.Commands.Usuario.CriarUsuario;

public record CriarUsuarioCommand : Command<Guid>
{
    public required string Nome { get; init; }
    public required string Username { get; init; }
    public required string Senha { get; init; }

    public static CriarUsuarioCommand MapToCommand(CriarUsuarioDTO dto)
    {
        return new CriarUsuarioCommand
        {
            Nome = dto.Nome,
            Username = dto.Username,
            Senha = dto.Senha
        };
    }
}
