using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DnkFinances.Models
{
  public class Account
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "Nome é obrigatório.")]
    [MaxLength(50, ErrorMessage = "Nome não pode exceder 50 caractéres.")]
    [DisplayName("Nome")]
    public string Name { get; set; }
    [Required]
    [DisplayName("Saldo Disponivel")]
    public Decimal Balance { get; set; } = 0;
    public ICollection<Transaction> Transactions { get; set; }

  }

  // public enum AccountType
  // {
  //   DINHEIRO = 1,
  //   CARTAO_CREADITO = 2,
  //   CARTAO_DEBITO = 3
  // }
}