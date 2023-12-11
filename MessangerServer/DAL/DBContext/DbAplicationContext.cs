using BLL.Core.Domain;
using DAL.DBContext;
using Microsoft.EntityFrameworkCore;

namespace DAL.DBContex
{
    public class DbAplicationContext : DbContext
    {
        private readonly string connectionString = "Server=localhost;Database=SecFlowDb;Trusted_Connection=True;TrustServerCertificate=True";
        public DbAplicationContext()
        {
        }

        public DbAplicationContext(DbContextOptions<DbAplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDialog>()
                    .HasKey(ud => new { ud.UserId, ud.DialogId });

            modelBuilder.Entity<UserDialog>()
                .HasOne(ud => ud.User)
                .WithMany(u => u.UserDialogs)
                .HasForeignKey(ud => ud.UserId);

            modelBuilder.Entity<UserDialog>()
                .HasOne(ud => ud.Dialog)
                .WithMany(d => d.UserDialogs)
                .HasForeignKey(ud => ud.DialogId);

            modelBuilder.Entity<Dialog>()
                .HasMany(d => d.Messages)
                .WithOne(m => m.Dialog)
                .HasForeignKey(m => m.DialogId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
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
                    throw new ArgumentException("Wrong connection string.");
                }
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Dialog> Dialogs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserDialog> UserDialogs { get; set; }
    }
}
