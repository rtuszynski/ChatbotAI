using System.ComponentModel.DataAnnotations;

namespace ChatbotFrontendBlazor.Models;

public class ChatMessage
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Wiadomość nie może być pusta")]
    [StringLength(100, ErrorMessage = "Wiadomość nie może być dłuższa niż 100 znaków")]
    public string UserMessage { get; set; }
    public string BotResponse { get; set; }
    public int? Rating { get; set; }
}
