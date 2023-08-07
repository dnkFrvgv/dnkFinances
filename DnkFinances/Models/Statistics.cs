using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnkFinances.Models
{
    public class Statistics
    {
        public decimal TotalBalance { get; set; }
        public decimal TotalIncomeCurrentMonth { get; set; }
        public decimal TotalExpenseCurrentMonth { get; set; }
        public int TotalNumberOfTransactionsCurrentYear { get; set; }
        public int NumberOfIncomeTransactionsCurrentYear { get; set; }
        public int NumberOfExpenseTransactionsCurrentYear { get; set; }
        public int TotalNumberOfTransactionsCurrentMonth { get; set; }
        public int NumberOfIncomeTransactionsCurrentMonth { get; set; }
        public int NumberOfExpenseTransactionsCurrentMonth { get; set; }
        public decimal MaxExpenseValueCurrentYear { get; set; }
        public decimal MaxIncomeValueCurrentYear { get; set; }
        public decimal MaxExpenseValueCurrentMonth { get; set; }
        public decimal MaxIncomeValueCurrentMonth { get; set; }
    }
}