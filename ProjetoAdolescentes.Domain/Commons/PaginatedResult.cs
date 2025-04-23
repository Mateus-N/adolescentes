namespace ProjetoAdolescentes.Domain.Commons;

public class PaginatedResult<T> where T : class
{
    public int Page { get; init; }
    public int PageSize { get; init; }
    public int TotalPages { get; init; }
    public int TotalItens { get; init; }
    public IEnumerable<T> Itens { get; init; } = [];
}