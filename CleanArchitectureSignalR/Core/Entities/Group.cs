namespace CleanArchitectureSignalR.Core.Entities;

public class Group
{
    public int GroupID { get; set; }
    public required string GroupName { get; set; }
    public ICollection<GroupMember>? GroupMembers { get; set; }
    public ICollection<Message> Messages { get; set; } = new List<Message>();

}
