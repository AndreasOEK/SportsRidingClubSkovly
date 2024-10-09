using Microsoft.EntityFrameworkCore;
using Module.User.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Module.User.Infrastructure.DbContexts
{
    public class UserDbContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Trainer> Trainers { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
