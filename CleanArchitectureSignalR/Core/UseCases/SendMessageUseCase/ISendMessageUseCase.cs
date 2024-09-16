using CleanArchitectureSignalR.Core.Entities;

namespace CleanArchitectureSignalR.Core.UseCases.SendMessageUseCase;

public interface ISendMessageUseCase
{
    Task ExecuteAsync(string user, string message);
}

