using ReconsB.model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReconsB.Model
{
    public class Filee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
        public int FileId { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; }

        [Required]
        public byte[] FileData { get; set; } // Binary data of the file

        public DateTime UploadedDate { get; set; } = DateTime.UtcNow; // Date of upload

        public int? InvoiceId { get; set; } // Foreign key to Invoice table
        public int? ErpInvoiceId { get; set; } // Foreign key to ErpInvoice table
        public int? PurchaseOrderId { get; set; } // Foreign key to PurchaseOrder table

        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }

        [ForeignKey("ErpInvoiceId")]
        public virtual ErpInvoice ErpInvoice { get; set; }

        [ForeignKey("PurchaseOrderId")]
        public virtual PurchaseOrder PurchaseOrder { get; set; } // Navigation property to PurchaseOrder
    }
}
