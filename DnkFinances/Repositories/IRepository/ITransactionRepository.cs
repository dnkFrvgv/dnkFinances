using DnkFinances.Models;

namespace DnkFinances.Repositories.IRepository
{
  public interface ITransactionRepository : IRepository<Transaction>
    {
        IEnumerable<Transaction> GetAllIncomeTransactions();
        IEnumerable<Transaction> GetAllExpenseTransactions();
        IEnumerable<Transaction> GetAllTransactionByAccountId(int accountId);
        IEnumerable<Transaction> GetAllIncomeTransactionByAccountId(int accountId);
        IEnumerable<Transaction> GetAllExpenseTransactionsByAccountId(int accountId);
        IEnumerable<Transaction> GetAllTransactionsByCategoryId(int categoryId);
        void Save();
    }
}