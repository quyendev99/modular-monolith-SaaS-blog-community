using BuildingBlocks.Core.Results;

namespace BuildingBlocks.Core.CQRS.Query;

public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery<TResponse>
{
   Task<Result<TResponse>> HandleAsync(TQuery query, CancellationToken ct);
}