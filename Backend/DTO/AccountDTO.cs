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

         public string? FirstName { get; set; }

        public string? typeName { get; set; }

        public string? email { get; set; }

        public string? phone { get; set; }
    }
    }




