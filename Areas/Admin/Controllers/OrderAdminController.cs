using Sneker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Sneker.Areas.Admin.Controllers
{
    public class OrderAdminController : Controller

    {
        // GET: Admin/OrderAdmin
        SnekerEntities db = new SnekerEntities();
        public ActionResult Order(String search = "")
        {
            List<Order> orders = db.Orders.Where(row => row.Shipname.Contains(search)).ToList();
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMg = TempData["result"];
            }
            if (TempData["error"] != null)
            {
                ViewBag.ErrorMg = TempData["error"];
            }
            return View(orders);
        }

        public ActionResult Edit(int ID)
        {
            Order orders = db.Orders.Where(row => row.OrderID == ID).FirstOrDefault();
            return View(orders);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            id = int.Parse(form["ID"]);
            Order orders = db.Orders.Where(row => row.OrderID == id).FirstOrDefault();
            if (orders != null)
            {
                orders.Orderdate = form["orderdate"];
                orders.Email = form["email"];
                orders.Phone = form["phone"];
                orders.Shipname = form["shipname"];
                orders.Shipaddress = form["shipaddress"];
                orders.Shipcity = form["shipcity"];
                orders.Shipcountry = form["shipcountry"];
                orders.Note = form["note"];
                orders.Status = form["status"];
                db.SaveChanges();
                TempData["result"] = "Edit Order successfully!";
                return RedirectToAction("Order", "OrderAdmin");
            }
            else
            {
                TempData["error"] = "Edit Order fall!";
                return RedirectToAction("Order", "OrderAdmin");
            }
        }
    }
}

