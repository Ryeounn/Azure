using Sneker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sneker.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        SnekerEntities db = new SnekerEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("/Users", "Account", new {area = ""});
        }

        public PartialViewResult Avatar()
        {
            string avt = "";
            var employee = Session["UsernameAd"];
            if (employee != null)
                avt = Session["PhotoPath"].ToString() + Session["Photo"].ToString();
                ViewBag.Photo = avt;
                return PartialView("Avatar");
        }

        public PartialViewResult Name()
        {
            string name = "";
            var names = Session["UsernameAd"];
            if(names != null)
               name = Session["FirstName"].ToString()+ " " + Session["LastName"].ToString();
               ViewBag.Name = name;
               return PartialView("Name");
        }

        

    }
}