using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Mail;

namespace WordVision.ec.Application.Interfaces.Shared
{
    public interface IEmailSender
    {
        Task SendAsync(MailRequest request);
        Task SendEmailAsync(string email, string subject, string message);

        Task SendEmailAsync(string email, string subject, string message, List<Attachment> adjunto);
        Task SendEmailAsync(string email, string subject, string message,string copia);
    }
}
