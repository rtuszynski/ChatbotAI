using ChatbotAPI.Data;
using ChatbotAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChatbotAPI.Features.ChatMessages.Queries;

public class GetChatMessagesHandler : IRequestHandler<GetChatMessagesQuery, List<ChatMessage>>
{
    private readonly ChatbotContext _context;

    public GetChatMessagesHandler(ChatbotContext context)
    {
        _context = context;
    }

    public async Task<List<ChatMessage>> Handle(GetChatMessagesQuery request, CancellationToken cancellationToken)
    {
        return await _context.ChatMessages.ToListAsync(cancellationToken);
    }
}
