using CleanArchitectureSignalR.Core.Entities;

namespace CleanArchitectureSignalR.Core.UseCases.GetMessageUseCase;

public interface IGetMessageUseCase
{
    Task<IEnumerable<Message>> ExecuteAsync();
}
