using System;
using System.Net;
using System.Net.Mail;

namespace klaravictor.Services
{
    public class SmtpService : ISmtpService
    {
        public bool SendMail(string mailto)
        {
            try
            {
                //  1.Login to your gmail account.
                // 2.Visit this page https://accounts.google.com/DisplayUnlockCaptcha and click on button to allow access.
                //3.Visit this page https://www.google.com/settings/security/lesssecureapps and enable access for less secure apps.
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("klaravictor@gmail.com", "password"),
                    EnableSsl = true
                };
                client.Send("joakim.wagstrom@gmail.com", mailto, "test", "testbody");

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}