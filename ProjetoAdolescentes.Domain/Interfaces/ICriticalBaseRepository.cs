using ProjetoAdolescentes.Domain.Primitives;

namespace ProjetoAdolescentes.Domain.Interfaces;

public interface ICriticalBaseRepository<T> : IBaseRepository<T> where T : CriticalEntity
{
    Task<int> GetIdByGuidAsNoTracking(Guid guid);
    Task<bool> ExistsByGuid(Guid guid);
    Task<bool> AllExistsByGuids(List<Guid> guids);
    Task<IEnumerable<Tuple<Guid, int>>> GetIdsByGuidsAsNoTracking(List<Guid> guids);
    Task<IEnumerable<T>> GetListByGuids(IEnumerable<Guid> guids);
    Task<Guid> GetGuidById(int id);
    Task<T> GetByGuidAsNoTracking(Guid guid);
    Task<T> GetByGuid(Guid guid);
    void DeleteInBatch(IEnumerable<Guid> guids);
}