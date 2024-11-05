using ReconsB.model;
using System;
using System.Collections.Generic; // Include this for List
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReconsB.Model
{
    public class PurchaseOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseOrderId { get; set; }

        [Required]
        [StringLength(50)]
        public string PONumber { get; set; }

        [Required]
        [StringLength(255)]
        public string SupplierName { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [StringLength(3)]
        public string Currency { get; set; }

        public string PaymentTerms { get; set; }

        public string Status { get; set; }

        [StringLength(255)]
        public string Notes { get; set; }

        // Items collection
        public virtual List<PurchaseOrderItem> Items { get; set; } = new List<PurchaseOrderItem>(); // Initialize to avoid null reference

        [Required]
        public int FileId { get; set; }

        [ForeignKey("FileId")]
        public virtual Filee File { get; set; }

        public PurchaseOrder() { }
    }
}
