using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Enum;

namespace Model.Base;
[Table("account")]
public class Account()
{
    [Key]
    [Column("id")]
    public int Id { get; set; } 

    [Column("txt_number")]
    public string TxtNumber { get; set; } 

    [Column("txt_type")]
    public AccountType TxtType { get; set; } 

    [Column("dt_opened")]
    public DateTime DtOpened { get; set; } 

    [Column("txt_status")]
    public AccountStatus TxtStatus { get; set; } 

    [Column("dt_closed")]
    public DateTime? DtClosed { get; set; } 

    [Column("dec_credit_limit")]
    public decimal? DecCreditLimit { get; set; } 

    [Column("dec_balance")]
    public decimal DecBalance { get; set; } 
}