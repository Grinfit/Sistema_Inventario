using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

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
                // ============================================
                // FORZAR TLS 1.2
                // ============================================

                ServicePointManager.SecurityProtocol =
                    SecurityProtocolType.Tls12;

                // ============================================
                // VALIDACION SSL
                // ============================================

                ServicePointManager
                    .ServerCertificateValidationCallback =
                    delegate (
                        object sender,
                        X509Certificate certificate,
                        X509Chain chain,
                        SslPolicyErrors sslPolicyErrors)
                    {
                        return true;
                    };

                // ============================================
                // EMAIL
                // ============================================

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

                // ============================================
                // SMTP
                // ============================================

                SmtpClient smtp =
    new SmtpClient();

                smtp.Host =
     "smtp.gmail.com";

                smtp.Port =
                    587;

                smtp.EnableSsl =
                    true;

                smtp.UseDefaultCredentials =
                    false;

                smtp.Credentials =
                    new NetworkCredential(
                        correoSistema,
                        password);

                smtp.DeliveryMethod =
                    SmtpDeliveryMethod.Network;

                smtp.Timeout =
                    30000;

                // ============================================
                // SEND
                // ============================================

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