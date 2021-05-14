using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
  public class ApplicationContext : DbContext
  {
    const string DEFAULT_CONNECTION = "Server=localhost;Port=5432;Database=Pocket;User ID=postgres;Password=postgres;";

    public ApplicationContext()
    {
      this.ChangeTracker.LazyLoadingEnabled = false;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? DEFAULT_CONNECTION;
      optionsBuilder.UseNpgsql(connectionString);
    }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<CurrencyType> CurrencyTypes { get; set; }
    public DbSet<LedgerEntries> LedgerEntries { get; set; }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Creation)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
  }
}