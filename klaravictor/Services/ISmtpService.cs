using klaravictor.Models;

namespace klaravictor.Services
{
    public interface ISmtpService
    {
        bool SendMail(RvspModel form);
    }
}