using Entities.Entities;

namespace Backend.DTO
{
    public class AccountDTO
    {
        public int AccountId { get; set; }

        public string AccountNumber { get; set; } = null!;

        public int ClientId { get; set; }

        public int AccountTypeId { get; set; }

        public decimal? Balance { get; set; }

        public DateTime? OpeningDate { get; set; }

        public virtual AccountType AccountType { get; set; } = null!;

        public virtual Client Client { get; set; } = null!;

        public virtual ICollection<Transaction> TransactionDestinationAccounts { get; set; } = new List<Transaction>();

        public virtual ICollection<Transaction> TransactionOriginAccounts { get; set; } = new List<Transaction>();

        public virtual ICollection<TransactionReport> TransactionReports { get; set; } = new List<TransactionReport>();
    }
    }




