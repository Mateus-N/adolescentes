namespace ProjetoAdolescentes.Application.DTOs.Usuario;

public record CriarUsuarioDTO
{
    public required string Nome { get; init; }
    public required string Username { get; init; }
    public required string Senha { get; init; }
}
