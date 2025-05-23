using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiReservas.Data;
using ApiReservas.Models;
using ApiReservas.Services;
using ApiReservas.Models.DTOs;

namespace ApiReservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly MySqlDataAccess _dataAccess;

        private readonly IServicioEmail _servicioEmail;
        public ReservasController(MySqlDataAccess dataAccess, IServicioEmail servicioEmail)
        {
            _dataAccess = dataAccess;
            _servicioEmail = servicioEmail;
        }

        [HttpGet]
        [Route("ListaDeReservas")]
        public IActionResult ListarReservas()
        {
            var reservas = _dataAccess.GetReservas();
            return Ok(reservas);
        }

        [HttpGet("Hoy")]
        
        public IActionResult ListarReservasActuales()
        {
            var reservas = _dataAccess.GetReservasToday();
            return Ok(reservas);
        }

        [HttpPost]
        [Route("CrearReserva")]
        public IActionResult CrearReserva([FromBody] CrearReservaDTO reservaDto)
        {
            var nuevaReserva = new Reserva
            {
                Nombre = reservaDto.Nombre,
                Apellido = reservaDto.Apellido,
                DNI = reservaDto.DNI,
                Fecha = reservaDto.Fecha,
                NumeroInvitados = reservaDto.NumeroInvitados,
                Email = reservaDto.Email
            };

            _dataAccess.PostReserva(nuevaReserva);

                var mensajeConfirmacion = $@"
¡Hola {nuevaReserva.Nombre}!

Gracias por realizar una reserva en nuestro restaurante.

Detalles de tu reserva:
- Nombre: {nuevaReserva.Nombre} {nuevaReserva.Apellido}
- Código de reserva: {nuevaReserva.DNI}
- Fecha: {nuevaReserva.Fecha:yyyy-MM-dd}
- Número de invitados: {nuevaReserva.NumeroInvitados}

¡Te esperamos con muchas ganas!

Saludos,  
Restaurante .NET

--------------------------------------------------  
Este correo es una confirmación automática. No respondas a este mensaje.
";

                _servicioEmail.EnviarMailConfirmacion(nuevaReserva.Email.ToString(), "Confirmacion de reserva", mensajeConfirmacion);



            return Ok(new { Message = "Reserva creada con éxito", Fecha = nuevaReserva.FechaSolo });
        }

    }
}
