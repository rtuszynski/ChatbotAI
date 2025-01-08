using MediatR;

namespace ChatbotAPI.Features.ChatMessages.Commands;

public record UpdateChatMessageRatingCommand(int Id, string Rating) : IRequest<bool>;
