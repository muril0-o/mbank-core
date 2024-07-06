using System.ComponentModel.DataAnnotations;

namespace Model.Base
{
    public class User
    {
        [Key]
        public int Id { get; set; } 
        public string TxtFirstName { get; set; } 
        public string TxtLastName { get; set; } 
        public int FkAccountId { get; set; } 
        public string TxtPhone { get; set; } 
        public string TxtCPF { get; set; } 
        public string TxtCEP { get; set; } 
        public string TxtAddress { get; set; } 
        public string TxtNumber { get; set; } 
        public string TxtNeighborhood { get; set; } 
        public string TxtCity { get; set; } 
        public string TxtState { get; set; } 
        public string TxtComplement { get; set; } 
        
        public User() { }
    }
}
