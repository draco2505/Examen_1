using SistemaHotel.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SistemaHotel.web.Servicio;

namespace SistemaHotel.web.Controllers
{
    public class HomeController : Controller
    {
        private Service Servicio;
        public HomeController()
        {
            Servicio = new Service();
        }
        public ActionResult Index()
        {
            if(Session["Usuario"] == null)
            {
                return RedirectToAction("Index", "Sesion");
            }
            return View();
        }

        public ActionResult RecuperarHabitaciones(int TipoHabitacionID = 1)
        {
            List<HabitacionesModel> lista = new List<HabitacionesModel>();
            Task.Run(async () => {
                var response = await Servicio.RecuperarHabitaciones(TipoHabitacionID);
                if (!response._Error)
                {
                    lista = response.Data;
                }
            }).GetAwaiter().GetResult();
            return PartialView("_ListaHabitaciones", lista);
        }
       
    }
}