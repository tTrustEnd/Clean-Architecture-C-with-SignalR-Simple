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

    public DbSet<Message> Messages{ get; set;}
    public DbSet<User> Users{ get; set;}
    public DbSet<Group> Groups{ get; set;}
    public DbSet<GroupMember> GroupMembers { get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Message>()
        //     .HasOne(m => m.User)
        //     .WithMany()
        //     .HasForeignKey(m => m.UserID);

        //modelBuilder.Entity<Message>()
        //    .HasOne(m => m.Group)
        //    .WithMany(g => g.Messages)
        //    .HasForeignKey(m => m.GroupID);

        SeedData(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }
    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupMember>().HasData(
            new GroupMember { GroupMemberID = 1, UserID = 1, GroupID = 1 },
            new GroupMember { GroupMemberID = 2, UserID = 2, GroupID = 1 },
            new GroupMember { GroupMemberID = 3, UserID = 1, GroupID = 2 }
        );
        modelBuilder.Entity<User>().HasData(
            new User { UserID = 1, UserName = "Truong1", IsOnline = true },
            new User { UserID = 2, UserName = "Truong2", IsOnline = true },
            new User { UserID = 3, UserName = "Truong3", IsOnline = true }
        );
        modelBuilder.Entity<Group>().HasData(
            new Group { GroupID = 1, GroupName = "Group1" },
            new Group { GroupID = 2, GroupName = "Group2" },
            new Group { GroupID = 3, GroupName = "Group3" }
        );

        modelBuilder.Entity<Message>().HasData(
            new Message
            {
                MessageID = 1,
                UserID = 1,
                Content = "Message1",
                GroupID = 1,
                SendAt = DateTime.Now
            },
             new Message
             {
                 MessageID = 2,
                 UserID = 2,
                 Content = "Message2",
                 GroupID = 2,
                 SendAt = DateTime.Now
             },
              new Message
              {
                  MessageID = 3,
                  UserID = 3,
                  Content = "Message3",
                  GroupID = 3,
                  SendAt = DateTime.Now
              }
        );

    }
}


