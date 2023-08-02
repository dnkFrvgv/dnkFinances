using System.ComponentModel.DataAnnotations;

namespace DnkFinances.Models
{
  public class Account
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public AccountType Type { get; set; }
    public Decimal Balance { get; set; } = 0;
    public ICollection<Transaction> Transactions { get; set; }

  }

  public enum AccountType
  {
    DINHEIRO = 1,
    CARTAO_CREADITO = 2,
    CARTAO_DEBITO = 3
  }
}