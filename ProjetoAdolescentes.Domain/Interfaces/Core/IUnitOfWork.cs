namespace ProjetoAdolescentes.Domain.Interfaces.Core;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
