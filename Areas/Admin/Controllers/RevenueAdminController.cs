using Sneker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sneker.Areas.Admin.Controllers
{
    public class RevenueAdminController : Controller
    {
        // GET: Admin/RevenueAdmin
        SnekerEntities db = new SnekerEntities();
        // GET: Admin/RevenueAdmin
        public ActionResult Revenue(string search = "")
        {
            List<Order> order = db.Orders.Where(row => row.Shipname.Contains(search)).ToList();
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMg = TempData["result"];
            }
            if (TempData["error"] != null)
            {
                ViewBag.ErrorMg = TempData["error"];
            }
            return View(order);
        }

        public ActionResult Edit(int id)
        {
            var order = db.Orders.Where(row => row.OrderID == id).FirstOrDefault();
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            id = int.Parse(form["orderid"]);
            Order order = db.Orders.Where(row => row.OrderID == id).FirstOrDefault();
            if (order != null)
            {
                order.OrderID = int.Parse(form["orderid"]);
                order.Orderdate = form["orderdate"];
                order.Email = form["email"];
                order.Shipname = form["shipname"];
                order.Shipaddress = form["shipaddress"];
                order.Shipcity = form["shipcity"];
                order.Shipcountry = form["shipcountry"];
                order.Note = form["note"];
                order.Status = form["status"];
                db.SaveChanges();
                TempData["result"] = "Edit Order successfully!";
                return RedirectToAction("Revenue", "RevenueAdmin");
            }
            else
            {
                TempData["error"] = "Edit Order fall !";
                return RedirectToAction("Revenue", "RevenueAdmin");
            }
        }

    }
}
