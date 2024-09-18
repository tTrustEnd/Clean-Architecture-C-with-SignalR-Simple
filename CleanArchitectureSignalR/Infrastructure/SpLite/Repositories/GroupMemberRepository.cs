using CleanArchitectureSignalR.Core.Entities;
using CleanArchitectureSignalR.Core.UseCases._Repositories;
using CleanArchitectureSignalR.Infrastructure.SpLite.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSignalR.Infrastructure.SpLite.Repositories;

public class GroupMemberRepository: IGroupMembersRepository
{
    private readonly AppDbContext _dbContext;
    public GroupMemberRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<GroupMember>> GetOnlineGroupMembersAsync(int groupID)
    {
        try
        {
            return await _dbContext.GroupMembers
                         .Include(gm => gm.User) 
                         .Where(gm => gm.GroupID == groupID && gm.User.IsOnline == true)
                         .ToListAsync();
        }
        catch (Exception)
        {

            throw;
        }
    }
}
