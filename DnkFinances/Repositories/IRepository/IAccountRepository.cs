using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnkFinances.Models;

namespace DnkFinances.Repositories.IRepository
{
    public interface IAccountRepository : IRepository<Account>
    {
        // IEnumerable<Account> GetAllAccountsByUserId(int userId);
        void Save();
    }
}