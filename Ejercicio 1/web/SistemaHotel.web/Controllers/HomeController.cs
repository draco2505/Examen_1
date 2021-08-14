using SistemaHotel.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaHotel.web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Session["Usuario"] == null)
            {
                return RedirectToAction("Index", "Sesion");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}