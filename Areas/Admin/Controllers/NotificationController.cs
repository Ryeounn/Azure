using Sneker.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Sneker.Areas.Admin.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Admin/Notification
        SnekerEntities db = new SnekerEntities();
        public ActionResult Noti(string search="")
        {
            var strings = "Pending";
            List<Order> order = db.Orders.Where(row => row.Status.Contains(search)).ToList();
            List<Order> orders = db.Orders.Where(row => row.Status == strings).ToList();
            dynamic myModel = new ExpandoObject();
            myModel.Tables = order;
            myModel.Notis = orders;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMg = TempData["result"];
            }
            if (TempData["error"] != null)
            {
                ViewBag.ErrorMg = TempData["error"];
            }
            return View(myModel);
        }

        public ActionResult Edit(int id)
        {
            Order order = db.Orders.Where(row => row.OrderID == id).FirstOrDefault();
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            id = int.Parse(form["orderid"]);
            Order order = db.Orders.Where(row => row.OrderID == id).FirstOrDefault();
            if (order != null)
            {
                order.Status = form["status"];
                db.SaveChanges();
                TempData["result"] = "Edit Status successfully!";
                return RedirectToAction("Noti", "Notification");
            }
            else
            {
                TempData["error"] = "Edit Status fall!";
                return RedirectToAction("Noti", "Notification");
            }
        }

        public ActionResult Accept(int id)
        {

            Order order = db.Orders.Where(row => row.OrderID == id).FirstOrDefault();
            if (order != null)
            {
                var status = db.Orders.FirstOrDefault(row => row.OrderID == id);
                if(status != null)
                {
                    status.Status = "Accept";
                    db.SaveChanges();
                    TempData["result"] = "Accept Order!";
                    return RedirectToAction("Noti", "Notification");
                }
            }
            return View();
        }

        public ActionResult Cancel(int id)
        {
            Order order = db.Orders.FirstOrDefault(row => row.OrderID == id);
            if (order != null)
            {
                var status = db.Orders.FirstOrDefault(row => row.OrderID == id);
                if(status != null)
                {
                    order.Status = "Cancel";
                    db.SaveChanges();
                    TempData["error"] = "Cancel Order!";
                    return RedirectToAction("Noti", "Notification");
                }
            }
            return View();
        }
    }
}