using MediatR;

namespace ProjetoAdolescentes.Application.Commands;

public record Command<TResponse> : IRequest<TResponse>
{
}