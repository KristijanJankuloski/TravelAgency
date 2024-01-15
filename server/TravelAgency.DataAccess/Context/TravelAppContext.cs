using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Context
{
    public class TravelAppContext : IdentityDbContext<TravelUser>
    {
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<AvailableDate> AvailableDates { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<ContractEmailEvent> ContractEmailEvents { get; set; }
        public DbSet<InvoiceEmailEvent> InvoiceEmailEvents { get; set; }

        public TravelAppContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contract>()
                .HasOne(x => x.Organization)
                .WithMany(x => x.Contracts)
                .HasForeignKey(x => x.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contract>()
                .HasOne(x => x.User)
                .WithMany(x => x.Contracts)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contract>()
                .HasIndex(x => x.ContractNumber)
                .IsUnique();

            modelBuilder.Entity<Invoice>()
                .HasIndex(x => x.Number)
                .IsUnique();

            modelBuilder.Entity<Invoice>()
                .Property(x => x.Note)
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<Invoice>()
                .HasOne(x => x.User)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Organization>()
                .Property(x => x.DefaultFooter)
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<Organization>()
                .Property(x => x.InvoiceNote)
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<TravelUser>()
                .HasOne(x => x.Organization)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contract>()
                .Property(x => x.Footer)
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<ContractEmailEvent>()
                .Property(x => x.Body)
                .HasColumnType("nvarchar(511)");

            modelBuilder.Entity<ContractEmailEvent>()
                .Property(x => x.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<ContractEmailEvent>()
                .HasOne(x => x.CreatedBy)
                .WithMany(x => x.ContractEmails)
                .HasForeignKey(x => x.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InvoiceEmailEvent>()
                .Property(x => x.Body)
                .HasColumnType("nvarchar(511)");

            modelBuilder.Entity<InvoiceEmailEvent>()
                .Property(x => x.SentOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<InvoiceEmailEvent>()
                .HasOne(x => x.CreatedBy)
                .WithMany(x => x.InvoiceEmails)
                .HasForeignKey(x => x.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
