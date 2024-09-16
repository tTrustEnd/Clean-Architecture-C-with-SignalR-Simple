using CleanArchitectureSignalR.Core.Entities;

namespace CleanArchitectureSignalR.Core.UseCases.Repositories;

public interface IMessageRepository
{
    Task SaveMessageAsync(Message message);
    Task<IEnumerable<Message>> GetMessagesAsync();
}
