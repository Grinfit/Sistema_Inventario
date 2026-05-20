using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Sistema_Inventario.Logica
{
    public class EmailService
    {
        private readonly string correoSistema =
            ConfigurationManager
            .AppSettings["CorreoSistema"];

        private readonly string password =
            ConfigurationManager
            .AppSettings["CorreoPassword"];

        private readonly string correoDestino =
            ConfigurationManager
            .AppSettings["CorreoAlertas"];

        public void EnviarAlerta(
            string asunto,
            string mensaje)
        {
            try
            {
                MailMessage mail =
                    new MailMessage();

                mail.From =
                    new MailAddress(
                        correoSistema);

                mail.To.Add(
                    correoDestino);

                mail.Subject =
                    asunto;

                mail.Body =
                    mensaje;

                mail.IsBodyHtml =
                    false;

                SmtpClient smtp =
                    new SmtpClient(
                        "smtp.gmail.com",
                        587);

                smtp.Credentials =
                    new NetworkCredential(
                        correoSistema,
                        password);

                smtp.EnableSsl =
                    true;

                smtp.DeliveryMethod =
                    SmtpDeliveryMethod.Network;

                smtp.UseDefaultCredentials =
                    false;

                smtp.Timeout =
                    20000;

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error enviando correo: "
                    + ex.Message);
            }
        }
    }
}