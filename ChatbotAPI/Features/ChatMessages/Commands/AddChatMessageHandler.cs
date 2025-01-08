using ChatbotAPI.Data;
using ChatbotAPI.Models;
using MediatR;

namespace ChatbotAPI.Features.ChatMessages.Commands;

public class AddChatMessageHandler : IRequestHandler<AddChatMessageCommand, ChatMessage>
{
    private readonly ChatbotContext _context;

    public AddChatMessageHandler(ChatbotContext context)
    {
        _context = context;
    }

    public async Task<ChatMessage> Handle(AddChatMessageCommand request, CancellationToken cancellationToken)
    {
        var message = new ChatMessage
        {
            UserMessage = request.UserMessage,
            BotResponse = request.BotResponse,
            Timestamp = DateTime.UtcNow
        };

        _context.ChatMessages.Add(message);
        await _context.SaveChangesAsync(cancellationToken);

        return message;
    }
}
