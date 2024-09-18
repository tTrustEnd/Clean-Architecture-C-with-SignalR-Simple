using CleanArchitectureSignalR.Core.Entities;

namespace CleanArchitectureSignalR.Core.UseCases.GetOnlineGroupMemberUseCase;

public interface IGetOnlineGroupMemberUseCase
{
    Task<IEnumerable<GroupMember>>? ExecuteAsync(int groupId);
}
