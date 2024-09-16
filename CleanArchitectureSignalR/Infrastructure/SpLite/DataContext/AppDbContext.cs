using System.Reflection;
using CleanArchitectureSignalR.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSignalR.Infrastructure.SpLite.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Message> Messages
    {
        get; set;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message>().ToTable("Message");
        SeedData(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }
    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message>().HasData(
            new Message { id = "1", User = "Truong1", Text = "Message1", SendAt = DateTime.Now },
            new Message { id = "2", User = "Truong2", Text = "Message2", SendAt = DateTime.Now },
            new Message { id = "3", User = "Truong3", Text = "Message3", SendAt = DateTime.Now }
        );
    }
}


