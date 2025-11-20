using BuildingBlocks.Core.Results;

namespace BuildingBlocks.Core.CQRS.Command;

public interface ICommandHandler<in TCommand, TResponse> where TCommand : ICommand<TResponse>
{
   Task<Result<TResponse>> HandleAsync(TCommand command, CancellationToken ct);
}