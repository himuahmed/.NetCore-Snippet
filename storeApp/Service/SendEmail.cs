using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using storeApp.Models;

namespace storeApp.Service
{
    public class SendEmail
    {
        private const string emailTemplatePath = @"EmailTemplate/{0}.html";
        private readonly SMTPConfigModel _smtpConfig;

        public SendEmail(IOptions<SMTPConfigModel> smtpConfig )
        {
            _smtpConfig = smtpConfig.Value;
        }
        public async Task SendEmails(EmailOptions emailOptions)
        {
            MailMessage mail = new MailMessage()
            {
                Subject = emailOptions.Subject,
                Body = emailOptions.Body,
                From = new MailAddress(_smtpConfig.SenderAddress, _smtpConfig.SenderDisplayName),
                IsBodyHtml = _smtpConfig.IsBodyHtml
            };

            foreach (var receiver in emailOptions.EmailReceivers)
            {
                mail.To.Add(receiver);
            }

            NetworkCredential networkCredential = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password);

            SmtpClient smtpClient = new SmtpClient()
            {
                Host = _smtpConfig.Host,
                Port = _smtpConfig.Port,
                EnableSsl = _smtpConfig.EnableSSL,
                UseDefaultCredentials = _smtpConfig.UseDefaultCredential,
                Credentials = networkCredential,
            };

            mail.BodyEncoding = Encoding.Default;
            await smtpClient.SendMailAsync(mail);
        }

        private string GetEmailBody(string emailTemplate)
        {
            var body = File.ReadAllText(string.Format(emailTemplatePath,emailTemplate));
            return body;
        }

    }
}
