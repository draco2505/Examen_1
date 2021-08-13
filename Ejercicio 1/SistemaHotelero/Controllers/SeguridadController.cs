using SistemaHotelero.Datos.Repositorios;
using SistemaHotelero.Models;
using SistemaHotelero.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SistemaHotelero.Controllers
{
    public class SeguridadController : ApiController
    {
        private Repositorio Repo;
        public SeguridadController()
        {
            this.Repo = new Repositorio(new HotelRepo());
        }

        public UsuarioModel RecuperarUsuario(string Usuario,string Pass)
        {
            return Repo.RecuperarUsuario(Usuario, Pass);
        }

    }
}
