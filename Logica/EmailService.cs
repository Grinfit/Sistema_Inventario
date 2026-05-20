// IMPORTACION DE LIBRERIAS NECESARIAS PARA EL ENVIO DE CORREOS Y CONFIGURACIONES
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Sistema_Inventario.Logica
{
    // CLASE ENCARGADA DEL ENVIO DE ALERTAS POR CORREO ELECTRONICO
    public class EmailService
    {
        // OBTIENE EL CORREO DEL SISTEMA DESDE APP.CONFIG
        private readonly string correoSistema =
            ConfigurationManager
            .AppSettings["CorreoSistema"];

        // OBTIENE LA CONTRASEÑA DEL CORREO
        private readonly string password =
            ConfigurationManager
            .AppSettings["CorreoPassword"];

        // OBTIENE EL CORREO DESTINO DE LAS ALERTAS
        private readonly string correoDestino =
            ConfigurationManager
            .AppSettings["CorreoAlertas"];

        // METODO PARA ENVIAR ALERTAS POR CORREO
        public void EnviarAlerta(
            string asunto,
            string mensaje)
        {
            try
            {
                // FUERZA EL USO DE TLS 1.2
                ServicePointManager.SecurityProtocol =
                    SecurityProtocolType.Tls12;

                // VALIDACION DEL CERTIFICADO SSL
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

                // CREACION DEL OBJETO MAIL
                MailMessage mail =
                    new MailMessage();

                // CORREO REMITENTE
                mail.From =
                    new MailAddress(
                        correoSistema);

                // CORREO DESTINO
                mail.To.Add(
                    correoDestino);

                // ASUNTO DEL CORREO
                mail.Subject =
                    asunto;

                // MENSAJE DEL CORREO
                mail.Body =
                    mensaje;

                // DEFINE SI EL CUERPO ES HTML
                mail.IsBodyHtml =
                    false;

                // CREACION DEL CLIENTE SMTP
                SmtpClient smtp =
    new SmtpClient();

                // SERVIDOR SMTP DE GMAIL
                smtp.Host =
     "smtp.gmail.com";

                // PUERTO SMTP
                smtp.Port =
                    587;

                // HABILITA SSL
                smtp.EnableSsl =
                    true;

                // DESHABILITA CREDENCIALES POR DEFECTO
                smtp.UseDefaultCredentials =
                    false;

                // CREDENCIALES DEL CORREO
                smtp.Credentials =
                    new NetworkCredential(
                        correoSistema,
                        password);

                // METODO DE ENTREGA DEL CORREO
                smtp.DeliveryMethod =
                    SmtpDeliveryMethod.Network;

                // TIEMPO DE ESPERA
                smtp.Timeout =
                    30000;

                // ENVIA EL CORREO
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                // LANZA UNA EXCEPCION SI OCURRE UN ERROR
                throw new Exception(
                    "Error enviando correo: "
                    + ex.Message);
            }
        }
    }
}