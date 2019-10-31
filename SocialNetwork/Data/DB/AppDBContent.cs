using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.Messages;
using SocialNetwork.Data.Models.Conversations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Data.DB
{
    public class AppDBContent : IdentityDbContext<User>
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) {
            Database.EnsureCreated();
        }
        //public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<TextMessage> TextMessages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Dialogue> Dialogues { get; set; }
        public DbSet<UserConversation> UserConversations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();

            modelBuilder.Entity<Message>()
                .Property(m => m.SendTime)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Conversation>()
                .Property(m => m.CreatingTime)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<UserConversation>()
                .HasKey(uc => new { uc.UserId, uc.ConversationId });

            modelBuilder.Entity<UserConversation>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.Conversations)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserConversation>()
                .HasOne(uc => uc.Conversation)
                .WithMany(c => c.Members)
                .HasForeignKey(uc => uc.ConversationId);
        }
    }
}
