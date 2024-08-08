using System.Net.Mail;
using System.Net;
using ZischeWeb.ContractsService.Abstraction;
using ZischeWeb.Shared.Models;
using Microsoft.Extensions.Options;

namespace ZischeWeb.ContractsService.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task<bool> SendEmailAsync(string email)
        {
            try
            {
                using var smtpClient = new SmtpClient(_smtpSettings.Host)
                {
                    Port = _smtpSettings.Port,
                    Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpSettings.Username),
                    Subject = "Thank you for subscribing!",
                    Body = "Welcome to our newsletter!",
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
