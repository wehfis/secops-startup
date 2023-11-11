using BLL.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

namespace DAL.DBContex
{
    public class DbAplicationContext : DbContext
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        public DbAplicationContext()
        {
        }

        public DbAplicationContext(DbContextOptions<DbAplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Dialogs)
                .WithOne(e => e.Sender)
                .HasForeignKey(e => e.SenderId)
                .IsRequired(false);

            modelBuilder.Entity<Dialog>()
                .HasMany(e => e.Messages)
                .WithOne(e => e.Dialog)
                .HasForeignKey(e => e.DialogId)
                .IsRequired(false);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                if(!string.IsNullOrEmpty(connectionString))
                {
                    optionsBuilder.UseSqlServer(connectionString);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Dialog> Dialogs { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
