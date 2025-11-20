using BuildingBlocks.Core.CQRS.Command;
using BuildingBlocks.Core.Pipelines;
using BuildingBlocks.Core.Results;

using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Core.Dispatchers.Command;

public class CommandDispatcher(IServiceProvider provider) : ICommandDispatcher
{
   public async Task<Result<TResponse>> SendAsync<TCommand, TResponse>(TCommand command, CancellationToken ct)
      where TCommand : ICommand<TResponse>
   {
      ICommandHandler<TCommand, TResponse> handler = provider.GetRequiredService<ICommandHandler<TCommand, TResponse>>();
      List<ICommandPipeline<TCommand, TResponse>> behaviors = provider.GetServices<ICommandPipeline<TCommand, TResponse>>().ToList();
      CommandPipelineDelegate<TResponse> pipeline = () => handler.HandleAsync(command, ct);

      foreach (ICommandPipeline<TCommand, TResponse> behavior in Enumerable.Reverse(behaviors))
      {
         CommandPipelineDelegate<TResponse> next = pipeline;
         pipeline = () => behavior.HandleAsync(command, ct, next);
      }

      return await pipeline();
   }
}