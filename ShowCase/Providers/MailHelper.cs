using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using ShowCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ShowCase.Providers
{
    public class MailHelper : IMailHelper
    {
        IConfiguration _configuration;
        private readonly MailSettings _mailSettings;
        public MailHelper(IConfiguration configuration, IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
            _configuration = configuration;
        }

        
        public async Task SendEmailAsync(string to, string subject, string content)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("mail.ShowCase.com", 25);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                smtpClient.PickupDirectoryLocation = @"C:\Email";

                MailMessage message = new MailMessage();
                message.From = new MailAddress(_mailSettings.Email, _mailSettings.DisplayName);
                message.To.Add(new MailAddress(to));
                message.IsBodyHtml = true;
                message.Body = content;

                await smtpClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}


//var message = new MimeMessage();
//message.From.Add(new MailboxAddress("ShowCase", "admin@showcase.com"));
//message.To.Add(new MailboxAddress(to, to));
//message.Subject = subject;
//message.Body = new TextPart("html") { Text = content };

//var smtpClient = new MailKit.Net.Smtp.SmtpClient();
//smtpClient.Connect("mail.ShowCase.com", 25);

//var email = new MimeMessage
//{
//    Sender = MailboxAddress.Parse(_mailSettings.Email),
//    Subject = subject
//};

//email.To.Add(MailboxAddress.Parse("salim.yahya89@gmail.com"));
//email.Body = new TextPart("html") { Text = content };

//using var client = new MailKit.Net.Smtp.SmtpClient();
//client.Connect(_mailSettings.Host, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
//client.Authenticate(_mailSettings.Email, _mailSettings.Password);
//client.Send(email);
//client.Disconnect(true);

//string fromAddress = _configuration["SmtpConfig:FromAddress"];
//string serverAddress = _configuration["SmtpConfig:ServerAddress"];
//string username = _configuration["SmtpConfig:Username"];
//string password = _configuration["SmtpConfig:Password"];
//int port = Convert.ToInt32(_configuration["SmtpConfig:Port"]);
//bool isUseSsl = Convert.ToBoolean(_configuration["SmtpConfig:IsUseSsl"]);

