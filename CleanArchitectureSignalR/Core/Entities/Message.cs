namespace CleanArchitectureSignalR.Core.Entities;

public class Message
{
    public string id { get; set; } = string.Empty;  
    public string User { get; set; } = string.Empty;
    public string Text {get; set; } = string.Empty;
    public DateTime SendAt { get; set; }
}
