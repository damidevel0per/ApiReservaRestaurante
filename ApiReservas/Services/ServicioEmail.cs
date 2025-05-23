﻿using System.Net;
using System.Net.Mail;

namespace ApiReservas.Services
{
    public interface IServicioEmail
    {
        Task EnviarMailConfirmacion(string emailReceptor, string tema, string cuerpo);
    }

    public class ServicioEmail : IServicioEmail
    {
        public readonly IConfiguration configuration;
        public ServicioEmail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task EnviarMailConfirmacion(string emailReceptor, string tema, string cuerpo)
        {
            var emailEmisor = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:EMAIL");
            var password = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:PASSWORD");
            var host = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:HOST");
            var puerto = configuration.GetValue<int>("CONFIGURACIONES_EMAIL:PUERTO");

            var smtpCliente = new SmtpClient(host, puerto);
            smtpCliente.EnableSsl = true;
            smtpCliente.UseDefaultCredentials = false;

            smtpCliente.Credentials = new NetworkCredential(emailEmisor, password);
            var mensaje = new MailMessage(emailEmisor!, emailReceptor, tema, cuerpo);
            await smtpCliente.SendMailAsync(mensaje);

        }
    }
}
