using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnkFinances.Data;
using DnkFinances.Models;
using DnkFinances.Repositories.IRepository;

namespace DnkFinances.Repositories
{
  public class TransactionRepository : Repository<Transaction>, ITransactionRepository
  {

    private ApplicationDbContext _context;

    public TransactionRepository(ApplicationDbContext context) : base(context)
    {
      _context = context;
    }
    public IEnumerable<Transaction> GetAllExpenseTransactions()
    {
      return _context.Transactions.Where(t => t.Type == Enums.TransactionType.EXPENSE).ToList();
    }

    public IEnumerable<Transaction> GetAllExpenseTransactionsByAccountId(int accountId)
    {
      return _context.Transactions.Where(t => t.Type == Enums.TransactionType.EXPENSE && t.AccountId == accountId).ToList();
    }

    public IEnumerable<Transaction> GetAllIncomeTransactionByAccountId(int accountId)
    {
      return _context.Transactions.Where(t => t.Type == Enums.TransactionType.INCOME && t.AccountId == accountId).ToList();
    }

    public IEnumerable<Transaction> GetAllIncomeTransactions()
    {
      return _context.Transactions.Where(t => t.Type == Enums.TransactionType.INCOME).ToList();
    }

    public IEnumerable<Transaction> GetAllTransactionByAccountId(int accountId)
    {
      return _context.Transactions.Where(t => t.AccountId == accountId).ToList();
    }

    public IEnumerable<Transaction> GetAllTransactionsByCategoryId(int categoryId)
    {
      return _context.Transactions.Where(t => t.CategoryId == categoryId).ToList();
    }

    public void Save()
    {
      _context.SaveChanges();
    }
  }
}