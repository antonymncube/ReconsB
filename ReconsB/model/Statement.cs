namespace ReconsB.model
{
    public class Statement
    {
        public int StatementId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public string Type { get; set; }
        public string FromCompany { get; set; }
        public DateTime StatementDate { get; set; }
        public string CustomerNumber { get; set; }
        public string PaymentTerms { get; set; }
        public decimal CurrentAmount { get; set; }
        public decimal Days30 { get; set; }
        public decimal Days60 { get; set; }
        public decimal Days90 { get; set; }
        public string Currency { get; set; }
        public decimal TotalBalance { get; set; }
        public string? ContactId { get; set; }
        public decimal? OpeningBalance { get; set; }
    }
}
