using System.ComponentModel.DataAnnotations;
using Model.Enum;

namespace Model.Base;

public class Account()
{
    [Key]
    public int Id { get; set; } 
    public string TxtNumber { get; set; } 
    public AccountType TxtType { get; set; } 
    public DateTime DtOpened { get; set; } 
    public AccountStatus TxtStatus { get; set; } 
    public DateTime? DtClosed { get; set; } 
    public decimal? DecCreditLimit { get; set; } 
    public decimal DecBalance { get; set; } 
}