using ChatbotAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatbotAPI.Data;

public class ChatbotContext : DbContext
{
    public DbSet<ChatMessage> ChatMessages { get; set; }

    public ChatbotContext(DbContextOptions<ChatbotContext> options) : base(options) { }
}
