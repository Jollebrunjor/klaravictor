using System.Data.Entity;
using klaravictor.Models;

namespace klaravictor.Services
{
    public interface IRvspService
    {
        bool SaveRvsp(RvspModel rvsp);
        bool DeleteRvsp(RvspModel rvsp);
        DbSet<RvspModel> GetRvsp();
    }
}