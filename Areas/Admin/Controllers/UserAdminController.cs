using Sneker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Sneker.Areas.Admin.Controllers
{
    public class UserAdminController : Controller
    {
        // GET: Admin/User
        SnekerEntities db = new SnekerEntities();
        public ActionResult Customer(String search = "")
        {
            List<Customer> customers = db.Customers.Where(row => row.Username.Contains(search)).ToList();
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMg = TempData["result"];
            }
            if (TempData["error"] != null)
            {
                ViewBag.ErrorMg = TempData["error"];
            }
            return View(customers);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(string Username, string email, FormCollection form, HttpPostedFileBase avataFile)
        {
            if (ModelState.IsValid)
            {
                email = form["email"];
                Username = form["username"];
                var customer = db.Customers.FirstOrDefault(row => row.Username == Username && row.Email == email);
                if (customer == null)
                {
                    Customer customeradd = new Customer();
                    customeradd.Username = form["username"];
                    customeradd.Password = form["password"];
                    customeradd.Name = form["name"];
                    customeradd.Email = form["email"];
                    customeradd.Phone = form["phone"];
                    customeradd.DateofBirth = form["date"];
                    customeradd.Address = form["address"];
                    string filename = customeradd.Username + ".jpg";
                    string path = Path.Combine(Server.MapPath("/Content/Image/Customer/"), filename);
                    avataFile.SaveAs(path);
                    customeradd.AvatarPath = "/Content/Image/Customer/";
                    customeradd.Avatar = filename;
                    db.Customers.Add(customeradd);
                    db.SaveChanges();
                    TempData["result"] = "Add Customer successfully!";
                    return RedirectToAction("Customer", "UserAdmin");
                }
                else
                {
                    TempData["error"] = "Add Customer fall because Username already exists!";
                    return RedirectToAction("Customer", "UserAdmin");
                }

            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Customer customer = db.Customers.Where(row => row.CustomerID == id).FirstOrDefault();
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(string Username, string email, FormCollection form, HttpPostedFileBase imageFile)
        {
            email = form["email"];
            Username = form["username"];
            Customer customer = db.Customers.Where(row => row.Username == Username && row.Email == email).FirstOrDefault();
            if (customer != null)
            {
                customer.Username = form["username"];
                customer.Password = form["password"];
                customer.Name = form["name"];
                customer.Email = form["email"];
                customer.Phone = form["phone"];
                customer.DateofBirth = form["date"];
                customer.Address = form["address"];
                string filename = customer.Username + ".jpg";
                string path = Path.Combine(Server.MapPath("/Content/Image/Customer/"), filename);
                imageFile.SaveAs(path);
                customer.AvatarPath = "/Content/Image/Customer/";
                customer.Avatar = filename;
                db.SaveChanges();
                TempData["result"] = "Edit Customer successfully!";
                return RedirectToAction("Customer", "UserAdmin");
            }
            else
            {
                TempData["error"] = "Edit Customer fall!";
                return RedirectToAction("Customer", "UserAdmin");
            }
        }

        public ActionResult Delete(int id)
        {
            var customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            TempData["result"] = "Delete Customer successfully!";
            return RedirectToAction("Customer", "UserAdmin");
        }
    }
}