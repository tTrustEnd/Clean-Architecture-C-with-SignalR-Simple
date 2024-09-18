using System.Text.Json.Serialization;

namespace CleanArchitectureSignalR.Core.Entities;

public class GroupMember
{
    public int GroupMemberID {get; set;}
    public int GroupID {get; set;}
    [JsonIgnore]
    public Group? Group {get; set;}
    public int UserID {get; set;}
    [JsonIgnore]
    public User? User {get; set;}
}
