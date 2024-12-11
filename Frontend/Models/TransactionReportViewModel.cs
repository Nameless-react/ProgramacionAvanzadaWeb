using System.ComponentModel;

namespace Frontend.Models
{
    public class TransactionReportViewModel
    {
        [DisplayName("ID")]
        public int TransactionReportId { get; set; }

        [DisplayName("ID Cuenta")]
        public int AccountId { get; set; }

        [DisplayName("ID Generador")]
        public int? GeneratorId { get; set; }

        [DisplayName("Fecfha de Inicio")]
        public DateTime? StartDate { get; set; }

        [DisplayName("Fecha Fin")]
        public DateTime? EndDate { get; set; }

        [DisplayName("Monto Total")]
        public decimal? TotalAmount { get; set; }

        [DisplayName("Cantidad Transacciones")]
        public int? TransactionCount { get; set; }
    }
}
