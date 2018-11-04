using System;
using klaravictor.Extensions;
using klaravictor.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace klaravictor.Services
{
    public class SmtpService : ISmtpService
    {
        public bool SendMail(RvspModel form)
        {
            RvspService rvspService = new RvspService();
            rvspService.ModifiedRvsp();
            var msg = new SendGridMessage();
            if (form.Attending)
            {
                msg = new SendGridMessage()
                {
                    From = new EmailAddress("info@klaravictor.se", "Klara och Victor"),
                    Subject = "Bröllopsbekräftelse!",
                    HtmlContent = "<p> Hej, <br/><br/> " +
                                  "Vad roligt att du vill komma och fira med oss.<br />" +
                                  "Om du önskat boende på FriluftsByn kommer vi återkomma med information kring detta. <br /><br />" +
                                  $"<b>Namn:</b> {form.Name}</br>" +
                                  $"<b>Epost:</b> {form.Email}</br>" +
                                  $"<b>Kommer:</b> {form.Attending.ToSwedish()}</br>" +
                                  $"<b>Boende:</b> {form.Accommondation}</br>" +
                                  $"<b>Antal nätter:</b> {form.NumberOfNights}</br>" +
                                  $"<b>Matinfo:</b> {form.FoodInfo}</br>" +
                                  $"<b>Kommentar:</b> {form.Comment}</br></br>" +
                                       "Kram, <br />" +
                                       "Klara&Victor</p>"

                };
            }

            if (!form.Attending)
            {
                msg = new SendGridMessage()
                {
                    From = new EmailAddress("info@klaravictor.se", "Klara och Victor"),
                    Subject = "Bröllopsbekräftelse!",
                    HtmlContent = "<p>Hej, <br /><br/>" +
                                       "Vad tråkigt att du inte kan komma. <br />" +
                                       "Vi får helt enkelt ses vid ett annat tillfälle. <br /><br/>" +
                                        $"<b>Namn:</b> {form.Name}</br>" +
                                        $"<b>Epost:</b> {form.Email}</br>" +
                                        $"<b>Kommer:</b> {form.Attending.ToSwedish()}</br>" +
                                        $"<b>Kommentar:</b> {form.Comment}</br></br>" +
                                       "Kram, <br />" +
                                       "Klara&Victor</p>"
                };
            }

            try
            {
                var apiKey = System.Environment.GetEnvironmentVariable("SMTP_KEY");
                var client = new SendGridClient(apiKey);
                msg.AddTo(new EmailAddress(form.Email, form.Name));
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