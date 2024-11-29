namespace Frontend.ApiModel
{
    public class Account
    {
        public int AccountId { get; set; }

        public string AccountNumber { get; set; } = null!;

        public int ClientId { get; set; }

        public int AccountTypeId { get; set; }

        public decimal? Balance { get; set; }

        public DateTime? OpeningDate { get; set; }

    }
}
