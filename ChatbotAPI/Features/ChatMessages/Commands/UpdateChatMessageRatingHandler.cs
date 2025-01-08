using ChatbotAPI.Data;
using MediatR;

namespace ChatbotAPI.Features.ChatMessages.Commands;

public class UpdateChatMessageRatingHandler : IRequestHandler<UpdateChatMessageRatingCommand, bool>
{
    private readonly ChatbotContext _context;

    public UpdateChatMessageRatingHandler(ChatbotContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateChatMessageRatingCommand request, CancellationToken cancellationToken)
    {
        var message = await _context.ChatMessages.FindAsync(request.Id);
        if (message == null) return false;

        message.Rating = request.Rating;
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
