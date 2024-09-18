using System.Text.Json.Serialization;

namespace CleanArchitectureSignalR.Core.Entities;

public class Message
{
    public int MessageID { get; set; }
    public string Content {get; set; } = string.Empty;
    public int GroupID{ get; set; }
    [JsonIgnore]
    public Group? Group { get; set; }
    public int UserID { get; set; }
    [JsonIgnore]
    public User? User {get; set; }
    public DateTime SendAt { get; set; }
}
