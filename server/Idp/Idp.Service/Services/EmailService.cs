using Idp.services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Idp.services.Services
{
    public class EmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;

        public EmailService(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _smtpUsername = smtpUsername;
            _smtpPassword = smtpPassword;
        }

        public void SendEmail(EmailDto emailDto)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(emailDto.ToAddress);
                if (!string.IsNullOrEmpty(emailDto.CcAddress))
                {
                    message.CC.Add(emailDto.CcAddress);
                }
                message.From = new MailAddress(emailDto.FromAddress);
                message.Subject = emailDto.Subject;
                message.Body = emailDto.Body;
                if (!string.IsNullOrEmpty(emailDto.Attachment))
                {
                    message.Attachments.Add(new Attachment(emailDto.Attachment));
                }

                using (var smtp = new SmtpClient(_smtpServer, _smtpPort))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                }
            }
        }
    }

}

