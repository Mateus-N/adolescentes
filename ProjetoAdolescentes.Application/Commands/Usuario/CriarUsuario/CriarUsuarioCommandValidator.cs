using FluentValidation;
using ProjetoAdolescentes.Domain.Interfaces.Repositories;

namespace ProjetoAdolescentes.Application.Commands.Usuario.CriarUsuario;

public class CriarUsuarioCommandValidator : AbstractValidator<CriarUsuarioCommand>
{
    public CriarUsuarioCommandValidator(IUsuarioRepository usuarioRepository)
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O nome é obrigatório.")
            .MaximumLength(250)
            .WithMessage("O nome deve ter no máximo 250 caracteres.");

        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("O username é obrigatório.")
            .MaximumLength(100)
            .WithMessage("O username deve ter no máximo 100 caracteres.")
            .MustAsync(async (username, ct) =>
            {
                var existe = await usuarioRepository.ExistsByUsername(username);
                return !existe;
            })
            .WithMessage("O Username já está em uso.");

        RuleFor(x => x.Senha)
            .NotEmpty()
            .WithMessage("A senha é obrigatória.");
    }
}
