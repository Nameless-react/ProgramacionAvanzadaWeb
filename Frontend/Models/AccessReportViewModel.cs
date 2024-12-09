using System;
using System.ComponentModel;

namespace Frontend.Models
{
    public class AccessReportViewModel
    {
        [DisplayName("ID del Reporte")]
        public int AccessReportID { get; set; }

        [DisplayName("ID del Cliente")]
        public int ClientID { get; set; }

        [DisplayName("Fecha de Acceso")]
        public DateTime? AccessDate { get; set; }

        [DisplayName("Dirección IP")]
        public string? IPAddress { get; set; } = null!;

        [DisplayName("Acceso Exitoso")]
        public bool? Success { get; set; }

        [DisplayName("Descripción del Acceso")]
        public string? AccessDescription { get; set; } = null!;

        [DisplayName("Nombre de Usuario")]
        public string UserName { get; set; } = null!;  // Nueva propiedad para el nombre de usuario

        [DisplayName("Tipo de Acceso")]
        public string AccessType { get; set; } = null!;  // Nueva propiedad para el tipo de acceso

        [DisplayName("Detalles")]
        public string Details { get; set; } = null!;  // Nueva propiedad para los detalles
    }
}
