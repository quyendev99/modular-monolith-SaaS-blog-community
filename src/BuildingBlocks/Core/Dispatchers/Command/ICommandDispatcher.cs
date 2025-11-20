using BuildingBlocks.Core.CQRS.Command;
using BuildingBlocks.Core.Results;

namespace BuildingBlocks.Core.Dispatchers.Command;

public interface ICommandDispatcher
{
   Task<Result<TResponse>> SendAsync<TCommand, TResponse>(TCommand command, CancellationToken ct)
      where TCommand : ICommand<TResponse>;
}