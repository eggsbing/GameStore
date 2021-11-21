using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Senders.Mail
{
    public class SendEmail : IMailSender
    {
        public void Send(string to, string subject, string body)
        {
            var defaultEmail = new
            {
                SMTP = "",
                From = "",
                DisplayName = "Game Store",
                Port = 25,
                UserName = "",
                Password = "",
                EnableSSL = false
            };

            var mail = new MailMessage();

            var SmtpServer = new SmtpClient(defaultEmail.SMTP);

            mail.From = new MailAddress(defaultEmail.From, defaultEmail.DisplayName);

            mail.To.Add(to);

            mail.Subject = subject;

            mail.Body = body;

            mail.IsBodyHtml = true;

            // System.Net.Mail.Attachment attachment;
            // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            // mail.Attachments.Add(attachment);

            SmtpServer.Port = defaultEmail.Port;

            SmtpServer.Credentials = new System.Net.NetworkCredential(defaultEmail.UserName, defaultEmail.Password);

            SmtpServer.EnableSsl = defaultEmail.EnableSSL;

            SmtpServer.Send(mail);
        }
    }
}
