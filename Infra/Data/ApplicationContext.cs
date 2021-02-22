using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infra.Data
{
  public class ApplicationContext : DbContext
  {
    const string DEFAULT_CONNECTION = "Server=localhost;Port=5432;Database=Pocket;User ID=postgres;Password=postgres;";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseNpgsql(DEFAULT_CONNECTION);
    }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<FinancialTransaction> FinancialTransactions { get; set; }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinancialTransaction>()
                .Property(t => t.Creation)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
  }
}