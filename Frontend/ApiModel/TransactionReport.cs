namespace Frontend.ApiModel
{
    public class TransactionReport
    {
        public int TransactionReportId { get; set; }

        public int AccountId { get; set; }

        public int? GeneratorId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal? TotalAmount { get; set; }

        public int? TransactionCount { get; set; }
    }
}
