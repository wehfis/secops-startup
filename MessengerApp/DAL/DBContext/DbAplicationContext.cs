using DAL.Models;
using Microsoft.EntityFrameworkCore;
using SecFlowMessenger.Models;
using System;
using System.Windows;

namespace DAL.DBContex
{
    public class DbAplicationContext : DbContext
    {
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
            string connectionString = "Server=DESKTOP-DGHE1SU;Database=SecFlowDb;Trusted_Connection=True;TrustServerCertificate=True";

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Dialog> Dialogs { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
