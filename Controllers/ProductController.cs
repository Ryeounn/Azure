using Sneker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sneker.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        SnekerEntities db = new SnekerEntities();
        public ActionResult Shoes(int id = 0)
        {
            int search = (int)id;
            if (search == 0)
            {
                List<Product> products = db.Products.ToList();
                return View(products);
            }
            else
            {
                List<Product> products = db.Products.Where(row => row.CaterogyID == search).ToList();
                return View(products);
            }
        }

        public ActionResult Search(int id = 0)
        {
            int search = (int)id;
            if (search == 0)
            {
                List<Product> products = db.Products.ToList();
                return View(products);
            }
            else
            {
                List<Product> products = db.Products.Where(row => row.CaterogyID == search).ToList();
                return View(products);
            }
        }

        public ActionResult Details(int id)
        {
            var products = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(products);
        }

        public ActionResult Choosing()
        {
            return View();
        }

        public ActionResult Service()
        {
            return View();
        }

        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        [HttpGet]
        public ActionResult AddtoCart(int ID)
        {
            var product = db.Products.SingleOrDefault(s => s.ProductID == ID);
            if(product != null)
            {
                GetCart().Add(product);
                Session["Quantity"] = ID;
            }
            return RedirectToAction("Order", "Product");
        }

        public ActionResult Order()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Order", "Product");
            }
            Cart cart = Session["Cart"] as Cart;

            return View(cart);
        }

        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id = int.Parse(form["ProductID"]);

            int quantity = int.Parse(form["Quantity"]);

            cart.Update_Quantity_Shopping(id, quantity);
            return RedirectToAction("Order", "Product");
        }

        public ActionResult Delete(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("Order", "Product");
        }

        public PartialViewResult BagCart()
        {
            int total_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if(cart != null)
                total_item = cart.Total_Quantity_in_Cart();
                ViewBag.QuantityCart = total_item;
                return PartialView("BagCart");
        }

        public PartialViewResult BagCartTotal()
        {
            int total_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
                total_item = cart.Total_Quantity_in_Cart();
            ViewBag.QuantityCart = total_item;
            return PartialView("BagCartTotal");
        }

        public ActionResult CheckOut()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Order", "Product");
            }
            Cart cart = Session["Cart"] as Cart;

            return View(cart);
        }

    }
}