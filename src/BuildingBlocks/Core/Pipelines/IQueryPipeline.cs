using BuildingBlocks.Core.CQRS.Query;
using BuildingBlocks.Core.Results;

namespace BuildingBlocks.Core.Pipelines;

public interface IQueryPipeline<in TQuery, TResponse> where TQuery : IQuery<TResponse>
{
   Task<Result<TResponse>> HandleAsync(TQuery query, CancellationToken ct,
      QueryPipelineDelegate<TResponse> next);
}

public delegate Task<Result<TResponse>> QueryPipelineDelegate<TResponse>();