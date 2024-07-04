using Microsoft.EntityFrameworkCore;

namespace StaffManager.Models.DB
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions options) : base(options)
        { }
        public DbSet<EmployeeDetails> employeeDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { if (!optionsBuilder.IsConfigured) { } }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDetails>(entity => { entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false); entity.Property(e => e.Description).IsRequired().HasMaxLength(250).IsUnicode(false); });
        }
    }
}
