using MailKit.Net.Smtp;
using MimeKit;
using Portafolio.Models;

namespace Portafolio.Services
{
    public interface IServicioEmail
    {
        Task Enviar(ContactoViewModel contacto);
    }

    public class ServicioEmail: IServicioEmail
    {
        private readonly IConfiguration configuration;

        public ServicioEmail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Enviar(ContactoViewModel contacto)
        {
            var nombre = configuration.GetValue<string>("SEND_NOMBRE");
            var email = configuration.GetValue<string>("SEND_TO");

            string server = "smtp.gmail.com";
            int port = 587;

            string gmailUser = configuration.GetValue<string>("GMAIL_USER");
            string gmailPass = configuration.GetValue<string>("PASS_APP");

            MimeMessage message = new();
            message.From.Add(new MailboxAddress("Mensajería de Contacto", gmailUser));
            message.To.Add(new MailboxAddress(nombre, email));
            message.Subject = "Formulario de Contacto";

            BodyBuilder builder = new();
            string text = string.Empty;

            //Invocar el Path con el metodo adecuado, segun el tipo de aplicacion
            using (StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\plantilla.html"))
            {
                text = reader.ReadToEnd();
            }

            text = text.Replace("{Nombre}", contacto.Nombre);
            text = text.Replace("{Email}", contacto.Email);
            text = text.Replace("{Mensaje}", contacto.Mensaje);

            builder.HtmlBody = text;
            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.CheckCertificateRevocation = false;
                client.Connect(server, port, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate(gmailUser, gmailPass); //Es necesario generar un password de aplicacion: Cuenta de Google\Seguridad\Contraseña de Aplicaciones
                var response = await client.SendAsync(message);
                client.Disconnect(true);
            }
        }
    }
}
