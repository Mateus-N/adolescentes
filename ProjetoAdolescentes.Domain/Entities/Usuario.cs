using ProjetoAdolescentes.Domain.Enums;
using ProjetoAdolescentes.Domain.Primitives;

namespace ProjetoAdolescentes.Domain.Entities;

public class Usuario : CriticalEntity
{
    protected Usuario() { }

    public Usuario(string nome, string username)
    {
        Nome = nome;
        Username = username;
        SenhaHash = string.Empty;
        Tipo = TipoUsuario.Aluno;
    }

    public string Nome { get; private set; }
    public string Username { get; private set; }
    public string SenhaHash { get; private set; }
    public TipoUsuario Tipo { get; private set; }

    public void DefinirSenhaHash(string hash)
    {
        SenhaHash = hash;
    }
}
