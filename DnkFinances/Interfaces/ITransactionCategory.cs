using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnkFinances.Interfaces
{
  public interface ITransactionCategory
  {
    public int Id { get; }
    public string Name { get; }
  }
}