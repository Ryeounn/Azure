﻿using Sneker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Sneker.Areas.Admin.Controllers
{
    public class ProductAdminController : Controller
    {
        // GET: Admin/ProductAdmin
        SnekerEntities db = new SnekerEntities();
        public ActionResult Shoe(string search ="")
        {
            List<Product> products = db.Products.Where(row => row.Productname.Contains(search)).ToList();
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMg = TempData["result"];
            }
            if (TempData["error"] != null)
            {
                ViewBag.ErrorMg = TempData["error"];
            }
            return View(products);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string productcode, FormCollection form, HttpPostedFileBase imageFile)
        {
            if(ModelState.IsValid)
            {
                productcode = form["productcode"];
                var productcoder = db.Products.FirstOrDefault(row => row.Productcode == productcode);
                if(productcoder == null)
                {
                    Product product = new Product();
                    product.Productcode = form["productcode"];
                    product.Productname = form["productname"];
                    product.Quantityperunit = int.Parse(form["quantityperunit"]);
                    product.Unitinstock = int.Parse(form["unitinstock"]);
                    product.Unitprice = int.Parse(form["unitprice"]);
                    product.Discount = int.Parse(form["discount"]);
                    product.Size = int.Parse(form["size"]);
                    product.CaterogyID = int.Parse(form["caterogyid"]);
                    string filename = product.Productcode + ".jpg";
                    string path = Path.Combine(Server.MapPath("/Content/Image/Product/"), filename);
                    imageFile.SaveAs(path);
                    product.PicturePath = "/Content/Image/Product/";
                    product.Picture = filename;
                    db.Products.Add(product);
                    db.SaveChanges();
                    TempData["result"] = "Add Product successfully!";
                    return RedirectToAction("Shoe", "ProductAdmin");
                }
                else
                {
                    TempData["error"] = "Add Product fall because ProductCode already exists!";
                    return RedirectToAction("Shoe", "ProductAdmin");
                }
                
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Product products = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(products);
        }

        [HttpPost]
        public ActionResult Edit(int id, string productcode, FormCollection form, HttpPostedFileBase imageFile)
        {
            id = int.Parse(form["productid"]);
            productcode = form["productname"];
            Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            if(product != null)
            {
                product.Productcode = form["productcode"];
                product.Productname = form["productname"];
                product.Quantityperunit = int.Parse(form["quantityperunit"]);
                product.Unitinstock = int.Parse(form["unitinstock"]);
                product.Unitprice = int.Parse(form["unitprice"]);
                product.Discount = int.Parse(form["discount"]);
                product.Size = int.Parse(form["size"]);
                product.CaterogyID = int.Parse(form["caterogyid"]);
                string filename = product.Productcode + ".jpg";
                string path = Path.Combine(Server.MapPath("/Content/Image/Product/"), filename);
                imageFile.SaveAs(path);
                product.PicturePath = "/Content/Image/Product/";
                product.Picture = filename;
                db.SaveChanges();
                TempData["result"] = "Edit Product successfully!";
                return RedirectToAction("Shoe", "ProductAdmin");
            }
            else
            {
                TempData["error"] = "Edit Product fall!";
                return RedirectToAction("Shoe", "ProductAdmin");
            }
        }

        public ActionResult Delete(int id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            TempData["result"] = "Delete Product successfully!";
            return RedirectToAction("Shoe", "ProductAdmin");
        }
    }
}