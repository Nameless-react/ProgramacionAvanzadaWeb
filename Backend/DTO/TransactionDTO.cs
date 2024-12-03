namespace Backend.DTO
{
    public class TransactionDTO
    {
        public int TransactionId { get; set; }

        public int OriginAccountId { get; set; }

        public int DestinationAccountId { get; set; }

        public DateTime? TransactionDate { get; set; }

        public decimal Amount { get; set; }

        public string? Description { get; set; }

   
    }
}
