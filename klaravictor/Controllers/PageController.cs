using System.Web.Mvc;
using klaravictor.Models;
using klaravictor.Services;

namespace klaravictor.Controllers
{
    public class PageController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(RvspModel rvsp)
        {
            RvspService rvspService = new RvspService();
            bool success = rvspService.SaveRvsp(rvsp);
            if (!success)
            {
                TempData["rvsp"] = "Något blev fel. Försök igen";
                return new RedirectResult(Url.Action("Index") + "#rvsp");
            }

            TempData["rvsp"] = $"Bra jobbat! Ett bekräftelsemail skickas till {rvsp.Email}.";

            return new RedirectResult(Url.Action("Index") + "#rvsp");
        }
    }
}