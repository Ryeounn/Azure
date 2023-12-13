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

namespace Sneker.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public SnekerEntities db = new SnekerEntities();
        public ActionResult Users()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, Customer customer, Employee employee)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var customerdata = db.Customers.Where(s => s.Username == customer.Username && s.Password.Equals(f_password));
                var employeedata = db.Employees.Where(s => s.Username == employee.Username && s.Password.Equals(f_password));
                if (customerdata.Count() > 0)
                {
                    //add session
                    Session["Name"] = customerdata.FirstOrDefault().Name;
                    Session["Email"] = customerdata.FirstOrDefault().Email;
                    Session["CustomerID"] = customerdata.FirstOrDefault().CustomerID;
                    Session["Phone"] = customerdata.FirstOrDefault().Phone;
                    Session["Address"] = customerdata.FirstOrDefault().Address;
                    Session["DateofBirth"] = customerdata.FirstOrDefault().DateofBirth;
                    Session["Avatar"] = customerdata.FirstOrDefault().Avatar;
                    Session["Password"] = f_password;
                    Session["Username"] = customerdata.FirstOrDefault().Username;
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else if (employeedata.Count() > 0)
                {
                    //add session
                    Session["FirstName"] = employeedata.FirstOrDefault().Firstname;
                    Session["LastName"] = employeedata.FirstOrDefault().Lastname;
                    Session["Email"] = employeedata.FirstOrDefault().Email;
                    Session["EmployeeID"] = employeedata.FirstOrDefault().EmployeeID;
                    Session["PhoneAd"] = employeedata.FirstOrDefault().Phone;
                    Session["AddressAd"] = employeedata.FirstOrDefault().Address;
                    Session["Birthday"] = employeedata.FirstOrDefault().Birthday;
                    Session["Photo"] = employeedata.FirstOrDefault().Photo;
                    Session["PhotoPath"] = employeedata.FirstOrDefault().PhotoPath;
                    Session["PasswordAd"] = f_password;
                    Session["UsernameAd"] = employeedata.FirstOrDefault().Username;
                    //return View("~/Areas/Admin/Views/HomeAdmin/Index.cshtml");
                    return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Users");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Users", "Account");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            var check = db.Customers.Where(row => row.Email == email);
            if (check != null)
            {
                Session["Reset"] = email;
                return RedirectToAction("Change", "Account");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Change()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Change(string password, string confirm)
        {
            var email = Session["Reset"].ToString();
            var pass = GetMD5(password);
            var cpass = GetMD5(confirm);
            var check = db.Customers.Where(row => row.Password != pass && pass == cpass);
            if (check != null)
            {
                var cus = db.Customers.Where(s => s.Email == email).FirstOrDefault();
                if (cus != null)
                {
                    var customeredit = db.Customers.FirstOrDefault(s => s.Email == email);
                    customeredit.Password = pass;
                    db.SaveChanges();
                    return View("Users");
                }
                else
                {
                    return View("Users");
                }
            }

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var check = db.Customers.FirstOrDefault(s => s.Username == customer.Username && s.Email == customer.Email);
                if (check == null)
                {
                    customer.Password = GetMD5(customer.Password);
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    return RedirectToAction("Users", "Account");

                }
                else
                {
                    ViewBag.error = "Username already exists";
                    return View();
                }
            }
            return View();
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

        public ActionResult Information()
        {
            return View();
        }

        public ActionResult General()
        {
            var user = Session["Username"].ToString();
            Customer customer = db.Customers.Where(s => s.Username == user).FirstOrDefault();
            return View(customer);
        }

        [HttpPost]
        public ActionResult General(Customer customer, HttpPostedFileBase imageFiles)
        {
            if (ModelState.IsValid)
            {
                var user = Session["Username"].ToString();
                var data = db.Customers.FirstOrDefault(s => s.Username == user);
                if (data != null)
                {
                    Customer customeredit = db.Customers.Where(row => row.Username == user).FirstOrDefault();
                    customeredit.Name = customer.Name;
                    customeredit.Email = customer.Email;
                    customeredit.Address = customer.Address;
                    customeredit.DateofBirth = customer.DateofBirth;
                    customeredit.Phone = customer.Phone;
                    customeredit.AvatarPath = "/Image/Customer/";
                    string filename = customeredit.Username + ".jpg";
                    string path = Path.Combine(Server.MapPath("/Image/Customer/"), filename);
                    imageFiles.SaveAs(path);
                    customeredit.Avatar = filename;
                    db.SaveChanges();
                    return RedirectToAction("Information", "Account");
                }
                else
                {
                    return RedirectToAction("Information", "Account");
                }
            }
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string Password, Customer customer, string New)
        {
            var user = Session["Username"].ToString();
            var Pass = GetMD5(Password);
            var NewPass = GetMD5(New);

            //var fpassword = GetMD5(Password);
            var data = db.Customers.Where(s => s.Username == user && s.Password == Pass);
            if (data != null)
            {

                var cus = db.Customers.Where(s => s.Username == user && s.Password == NewPass).FirstOrDefault();
                if (cus == null)
                {
                    var customeredit = db.Customers.FirstOrDefault(s => s.Username == user);
                    customeredit.Password = NewPass;
                    db.SaveChanges();
                    return View("Information");
                }
                else
                {
                    return RedirectToAction("Information");

                }
            }

            else
            {
                return View("Login");

            }
        }

    }
}