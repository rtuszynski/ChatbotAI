using MediatR;

namespace ChatbotAPI.Features.ChatMessages.Commands;

public class UpdateChatMessageCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string BotResponse { get; set; }
}
