using System.ComponentModel;

namespace Frontend.Models
{
    public class ClientViewModel
    {
        [DisplayName("ID")]
        public int ClientId { get; set; }

        [DisplayName("Nombre de Usuario")]
        public string UserName { get; set; } = null!;

        [DisplayName("Numero de telefono")]
        public string PhoneNumber { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; } = null!;

    }
}
