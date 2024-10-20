namespace ReconsB.model.DTOs
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public string FromCompany { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string Reference { get; set; }
        public string InvoiceNumber { get; set; }
        public string PONumber { get; set; }
        public string CustomerNumber { get; set; }
        public string PaymentTerms { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public string Currency { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Status { get; set; }
        public string SecurityChecks { get; set; }
        public int? ContactId { get; set; }
        public string ErpSupplierName { get; set; }
    }
}
