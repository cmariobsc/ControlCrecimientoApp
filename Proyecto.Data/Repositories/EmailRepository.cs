using System;
using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Repositories;
using Proyecto.Core.Models;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace Bg.NeoTrack.Data.Repositories
{
    public class EmailRepository : IEmailRepository, IRepository
    {
        public bool SendEmail(Email email, out string codError, out string mensajeRetorno)
        {
            var response = false;

            var AplicacionName = ConfigurationManager.AppSettings["AplicacionName"];
            var SmtpHost = ConfigurationManager.AppSettings["SmtpHost"];
            var SmtpPort = ConfigurationManager.AppSettings["SmtpPort"];
            var EmailApp = ConfigurationManager.AppSettings["EmailApp"];
            var EmailPassApp = ConfigurationManager.AppSettings["EmailPassApp"];

            var fromAddress = new MailAddress(EmailApp, AplicacionName);
            var toAddress = new MailAddress(email.EmailDestinatario, email.NombreDestinatario);

            try
            {
                var smtp = new SmtpClient
                {
                    Host = SmtpHost,
                    Port = Convert.ToInt32(SmtpPort),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, EmailPassApp)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = email.Asunto,
                    Body = email.Cuerpo
                })
                {
                    message.IsBodyHtml = true;
                    smtp.Send(message);
                }

                codError = "000";
                mensajeRetorno = "Email enviado correctamente, dentro de poco el doctor se pondrá en contacto con usted";

                response = true;
            }
            catch (Exception exception)
            {
                response = false;
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return response;
        }
    }
}
