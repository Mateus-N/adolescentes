using ProjetoAdolescentes.Domain.Primitives;

namespace ProjetoAdolescentes.Domain.Interfaces;

public interface IBaseRepository<T> where T : Entity
{
    Task Create(T model);
    void Update(T model);
    void Delete(T model);
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task<bool> Exists(int id);
    Task CreateInBatch(IEnumerable<T> models);
    void DeleteInBatch(IEnumerable<T> models);
    void UpdateInBatch(IEnumerable<T> models);
    void DeleteInBatch(IEnumerable<int> ids);
}