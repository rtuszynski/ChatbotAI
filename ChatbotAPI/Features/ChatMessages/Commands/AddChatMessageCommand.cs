using ChatbotAPI.Models;
using MediatR;

namespace ChatbotAPI.Features.ChatMessages.Commands;

public record AddChatMessageCommand(string UserMessage, string BotResponse) : IRequest<ChatMessage>;
