using CleanArchitectureSignalR.Core.Entities;
using CleanArchitectureSignalR.Core.UseCases.Repositories;
using CleanArchitectureSignalR.Infrastructure.SpLite.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSignalR.Infrastructure.SpLite.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly AppDbContext _dbContext;
    public MessageRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
    }
    public async Task SaveMessageAsync(Message message)
    {
        _dbContext.Messages.Add(message);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<IEnumerable<Message>> GetMessagesAsync()
    {
        return await _dbContext.Messages.ToListAsync();
    }
   
}
