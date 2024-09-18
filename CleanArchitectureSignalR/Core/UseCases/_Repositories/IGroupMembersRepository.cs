using CleanArchitectureSignalR.Core.Entities;

namespace CleanArchitectureSignalR.Core.UseCases._Repositories;

public interface IGroupMembersRepository
{
    Task<IEnumerable<GroupMember>> GetOnlineGroupMembersAsync(int groupID);
}
