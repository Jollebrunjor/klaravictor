using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using klaravictor.Services;

namespace klaravictor.Controllers
{
    public class AdminController : Controller
    {
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            string userName = WebConfigurationManager.AppSettings["LoginUserName"];
            string userPassword = WebConfigurationManager.AppSettings["LoginPassword"];

            bool validUser = password == userPassword && username == userName;

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
            try
            {
                if (requestCookie == null || requestCookie.Value != Session["AuthID"].ToString()) return View("Index");
            }
            catch
            {
                return View("Index");
            }
            var rvspService = new RvspService();
            var rvsp = rvspService.ModifiedRvsp();
            return View(rvsp);
        }
        public ActionResult ExportToExcel()
        {
            var rvspService = new RvspService();
           var ds = rvspService.ModifiedRvsp();

            var data = from s in ds 
                select new
                {
                    s.Namn,
                    s.Email,
                    s.Kommer,
                    s.Boende,
                    s.AntalNätter,
                    s.MatInfo,
                    s.Kommentar,
                };

            var list = data.ToList();
            var grid = new GridView();
            grid.DataSource = list;
            grid.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Bröllop_OSA.xls");
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grid.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();

            return View("Index", ds);
        }
    }
}