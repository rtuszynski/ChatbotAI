using ChatbotFrontendBlazor.Models;
using System.Net.Http.Json;

namespace ChatbotFrontendBlazor.Services;

public class ChatService
{
    private readonly HttpClient _httpClient;

    public ChatService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ChatMessage>> GetMessagesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<ChatMessage>>("chat/messages");
    }

    public async Task AddMessageAsync(ChatMessage message)
    {
        message.BotResponse = GenerateBotResponse();
        await _httpClient.PostAsJsonAsync("chat/messages", message);
    }

    private string GenerateBotResponse()
    {
        var random = new Random();
        int responseType = random.Next(3);

        switch (responseType)
        {
            case 0:
                return "To jest krótka odpowiedź bota.";
            case 1:
                return "To jest średnia odpowiedź bota, która zawiera więcej informacji i składa się z kilku zdań.";
            case 2:
                return "To jest bardzo długa odpowiedź bota, która składa się z kilku akapitów. Może zawierać " +
                    "wiele szczegółów i informacji, które są istotne dla użytkownika. Taka odpowiedź może być " +
                    "użyteczna w przypadku bardziej skomplikowanych zapytań, które wymagają szczegółowego wyjaśnienia.";
            default:
                return "To jest domyślna odpowiedź bota.";
        }
    }

    public async Task UpdateRatingAsync(int id, int rating)
    {
        await _httpClient.PutAsJsonAsync($"chat/messages/{id}/rating", rating);
    }

    public async Task UpdateMessageAsync(ChatMessage message)
    {
        await _httpClient.PutAsJsonAsync($"chat/messages/{message.Id}", message);
    }
}
