namespace CleanArchitectureSignalR.Core.Entities;

public class User
{
    public int UserID{ get; set; }
    public string UserName { get; set; } = string.Empty;
    public bool IsOnline { get; set; } = false;
    public ICollection<GroupMember> GroupMembers { get; set; } = new List<GroupMember>();
}
