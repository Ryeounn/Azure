using Sneker.Models;
using System.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sneker.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = new Functions().Nikes().ToList();
            var model1 = new Functions().Adidas().ToList();
            var model2 = new Functions().Puma().ToList();
            var model3 = new Functions().Converse().ToList();
            dynamic myModel = new ExpandoObject();
            myModel.Nike = model;
            myModel.Adidas = model1;
            myModel.Puma = model2;
            myModel.Converse = model3;
            return View(myModel);
        }

        public ActionResult Stories()
        {
            return View();
        }

        public ActionResult Instruction()
        {
            return View();
        }

        public ActionResult Service()
        {
            return View();
        }
    }
}