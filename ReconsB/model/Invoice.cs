using ReconsB.model;
 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReconsB.Model
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
        public int InvoiceId { get; set; }
 

        public string FromCompany { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public DateTime? DueDate { get; set; }

        public string Reference { get; set; }

        [Required]
        [StringLength(50)]
        public string InvoiceNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string PONumber { get; set; }

        public string CustomerNumber { get; set; }

        public string PaymentTerms { get; set; }

        public decimal InvoiceAmount { get; set; }

        public string Currency { get; set; }

        public decimal? TotalTax { get; set; }

        public decimal? TotalAmount { get; set; }

        public string Status { get; set; }

        public string SecurityChecks { get; set; }

      
        [ForeignKey("PurchaseOrder")]
        public int? PurchaseOrderId { get; set; } 

        public virtual PurchaseOrder PurchaseOrder { get; set; } 

       
        [ForeignKey("Contact")]
        public int? ContactId { get; set; }  

        public virtual Contact Contact { get; set; }  

       
        [ForeignKey("File")]
        public int FileId { get; set; }

        [NotMapped]
        public List<PurchaseOrderItem> Items { get; set; }
        public virtual Filee File { get; set; }

        public Invoice()
        {
            Items = new List<PurchaseOrderItem>();  
        }
    }
}
