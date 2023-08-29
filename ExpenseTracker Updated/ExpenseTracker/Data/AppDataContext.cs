using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Data
{
    public class AppDataContext : DbContext
    {
        public virtual DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public virtual DbSet<ExpenseEntry> ExpenseEntries { get; set; }

        public AppDataContext()
        {
            if (Database.CanConnect()) AppDataSeeder.SeedData(this);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ConnectionString = @"server=localhost;port = 3306;user id=root;password=pritom;database=ExpenseTrackerDb";

            optionsBuilder.UseMySql(ConnectionString, MySqlServerVersion.AutoDetect(ConnectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ExpenseEntry>()
                .HasOne(e => e.Category)
                .WithMany(c => c.Expenses)
                .IsRequired();
        }

    }
}
