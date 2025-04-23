using Microsoft.EntityFrameworkCore;
using ProjetoAdolescentes.Domain.Interfaces;
using ProjetoAdolescentes.Domain.Primitives;
using ProjetoAdolescentes.Infra.Data.Contexts;

namespace ProjetoAdolescentes.Infra.Data.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : Entity
{
    public AdolescentesContext _context;
    public DbSet<T> _dbSet;

    public BaseRepository(AdolescentesContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task Create(T model)
    {
        await _dbSet.AddAsync(model);
    }

    public void Delete(T model)
    {
        _dbSet.Remove(model);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return (await _dbSet.FindAsync(id))!;
    }

    public void Update(T model)
    {
        _context.Entry(model).State = EntityState.Modified;
        _dbSet.Update(model);
    }

    public async Task<bool> Exists(int id)
    {
        return await _dbSet.AsNoTracking().AnyAsync(x => x.Id == id);
    }

    public async Task CreateInBatch(IEnumerable<T> models)
    {
        await _dbSet.AddRangeAsync(models);
    }

    public void DeleteInBatch(IEnumerable<T> models)
    {
        _dbSet.RemoveRange(models);
    }

    public void UpdateInBatch(IEnumerable<T> models)
    {
        _dbSet.UpdateRange(models);
    }

    public void DeleteInBatch(IEnumerable<int> ids)
    {
        _dbSet.Where(x => ids.Contains(x.Id)).ToList().ForEach(x => _dbSet.Remove(x));
    }
}