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
        await _httpClient.PostAsJsonAsync("chat/messages", message);
    }

    public async Task UpdateRatingAsync(int id, int rating)
    {
        await _httpClient.PutAsJsonAsync($"chat/messages/{id}/rating", rating);
    }
}
