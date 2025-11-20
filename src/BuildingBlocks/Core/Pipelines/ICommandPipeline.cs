using BuildingBlocks.Core.CQRS.Command;
using BuildingBlocks.Core.Results;

namespace BuildingBlocks.Core.Pipelines;

public interface ICommandPipeline<in TCommand, TResponse> where TCommand : ICommand<TResponse>
{
   Task<Result<TResponse>> HandleAsync(ICommand<TResponse> command, CancellationToken ct,
      CommandPipelineDelegate<TResponse> next);
}

public delegate Task<Result<TResponse>> CommandPipelineDelegate<TResponse>();