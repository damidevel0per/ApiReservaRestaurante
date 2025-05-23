namespace ApiReservas.Models.DTOs
{
    public class CrearReservaDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroInvitados { get; set; }
        public string Email { get; set; }

    }
}
