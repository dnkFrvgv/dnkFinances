using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnkFinances.Models;

namespace DnkFinances.Repositories.IRepository
{
    public interface ICategoryRepository : IRepository<TransactionCategory>
    {
        IEnumerable<TransactionCategory> GetAllIncomeTypeCategories();
        IEnumerable<TransactionCategory> GetAllExpenseTypeCategories();
        void Save();
    }
}