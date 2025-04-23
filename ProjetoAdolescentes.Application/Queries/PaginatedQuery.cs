using MediatR;

namespace ProjetoAdolescentes.Application.Queries;

public record PaginatedQuery<TResponse> : IRequest<TResponse>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}