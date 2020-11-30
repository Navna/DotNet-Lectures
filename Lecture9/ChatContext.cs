using System;
using Microsoft.EntityFrameworkCore;

namespace Lecture9
{
    public class ChatContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Dialog> Dialogs { get; set; }
        public DbSet<UserDialog> UserDialogs { get; set; }
        public DbSet<Message> Messages { get; set; }

        //public ChatContext()
        //{
        //    Database.EnsureDeleted();
        //    Database.EnsureCreated();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // TODO: https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets
            options.UseMySQL("Datasource=localhost; Database=chat; User=root; Password=password");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException(nameof(modelBuilder));
            modelBuilder.Entity<UserDialog>().HasKey(e => new { e.UserId, e.DialogId });
        }
    }
}
