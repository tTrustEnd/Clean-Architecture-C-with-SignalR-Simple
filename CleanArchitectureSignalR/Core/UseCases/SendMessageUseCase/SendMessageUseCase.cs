using CleanArchitectureSignalR.Core.Entities;
using CleanArchitectureSignalR.Core.UseCases.Repositories;
using CleanArchitectureSignalR.Core.UseCases.SendMessageUseCase;


public class SendMessageUseCase : ISendMessageUseCase
{
    private readonly IMessageRepository _messageRepository;
    public SendMessageUseCase(IMessageRepository messageRepository)
    {
       _messageRepository = messageRepository;
    }

    public async Task ExecuteAsync(string user, string message)
    {
        var newMessage = new Message
        {
            UserID = 1,
            GroupID = 1,
            Content = message,
            SendAt = DateTime.Now,
        };
        await _messageRepository.SaveMessageAsync(newMessage);
    }
}

