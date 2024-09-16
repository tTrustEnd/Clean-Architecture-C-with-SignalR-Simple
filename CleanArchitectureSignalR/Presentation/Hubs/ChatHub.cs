using Microsoft.AspNetCore.SignalR;

using System.Diagnostics;
using CleanArchitectureSignalR.Core.Entities;
using CleanArchitectureSignalR.Core.UseCases.GetMessageUseCase;
using CleanArchitectureSignalR.Core.UseCases.SendMessageUseCase;
using CleanArchitectureSignalR.Core.UseCases.Services;

namespace CleanArchitectureSignalR.Presentation.Hubs;

public class ChatHub : Hub
{
    private readonly IMessageService _messageService;
    public ChatHub(IMessageService messageService)
    {
        _messageService = messageService;
    }
    public async Task SendMessage(string user, string message)
    {
        try
        {
            await _messageService.SendMessageAsync(user, message);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw; // Propagate the exception to client
        }
    }
    public async Task<IEnumerable<Message>> GetMessages()
    {
        try
        {
            var Mes = await _messageService.GetMessagesAsync();
            Debug.WriteLine("Messages: " + string.Join(", ", Mes)); // Ghi log tin nhắn
            return Mes;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
