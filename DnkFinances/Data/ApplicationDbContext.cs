using DnkFinances.Models;
using Microsoft.EntityFrameworkCore;

namespace DnkFinances.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get;  set;}
    public DbSet<TransactionCategory> TransactionCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Transaction>()
        .HasOne(t=>t.Account)
        .WithMany(a=>a.Transactions)
        .HasForeignKey(t=>t.AccountId);

      modelBuilder.Entity<Transaction>().HasOne(t=>t.Category).WithMany(c=>c.Transactions).HasForeignKey(t=>t.CategoryId);


      modelBuilder.Entity<TransactionCategory>().HasData(
        new TransactionCategory(){Id=1,Title="Salário", Type=Enums.TransactionType.INCOME},
        new TransactionCategory(){Id=2,Title="Pet", Type=Enums.TransactionType.EXPENSE}
      );
  
    }

  }
}