using Microsoft.EntityFrameworkCore;
using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Context
{
    public class TravelAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<AvailableDate> AvailableDates { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        public TravelAppContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Contract>()
                .HasOne(x => x.User)
                .WithMany(x => x.Contracts)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
