using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace SIS_FACT_Z3R0.EnviarCorreo
{
    public abstract class ServidorDeEmail
    {
        private SmtpClient client;
        protected string RemitenteEmail { get; set; }
        protected string Password { get; set; }
        protected string Servidor { get; set; }
        protected int Puerto { get; set; }
        protected bool SSL { get; set; }

        protected void InicializacionServidor()
        {
            client = new SmtpClient();
            client.Credentials = new NetworkCredential(RemitenteEmail, Password);
            client.Host = Servidor;
            client.Port = Puerto;
            client.EnableSsl = SSL;
        }

        public void EnviarMensaje(string asunto, string cuerpo, List<string> CorreoDestinatario)
        {
            var MensajeCorreo = new MailMessage();

            try
            {
                MensajeCorreo.From = new MailAddress(RemitenteEmail);
                foreach (string Correo in CorreoDestinatario)
                {
                    MensajeCorreo.To.Add(Correo);
                }
                MensajeCorreo.Subject = asunto;
                MensajeCorreo.Body = cuerpo;
                MensajeCorreo.Priority = MailPriority.Normal;
                MensajeCorreo.IsBodyHtml = true;
                client.Send(MensajeCorreo);
            }
            catch (Exception ex)
            { }
            finally
            {
                MensajeCorreo.Dispose();
                client.Dispose();
            }
        }
    }
}
