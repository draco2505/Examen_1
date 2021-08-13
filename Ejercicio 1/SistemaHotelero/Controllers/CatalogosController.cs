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
    public class CatalogosController : ApiController
    {
        private Repositorio Repo;
        public CatalogosController()
        {
            this.Repo = new Repositorio(new HotelRepo());
        }
        [Route("api/Catalogos/GetRoles")]
        public IEnumerable<RolModel> GetRoles()
        {
            var Roles = Repo.RecuperarCatalogoRoles();

            return Roles;
        }

        [Route("api/Catalogos/GetTiposHabitacion")]
        public IEnumerable<TipoHabitacionModel> GetTiposHabitacion()
        {
            var TiposHabitacion = Repo.RecuperarCatalogoTipoHabitacion();

            return TiposHabitacion;
        }
        [Route("api/Catalogos/GetTiposCliente")]
        public IEnumerable<TipoClienteModel> GetTiposCliente()
        {
            var TiposCliente = Repo.RecuperarCatalogoTipoCliente();

            return TiposCliente;
        }

    }
}
