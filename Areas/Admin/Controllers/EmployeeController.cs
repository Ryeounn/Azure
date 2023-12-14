using Sneker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Sneker.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Admin/Employee
        SnekerEntities db = new SnekerEntities();
        public ActionResult Staff(string search ="")
        {
            List<Employee> employees = db.Employees.Where(row => row.Username.Contains(search)).ToList();
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMg = TempData["result"];
            }
            if (TempData["error"] != null)
            {
                ViewBag.ErrorMg = TempData["error"];
            }
            return View(employees);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string username, string email, FormCollection form, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                username = form["username"];
                email = form["email"];
                var employees = db.Employees.FirstOrDefault(row => row.Username == username && row.Email == email);
                if (employees == null)
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
                    employee.PhotoPath = "/Image/Employee/";
                    employee.Photo = filename;
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    TempData["result"] = "Add Employee successfully!";
                    return RedirectToAction("Staff", "Employee");
                }
                else
                {
                    TempData["error"] = "Add Employee fall because Username already exist!";
                    return RedirectToAction("Staff", "Employee");
                }

            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Employee employees = db.Employees.Where(row => row.EmployeeID == id).FirstOrDefault();
            return View(employees);
        }

        [HttpPost]
        public ActionResult Edit(int id, string email, FormCollection form, HttpPostedFileBase imageFile)
        {
            id = int.Parse(form["employeeid"]);
            var pass = GetMD5(form["password"]);
            email = form["email"];
            Employee employee = db.Employees.Where(row => row.EmployeeID == id && row.Email == email).FirstOrDefault();
            if (employee != null)
            {
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
                employee.PhotoPath = "/Image/Employee/";
                employee.Photo = filename;
                db.SaveChanges();
                TempData["result"] = "Edit Employee successfully!";
                return RedirectToAction("Staff", "Employee");
            }
            else
            {
                TempData["error"] = "Edit Employee fall!";
                return RedirectToAction("Staff", "Employee");
            }
        }

        public ActionResult Delete(int id)
        {
            var employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            TempData["result"] = "Edit Employee successfully!";
            return RedirectToAction("Staff", "Employee");
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