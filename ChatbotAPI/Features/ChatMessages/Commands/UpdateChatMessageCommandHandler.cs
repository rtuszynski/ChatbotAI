using ChatbotAPI.Data;
using MediatR;

namespace ChatbotAPI.Features.ChatMessages.Commands;

public class UpdateChatMessageCommandHandler : IRequestHandler<UpdateChatMessageCommand, bool>
{
    private readonly ChatbotContext _context;

    public UpdateChatMessageCommandHandler(ChatbotContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateChatMessageCommand request, CancellationToken cancellationToken)
    {
        var message = await _context.ChatMessages.FindAsync(request.Id);
        if (message == null)
        {
            return false;
        }

        message.BotResponse = request.BotResponse;

        _context.ChatMessages.Update(message);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
