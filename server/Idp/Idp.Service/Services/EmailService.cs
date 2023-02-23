using IDP.Service.Dto;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace IDP.Service.Services
{
    public class EmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _username;
        private readonly string _password;
        private readonly string _toaddress;
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
            _smtpServer = configuration["MailConfig:Server"];
            _smtpPort = int.Parse(configuration["MailConfig:Port"]);
            _username = configuration["MailConfig:Username"];
            _password = configuration["MailConfig:Password"];
            _toaddress = configuration["MailConfig:ToAddress"];

        }

        public void SendEmail(EmailDto emaildto)
        {

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(emaildto.fromAddress));
            email.To.Add(MailboxAddress.Parse(_toaddress));
            email.Subject = emaildto.subject;
            email.Body = new TextPart(TextFormat.Html) { Text = emaildto.body };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_smtpServer, _smtpPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(_username, _password);
                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    }


}

