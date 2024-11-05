using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReconsB.Model
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public int ContactId { get; set; }  

        [Required]
        [StringLength(255)]
        public string ContactName { get; set; }  

        public string ContactFromId { get; set; }  

        public string Whitelist { get; set; }  

        public string GLCode { get; set; }  

        public string CostCentre { get; set; }  

        public string DocumentClass { get; set; }  
    }
}
