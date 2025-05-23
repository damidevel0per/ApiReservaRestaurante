using System.Text.Json.Serialization;

namespace ApiReservas.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public int NumeroInvitados { get; set; }
        public DateTime Fecha { get; set; }

        [JsonIgnore]
        public DateTime FechaCompleta => Fecha;

        public string FechaSolo => Fecha.ToString("dd-MM-yyyy");
    }
}
