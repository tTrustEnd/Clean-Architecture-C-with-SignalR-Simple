using System.CodeDom;
using CleanArchitectureSignalR.Core.Entities;
using CleanArchitectureSignalR.Core.UseCases.Repositories;
using CleanArchitectureSignalR.Core.UseCases.SendMessageUseCase;

namespace CleanArchitectureSignalR.Core.UseCases.GetMessageUseCase;

public class GetMessageUseCase : IGetMessageUseCase
{
    private readonly IMessageRepository _messageRepository;
    public GetMessageUseCase(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }
    public async Task<IEnumerable<Message>> ExecuteAsync()
    {
        return await _messageRepository.GetMessagesAsync();
    }
}
