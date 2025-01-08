namespace ChatbotAPI.Models;

public class ChatMessage
{
    public int Id { get; set; }
    public string UserMessage { get; set; }
    public string BotResponse { get; set; }
    public string Rating { get; set; }
    public DateTime Timestamp { get; set; }
}
