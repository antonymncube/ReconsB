using ReconsB.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReconsB.model
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public int Id { get; set; }  

        [Required]
        [StringLength(255)]
        public string SupplierName { get; set; } 

        public string Bank { get; set; } 

        public string BankAccountNumber { get; set; } 

        public string VatNo { get; set; } 

        public string CompanyReg { get; set; } 

        public string Other { get; set; } 

        public int? ContactId { get; set; } 
        [ForeignKey("ContactId")]
        public virtual Contact Contact { get; set; }  

        public string PaymentTerms { get; set; }  

    }
}

