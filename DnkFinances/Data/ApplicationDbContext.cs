using DnkFinances.Models;
using Microsoft.EntityFrameworkCore;

namespace DnkFinances.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    DbSet<Account> BankAccounts { get; }
    DbSet<Transaction> Transactions { get; }
    DbSet<TransactionCategory> TransactionCategories { get; }

  }
}