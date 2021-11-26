using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Mail;
using WordVision.ec.Application.Interfaces.Shared;

namespace WordVision.ec.Web.Services.Email
{
    public class EmailSender : IEmailSender
    {
        private SmtpClient Cliente { get; }
        private EmailSenderOptions Options { get; }

        public EmailSender(IOptions<EmailSenderOptions> options)
        {
            Options = options.Value;
            Cliente = new SmtpClient()
            {
                Host = Options.Host,
                Port = Options.Port,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Options.Email, Options.Password),
                EnableSsl = Options.EnableSsl,
            };
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var correo = new MailMessage(from: Options.Email, to: email, subject: subject, body: message);
            correo.IsBodyHtml = true;
            if (Options.Copia.Length != 0)
                correo.CC.Add(Options.Copia);
            return Cliente.SendMailAsync(correo);
        }
        public Task SendEmailAsync(string email, string subject, string message, List<Attachment> adjunto)
        {
            var correo = new MailMessage(from: Options.Email, to: email, subject: subject, body: message);
            for (int i = 0; i <= adjunto.Count - 1; i++)
            {
                correo.Attachments.Add(adjunto[i]);
            }
            if (Options.Copia.Length != 0)
                correo.CC.Add(Options.Copia);
            correo.IsBodyHtml = true;
            return Cliente.SendMailAsync(correo);
        }

        public Task SendEmailAsync(string email, string subject, string message, string copia)
        {
            var correo = new MailMessage(from: Options.Email, to: email, subject: subject, body: message);

            if (copia.Length != 0)
                correo.CC.Add(copia);
            correo.IsBodyHtml = true;
            return Cliente.SendMailAsync(correo);
        }

        public Task SendAsync(MailRequest request)
        {
            var correo = new MailMessage(from: request.From, to: request.To, subject: request.Subject, body: request.Body);
            correo.IsBodyHtml = true;
            if (Options.Copia.Length != 0)
                correo.CC.Add(Options.Copia);
            return Cliente.SendMailAsync(correo);
        }
    }
}
