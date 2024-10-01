using MediatR;

namespace MagCoders.Orders.Shared.Abstractions.Queries;

/// <summary>
/// Interface to send queries.
/// </summary>
/// <typeparam name="TResponse">Type of request.</typeparam>
public interface IQuery<TResponse> : IRequest<TResponse>
{
}