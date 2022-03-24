using CleaningManagement.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleaningManagement.DAL
{
    public class CleaningManagementDbContext : DbContext
    {
        public string DbPath { get; }

        public DbSet<CleaningPlanEntity> CleaningPlans { get; set; }

        public CleaningManagementDbContext()
        {
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
           bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default
        )
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                if (entry.Entity is CleaningPlanEntity trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entry.Property("CreatedAt").IsModified = false;
                            break;

                        case EntityState.Added:
                            // set both updated and created date to "now"
                            trackable.CreatedAt = utcNow;
                            break;
                    }
                }
            }
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseInMemoryDatabase("CleaningContext");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CleaningPlanEntity>().Property(b => b.CustomerId).IsRequired();
            modelBuilder.Entity<CleaningPlanEntity>().Property(b => b.CreatedAt).IsRequired();
            modelBuilder.Entity<CleaningPlanEntity>().Property(b => b.Title).IsRequired().HasMaxLength(256);
            modelBuilder.Entity<CleaningPlanEntity>().Property(b => b.Description).HasMaxLength(512);

        }
    }
}