using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Base
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; } 

        [Column("txt_first_name")]
        public string TxtFirstName { get; set; } 

        [Column("txt_last_name")]
        public string TxtLastName { get; set; } 

        [Column("fk_account_id")]
        public int FkAccountId { get; set; } 

        [Column("txt_phone")]
        public string TxtPhone { get; set; } 

        [Column("txt_cpf")]
        public string TxtCPF { get; set; } 

        [Column("txt_cep")]
        public string TxtCEP { get; set; } 

        [Column("txt_address")]
        public string TxtAddress { get; set; } 

        [Column("txt_number")]
        public string TxtNumber { get; set; } 

        [Column("txt_neighborhood")]
        public string TxtNeighborhood { get; set; } 

        [Column("txt_city")]
        public string TxtCity { get; set; } 

        [Column("txt_state")]
        public string TxtState { get; set; } 

        [Column("txt_complement")]
        public string TxtComplement { get; set; } 
        
        public User() { }
    }
}
