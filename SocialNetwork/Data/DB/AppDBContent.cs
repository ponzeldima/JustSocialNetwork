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
        public DbSet<Polylogist> Polylogists { get; set; }
        public DbSet<UserConversation> UserConversations { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.UserName).IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Conversation)
                .WithOne(c => c.Image)
                .IsRequired(false);



            modelBuilder.Entity<Message>()
                .Property(m => m.SendTime)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Conversation>()
                .Property(m => m.CreatingTime)
                .HasDefaultValueSql("GETDATE()");
                

            modelBuilder.Entity<Conversation>().HasIndex(c => c.NickName).IsUnique();
            modelBuilder.Entity<Conversation>().Property(c => c.NickName).IsRequired();


            modelBuilder.Entity<UserConversation>()
                .HasKey(uc => new { uc.UserId, uc.ConversationId });

            modelBuilder.Entity<UserConversation>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.Conversations)
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<UserConversation>()
                .HasOne(uc => uc.Conversation)
                .WithMany(c => c.Members)
                .HasForeignKey(uc => uc.ConversationId)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<UserMessage>()
                .HasKey(um => new { um.MessageId, um.UserId });

            modelBuilder.Entity<UserMessage>()
                .HasOne(um => um.Message)
                .WithMany(m => m.VisibleFor)
                .HasForeignKey(um => um.MessageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserMessage>()
                .HasOne(um => um.User)
                .WithMany(u => u.VisibleMessages)
                .HasForeignKey(um => um.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
