
using System.ComponentModel;


namespace Frontend.Models
{
    public class EmployeeViewModel
    {

        [DisplayName("ID")]
        public int EmployeeID { get; set; }

        [DisplayName("Nombre")]
        public string FirstName { get; set; } = null!;

        [DisplayName("Apellido")]
        public string LastName { get; set; }

        [DisplayName("Cedula")]
        public string IDNumber { get; set; }

        [DisplayName("Numero de Telefono")]
        public string Phone { get; set; }

        [DisplayName("Direccion")]
        public string Address { get; set; }

        [DisplayName("Correo Electronico")]
        public string Email { get; set; }

        [DisplayName("Fecha de Contratacion")]
        public DateOnly? HireDate { get; set; }

        [DisplayName("Posicion de Trabajo")]
        public string Position { get; set; }
    }
}
