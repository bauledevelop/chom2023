﻿using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Security;
using MailKit.Net.Smtp;

namespace CHOM.Extensions
{
    public class EmailSender : IEmailSender
    {
        MailSettings _mailSettings { get; set; }
        public EmailSender(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task<bool> SendMail(MailContent mailContent)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailContent.To));
            email.Subject = mailContent.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailContent.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            try
            {
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
                return true;
            }
            catch(Exception ex)
            {
                smtp.Disconnect(true);
                return false;
            }
        }

    }
    public class MailContent
    {
        public string To { set; get; }
        public string Subject { set; get; }
        public string Body { set; get; }
    }
}
