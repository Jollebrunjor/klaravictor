namespace klaravictor.Services
{
    public interface ISmtpService
    {
        bool SendMail(string mailto, string user);
    }
}