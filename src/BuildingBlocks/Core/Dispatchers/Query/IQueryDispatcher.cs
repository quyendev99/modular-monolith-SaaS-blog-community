using BuildingBlocks.Core.CQRS.Query;
using BuildingBlocks.Core.Results;

namespace BuildingBlocks.Core.Dispatchers.Query;

public interface IQueryDispatcher
{
   Task<Result<TResponse>> QueryAsync<TQuery, TResponse>(IQuery<TResponse> query, CancellationToken ct)
      where TQuery : IQuery<TResponse>;
}