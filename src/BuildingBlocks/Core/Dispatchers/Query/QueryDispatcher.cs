using BuildingBlocks.Core.CQRS.Query;
using BuildingBlocks.Core.Pipelines;
using BuildingBlocks.Core.Results;

using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Core.Dispatchers.Query;

public class QueryDispatcher(IServiceProvider provider) : IQueryDispatcher
{
   public async Task<Result<TResponse>> QueryAsync<TQuery, TResponse>(IQuery<TResponse> query, CancellationToken ct)
      where TQuery : IQuery<TResponse>
   {
      IQueryHandler<TQuery, TResponse> handler = provider.GetRequiredService<IQueryHandler<TQuery, TResponse>>();
      List<IQueryPipeline<TQuery, TResponse>> behaviors = provider.GetServices<IQueryPipeline<TQuery, TResponse>>().ToList();
      QueryPipelineDelegate<TResponse> pipeline = () => handler.HandleAsync((TQuery)query, ct);

      foreach (IQueryPipeline<TQuery, TResponse> behavior in Enumerable.Reverse(behaviors))
      {
         QueryPipelineDelegate<TResponse> next = pipeline;
         pipeline = () => behavior.HandleAsync((TQuery)query, ct, next);
      }

      return await pipeline();
   }
}