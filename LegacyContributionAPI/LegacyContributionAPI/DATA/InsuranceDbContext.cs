using Microsoft.EntityFrameworkCore;
using InsuranceContribution.Domain.Entities;

namespace InsuranceContribution.Infrastructure.Data
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Insurer> Insurers => Set<Insurer>();
        public DbSet<Policy> Policies => Set<Policy>();
        public DbSet<Contribution> Contributions => Set<Contribution>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

            // Decimal precision fix
            modelBuilder.Entity<Contribution>()
                .Property(c => c.PremiumAmount)
                .HasPrecision(18, 2);

            // Unique constraints
            modelBuilder.Entity<Insurer>()
                .HasIndex(i => i.InsurerCode)
                .IsUnique();

            modelBuilder.Entity<Policy>()
                .HasIndex(p => p.PolicyNumber)
                .IsUnique();

            modelBuilder.Entity<Contribution>()
                .HasIndex(c => c.TransactionRef)
                .IsUnique();
        }
    }
}
