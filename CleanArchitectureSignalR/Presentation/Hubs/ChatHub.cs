using Microsoft.AspNetCore.SignalR;

using System.Diagnostics;
using CleanArchitectureSignalR.Core.Entities;
using CleanArchitectureSignalR.Core.UseCases.Services;
using CleanArchitectureSignalR.Core.UseCases.GetOnlineGroupMemberUseCase;

namespace CleanArchitectureSignalR.Presentation.Hubs;

public class ChatHub : Hub
{
    private readonly IMessageService _messageService;
    private readonly IGetOnlineGroupMemberUseCase _getOnlineGroupMemberUseCase;
    public ChatHub(
        IMessageService messageService,
        IGetOnlineGroupMemberUseCase getOnlineGroupMemberUseCase
        )
    {
        _messageService = messageService;
        _getOnlineGroupMemberUseCase = getOnlineGroupMemberUseCase;
    }
    public async Task GetOnlineGroupMembers(int groupId)
    {
        try
        {
            var member = await _getOnlineGroupMemberUseCase.ExecuteAsync(groupId);
            foreach(var mb in member)
            {
                Debug.WriteLine(
                    "NAME: " + mb.User?.UserName
                    );
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw; 
        }
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
            foreach (var m in Mes) 
            {
                Debug.WriteLine(m.MessageID + " " 
                    + m.User?.UserName + " "
                    + m.Group?.GroupName + " "
                    + m.Content);
            }
            return Mes;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
