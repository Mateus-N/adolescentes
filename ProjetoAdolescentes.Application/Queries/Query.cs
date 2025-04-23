using MediatR;

namespace ProjetoAdolescentes.Application.Queries;

public record Query<TResponse> : IRequest<TResponse>
{
}