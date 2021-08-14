using SistemaHotel.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaHotel.web.Servicio;
using System.Threading.Tasks;

namespace SistemaHotel.web.Controllers
{
    public class SesionController : Controller
    {
        private Service Servicio;
        public SesionController()
        {
            Servicio = new Service();
        }
        // GET: Sesion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string Usuario, string Password)
        {
            UsuarioModel User = new UsuarioModel();            
            Task.Run(async () => {
                var response = await Servicio.RecuperarUsuario(Usuario, Password);
                if (!response._Error)
                {
                   User = response.Data;
                }
            }).GetAwaiter().GetResult();
            if (User.Id != 0)
            {
                Session["Usuario"] = User;
                return RedirectToAction("Index","Home");
            }

            return Json(new { User }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogOff()
        {
            Session["Usuario"] = null;
            return Json(new { Exito=true});
        }
    }
}