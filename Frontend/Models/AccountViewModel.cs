using System.ComponentModel;

namespace Frontend.Models
{
    public class AccountViewModel
    {
        [DisplayName("ID")]
        public int AccountId { get; set; }

        [DisplayName("Numero de Cuenta")]
        public string AccountNumber { get; set; } = null!;

        [DisplayName("ID del Cliente")]
        public int ClientId { get; set; }

        [DisplayName("Tipo de Cuenta")]
        public int AccountTypeId { get; set; }

        [DisplayName("Saldo")]
        public decimal? Balance { get; set; }

        [DisplayName("Fecha de Apertura")]
        public DateTime? OpeningDate { get; set; }
    }
}
