using CleanArchitectureSignalR.Core.Entities;
using CleanArchitectureSignalR.Core.UseCases._Repositories;

namespace CleanArchitectureSignalR.Core.UseCases.GetOnlineGroupMemberUseCase;

public class GetOnlineGroupMemberUseCase : IGetOnlineGroupMemberUseCase
{
    private readonly IGroupMembersRepository _membersRepository;
    public GetOnlineGroupMemberUseCase(IGroupMembersRepository membersRepository)
    {
        _membersRepository = membersRepository;
    }
    public async Task<IEnumerable<GroupMember>> ExecuteAsync(int groupId)
    {
        try
        {
            return await _membersRepository.GetOnlineGroupMembersAsync(groupId);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
