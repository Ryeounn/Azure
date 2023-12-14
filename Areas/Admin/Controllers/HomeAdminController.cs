using Sneker.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Sneker.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        SnekerEntities db = new SnekerEntities();
        public ActionResult Index(string search="")
        {
            List<Order> orders = db.Orders.Where(row => row.Shipname.Contains(search)).ToList();
            return View(orders);
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
                avt = Session["PhotoPath"] + Session["Photo"].ToString();
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

        public ActionResult Information()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMg = TempData["result"];
            }
            if (TempData["error"] != null)
            {
                ViewBag.ErrorMg = TempData["error"];
            }
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string current, Employee employee, string newp)
        {
            var user = Session["UsernameAd"].ToString();
            var Pass = GetMD5(current);
            var NewPass = GetMD5(newp);

            //var fpassword = GetMD5(Password);
            var data = db.Employees.Where(s => s.Username == user && s.Password == Pass);
            if (data != null)
            {

                var admin = db.Employees.Where(s => s.Username == user && s.Password == NewPass).FirstOrDefault();
                if (admin == null)
                {
                    var adminedit = db.Employees.FirstOrDefault(s => s.Username == user);
                    adminedit.Password = NewPass;
                    db.SaveChanges();
                    TempData["result"] = "Change Password successfully!";
                    return RedirectToAction("Information","HomeAdmin");
                }
                else
                {
                    TempData["error"] = "Change Password fall because Current Password match New Password!";
                    return RedirectToAction("Information", "HomeAdmin");
                }
            }

            else
            {
                return View();

            }
        }

        public ActionResult General()
        {
            int id = int.Parse(Session["EmployeeID"].ToString());
            Employee employee = db.Employees.Where(row => row.EmployeeID == id).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        public ActionResult General(FormCollection form, HttpPostedFileBase imageFile)
        {
            int id = int.Parse(Session["EmployeeID"].ToString());
            Employee employee = db.Employees.Where(row => row.EmployeeID == id).FirstOrDefault();
            if (employee != null)
            {
                employee.Firstname = form["firstname"];
                employee.Lastname = form["lastname"];
                employee.Username = form["username"];
                employee.Email = form["email"];
                employee.Phone = form["phone"];
                employee.Birthday = form["birthday"];
                employee.Address = form["address"];
                string filename = employee.Username + ".jpg";
                string path = Path.Combine(Server.MapPath("/Content/Image/Employee/"), filename);
                imageFile.SaveAs(path);
                employee.PhotoPath = "/Content/Image/Employee/";
                employee.Photo = filename;
                db.SaveChanges();
                TempData["result"] = "Update Information successfully!";
                return RedirectToAction("Information", "HomeAdmin");
            }
            else
            {
                TempData["error"] = "Update Information fall!";
                return RedirectToAction("Information", "HomeAdmin");
            }
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }


    }
}