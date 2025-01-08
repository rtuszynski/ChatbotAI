using MediatR;

namespace ChatbotAPI.Features.ChatMessages.Commands;

public record UpdateChatMessageRatingCommand(int Id, int Rating) : IRequest<bool>;
