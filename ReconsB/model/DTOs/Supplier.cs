namespace ReconsB.model.DTOs
{
    public class Supplier
    {
        public int Id { get; set; }  
        public string SupplierName { get; set; }
        public string Bank { get; set; }
        public string BankAccountNumber { get; set; }
        public string VatNo { get; set; }
        public string CompanyReg { get; set; }
        public string Other { get; set; }
        public string StatementText { get; set; }
        public string InvoiceText { get; set; }
        public string NotesAI { get; set; }
        public Guid ContactId { get; set; }  
        public string DetectionMethod { get; set; }
        public string PaymentTerms { get; set; }  
        public string Alias { get; set; }
 
    }
}
