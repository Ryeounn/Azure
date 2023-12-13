using Sneker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Sneker.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Admin/Employee
        SnekerEntities db = new SnekerEntities();
        public ActionResult Staff(string search = " ")
        {
            List<Employee> employees = db.Employees.Where(row => row.Lastname.Contains(search)).ToList();
            return View(employees);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(FormCollection form, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                var employees = db.Employees.Where(row => row.Username != form["username"]);
                if (employees != null)
                {
                    Employee employee = new Employee();
                    var pass = GetMD5(form["password"]);
                    employee.Firstname = form["firstname"];
                    employee.Lastname = form["lastname"];
                    employee.Username = form["username"];
                    employee.Password = pass;
                    employee.Email = form["email"];
                    employee.Phone = form["phone"];
                    employee.Birthday = form["birthday"];
                    employee.Address = form["address"];
                    string filename = employee.Username + ".jpg";
                    string path = Path.Combine(Server.MapPath("/Image/Employee/"), filename);
                    imageFile.SaveAs(path);
                    employee.PhotoPath = "/Content/Image/Product/";
                    employee.Photo = filename;
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    return RedirectToAction("Staff", "Employee");
                }
                else
                {
                    ViewBag.Error = "Product Code already exist";
                    return View();
                }

            }
            else
            {
                return View();
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