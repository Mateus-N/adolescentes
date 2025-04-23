using Microsoft.EntityFrameworkCore;
using ProjetoAdolescentes.Domain.Interfaces;
using ProjetoAdolescentes.Domain.Primitives;
using ProjetoAdolescentes.Infra.Data.Contexts;

namespace ProjetoAdolescentes.Infra.Data.Repositories;

public class CriticalBaseRepository<T>(AdolescentesContext context) : BaseRepository<T>(context), ICriticalBaseRepository<T> where T : CriticalEntity
{
    public async Task<bool> ExistsByGuid(Guid guid)
    {
        return await _dbSet.AsNoTracking().AnyAsync(x => x.Guid == guid);
    }

    public async Task<T> GetByGuidAsNoTracking(Guid guid)
    {
        return (await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Guid == guid))!;
    }

    public async Task<int> GetIdByGuidAsNoTracking(Guid guid)
    {
        return (await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Guid == guid))!.Id;
    }
    public async Task<Guid> GetGuidById(int id)
    {
        return (await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id))!.Guid;
    }

    public async Task<IEnumerable<Tuple<Guid, int>>> GetIdsByGuidsAsNoTracking(List<Guid> guids)
    {
        return await _dbSet.AsNoTracking().Where(x => guids.Contains(x.Guid)).Select(x => new Tuple<Guid, int>(x.Guid, x.Id)).ToListAsync();
    }

    public void DeleteInBatch(IEnumerable<Guid> guids)
    {
        _dbSet.Where(x => guids.Contains(x.Guid)).ToList().ForEach(x => _dbSet.Remove(x));
    }

    public async Task<T> GetByGuid(Guid guid)
    {
        return (await _dbSet.FirstOrDefaultAsync(x => x.Guid == guid))!;
    }

    public async Task<bool> AllExistsByGuids(List<Guid> guids)
    {
        return await _dbSet.AsNoTracking().Where(cgm => guids.Contains(cgm.Guid)).Select(s => s.Guid).Distinct().CountAsync() == guids.Distinct().Count();
    }

    public async Task<IEnumerable<T>> GetListByGuids(IEnumerable<Guid> guids)
    {
        return await _dbSet.Where(x => guids.Contains(x.Guid)).ToListAsync();
    }
}