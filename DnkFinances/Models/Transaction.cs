using System.ComponentModel.DataAnnotations;
using DnkFinances.Enums;
using DnkFinances.Interfaces;

namespace DnkFinances.Models
{
  public class Transaction
  {
    public int Id { get; set; }
    public TransactionType Type { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; set; }
    public int CategoryId { get; set; }
    public TransactionCategory Category { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public DateTime DateAdded { get; set; }
    public TransactionStatus Status { get; set; }

    
  }
}