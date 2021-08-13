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
    public class ReservacionController : ApiController
    {
        private Repositorio Repo;
        public ReservacionController()
        {
            this.Repo = new Repositorio(new HotelRepo());
        }

        [HttpPut]
        public bool ActualizarPRecioHabitacion(int HabitacionID, decimal Precio) => Repo.ActualizarPRecioHabitacion(HabitacionID, Precio);
        [HttpGet]
        public GananciasModel CalculoGananciasMensuales(int Mes) => Repo.CalculoGananciasMensuales(Mes);
        [HttpPut]
        public bool CancelarReservacion(int ReservacionID) => Repo.CancelarReservacion(ReservacionID);
        [HttpGet]
        public ClienteModel RecuperarClientePorID(int ClienteID) => Repo.RecuperarClientePorID(ClienteID);

        [HttpGet]
        public IEnumerable<ClienteModel> RecuperarClientePorID() => Repo.RecuperarClientes();

        [HttpGet]
        public HabitacionesModel RecuperarHabitacion(int HabitacionID) =>Repo.RecuperarHabitacion(HabitacionID);

        [HttpGet]
        public IEnumerable<HabitacionesModel> RecuperarHabitaciones(int TipoHabitacion) =>Repo.RecuperarHabitaciones(TipoHabitacion);

        [HttpGet]
        public UsuarioModel RecuperarUsuario(string Usuario, string Pass) => Repo.RecuperarUsuario(Usuario, Pass);
        [HttpPost]
        public ReservacionModel ReservarHabitacion(ReservacionModel Reservacion) => Repo.ReservarHabitacion(Reservacion);



    }
}
