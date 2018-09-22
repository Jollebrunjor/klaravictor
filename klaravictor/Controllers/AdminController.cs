using System.Web.Mvc;
using klaravictor.Models;
using klaravictor.Services;

namespace klaravictor.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            RvspService rvspService = new RvspService();

            var rvsp = rvspService.GetRvsp();
            return View(rvsp);
        }
    }
}