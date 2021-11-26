using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Mail;
using WordVision.ec.Application.DTOs.Settings;
using WordVision.ec.Application.Interfaces.Shared;

namespace WordVision.ec.Infrastructure.Shared.Services
{
    public class SMTPMailService : IEmailSender
    {
        public MailSettings _mailSettings { get; }
        public ILogger<SMTPMailService> _logger { get; }

        public SMTPMailService(IOptions<MailSettings> mailSettings, ILogger<SMTPMailService> logger)
        {
            _mailSettings = mailSettings.Value;
            _logger = logger;
        }

        public async Task SendAsync(MailRequest request)
        {
            try
            {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(request.From ?? _mailSettings.From);
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = request.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.UserName, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            throw new System.NotImplementedException();
        }

        public Task SendEmailAsync(string email, string subject, string message, List<System.Net.Mail.Attachment> adjunto)
        {
            throw new System.NotImplementedException();
        }

        public Task SendEmailAsync(string email, string subject, string message, string copia)
        {
            throw new System.NotImplementedException();
        }
    }
}