using EmployeePlatform.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePlatform.Database
{
    /// <summary>
    /// Model aplication DBcontext
    /// </summary>
    public class EmployeePlatformContext : DbContext
    {
        public EmployeePlatformContext(DbContextOptions<EmployeePlatformContext> options)
            : base(options)
        {
        }


        public DbSet<Area> Areas { get; set; }
        public DbSet<Subarea> Subareas { get; set; }
        public DbSet<IdentificationType> IdentificationTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            AddAuditData();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuditData();
            return await base.SaveChangesAsync();
        }

        private void AddAuditData()
        {
            foreach (var entry in ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified)))
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).CreatedAt = DateTime.UtcNow;
                }
                ((BaseEntity)entry.Entity).ModifiedAt = DateTime.UtcNow;
            }
        }

    }
}
