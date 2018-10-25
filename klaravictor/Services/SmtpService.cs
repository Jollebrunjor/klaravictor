using System;
using System.Net;
using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace klaravictor.Services
{
    public class SmtpService : ISmtpService
    {
        public bool SendMail(string mailto, string user)
        {
            try
            {
                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress("info@klaravictor.se", "Klara och Victor"),
                    Subject = "Bröllopsbekräftelse!",
                    PlainTextContent = $"Hej hej {user} du är anmäld!",
                    
                };
                msg.AddTo(new EmailAddress(mailto, user));
               client.SendEmailAsync(msg);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}