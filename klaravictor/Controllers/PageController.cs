using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            rvspService.SaveRvsp(rvsp);
            return View();
        }
    }
}