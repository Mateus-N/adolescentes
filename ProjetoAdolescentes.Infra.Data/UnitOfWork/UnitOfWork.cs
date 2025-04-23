using ProjetoAdolescentes.Domain.Interfaces.Core;
using ProjetoAdolescentes.Infra.Data.Contexts;

namespace ProjetoAdolescentes.Infra.Data.UnitOfWork;

internal class UnitOfWork(AdolescentesContext context) : IUnitOfWork
{
    private readonly AdolescentesContext _context = context;

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}