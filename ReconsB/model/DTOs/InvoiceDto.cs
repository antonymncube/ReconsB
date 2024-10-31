using System;
using System.ComponentModel.DataAnnotations;

namespace ReconsB.model.DTOs
{
    public class InvoiceDto
    {
        [Required]
        public string FileName { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string FromCompany { get; set; }

        public DateTime? InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }

        [Required]
        public string Reference { get; set; }

        [Required]
        public string InvoiceNumber { get; set; }

        public string PONumber { get; set; }
        public string CustomerNumber { get; set; }

        [Required]
        public string PaymentTerms { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Invoice amount must be greater than zero.")]
        public decimal? InvoiceAmount { get; set; }

        [Required]
        public string Currency { get; set; }

        public decimal? TotalTax { get; set; }

        public decimal? TotalAmount { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string SecurityChecks { get; set; }

        public int? ContactId { get; set; }

        [Required]
        public string ErpSupplierName { get; set; }
        
    }
}
