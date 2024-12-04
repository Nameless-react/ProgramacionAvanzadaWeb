using System.ComponentModel;

namespace Frontend.Models
{
    public class TransactionViewModel
    {
        [DisplayName("ID")]
        public int TransactionId { get; set; }

        [DisplayName("Cuenta de Origen")]
        public int OriginAccountId { get; set; }

        [DisplayName("Cuenta de Destino")]
        public int DestinationAccountId { get; set; }

        [DisplayName("Fecha de la Transaccion")]
        public DateTime? TransactionDate { get; set; }

        [DisplayName("Monto")]
        public decimal Amount { get; set; }

        [DisplayName("Descripcion")]
        public string? Description { get; set; }
    }
}
