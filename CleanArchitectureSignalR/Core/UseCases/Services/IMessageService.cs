using CleanArchitectureSignalR.Core.Entities;

namespace CleanArchitectureSignalR.Core.UseCases.Services;

public interface IMessageService
{
    Task SendMessageAsync(string user, string message);
    Task <IEnumerable<Message>> GetMessagesAsync();
}
