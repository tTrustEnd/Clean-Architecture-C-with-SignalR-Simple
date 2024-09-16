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
            id = Guid.NewGuid().ToString(),
            User = user,
            Text = message,
            SendAt = DateTime.Now,
        };
        await _messageRepository.SaveMessageAsync(newMessage);
    }
}

