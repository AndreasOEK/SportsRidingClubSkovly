using Microsoft.EntityFrameworkCore;
using Module.User.Domain.Entity;

namespace Module.User.Infrastructure.DbContexts
{
    public class UserDbContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Module.User.Domain.Entity.User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Session>()
                .Property(s => s.RowVersion)
                .IsRowVersion();
            
            modelBuilder.Entity<Booking>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Session>()
                .HasMany(s => s.Bookings)
                .WithOne(b => b.Session)
                .HasForeignKey("SessionId")
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
