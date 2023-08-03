using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnkFinances.Enums;

namespace DnkFinances.Models
{
  public class TransactionCategory
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public TransactionType Type { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
  }
}