using ChatbotAPI.Models;
using MediatR;

namespace ChatbotAPI.Features.ChatMessages.Queries;

public record GetChatMessagesQuery : IRequest<List<ChatMessage>>;
