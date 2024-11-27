using System.ComponentModel;

namespace Frontend.Models
{
    public class ClientViewModel
    {
        [DisplayName("ID")]
        public int ClientId { get; set; }

        [DisplayName("Nombre")]
        public string FirstName { get; set; } = null!;

        [DisplayName("Apellido")]
        public string LastName { get; set; } = null!;

        [DisplayName("Fecha de Nacimiento")]
        public DateOnly? DateOfBirth { get; set; }

        [DisplayName("Telefono")]
        public string? Phone { get; set; }

        [DisplayName("Correo Electronico")]
        public string? Email { get; set; }

        [DisplayName("Direccion")]
        public string? Address { get; set; }

        [DisplayName("Ciudad")]
        public string? City { get; set; }

        [DisplayName("Pais")]
        public string? Country { get; set; }

        [DisplayName("Fecha de Registro")]
        public DateTime? RegistrationDate { get; set; }
    }
}
