using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Bank_Branches_Mini_Project.Models
{
    public class BankContext : DbContext
    {
        public DbSet<BankBranchModel> BankBranches { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure uniqueness constraint for CivilId property of Employee entity
            modelBuilder.Entity<EmployeeModel>()
                .HasIndex(e => e.CivilId)
                .IsUnique();
        }
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {

        }

        
    }
}
