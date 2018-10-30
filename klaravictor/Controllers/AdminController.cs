using System;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using klaravictor.Models;
using klaravictor.Services;

namespace klaravictor.Controllers
{
    public class AdminController : Controller
    {

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            bool validUser = password == "password" && username == "user";

            if (!validUser) return RedirectToAction("Index", "Page");

            string authId = Guid.NewGuid().ToString();

            Session["AuthID"] = authId;

            var cookie = new HttpCookie("AuthID");
            cookie.Value = authId;
            Response.Cookies.Add(cookie);

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var requestCookie = Request.Cookies["AuthID"];
            if (requestCookie != null && requestCookie.Value == Session["AuthID"].ToString())
                {
                    RvspService rvspService = new RvspService();

                    var rvsp = rvspService.GetRvsp();
                    return View(rvsp);
                }

                return View("Index");
        }


    }
}