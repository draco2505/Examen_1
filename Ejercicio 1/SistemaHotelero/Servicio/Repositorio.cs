using SistemaHotelero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaHotelero.Datos.Repositorios;
using AutoMapper;
using SistemaHotelero.Datos.Entidades;

namespace SistemaHotelero.Servicio
{
    public class Repositorio : IRepositorio
    {
        IMapper mapper;
        IHotelRepo Repo;
        public Repositorio(IHotelRepo Repo)
        {
            this.Repo = Repo;
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        public bool ActualizarPRecioHabitacion(int HabitacionID, decimal Precio) => Repo.ActualizarPRecioHabitacion(HabitacionID, Precio);

        public GananciasModel CalculoGananciasMensuales(int Mes) => mapper.Map<GananciasModel>(Repo.CalculoGananciasMensuales(Mes));

        public bool CancelarReservacion(int ReservacionID) => Repo.CancelarReservacion(ReservacionID);       

        public IEnumerable<RolModel> RecuperarCatalogoRoles() 
        {
           var Catalogo = mapper.Map<IEnumerable<RolModel>>(Repo.RecuperarCatalogoRoles());
            return Catalogo;
        }

        public IEnumerable<TipoClienteModel> RecuperarCatalogoTipoCliente()
        {
            var Catalogo = mapper.Map<IEnumerable<TipoClienteModel>>(Repo.RecuperarCatalogoTipoCliente());
            return Catalogo;
        }

        public IEnumerable<TipoHabitacionModel> RecuperarCatalogoTipoHabitacion()
        {
            var Catalogo = mapper.Map<IEnumerable<TipoHabitacionModel>>(Repo.RecuperarCatalogoTipoHabitacion());
            return Catalogo;
        }

        public ClienteModel RecuperarClientePorID(int ClienteID) => mapper.Map<ClienteModel>(Repo.RecuperarClientePorID(ClienteID));
       

        public IEnumerable<ClienteModel> RecuperarClientes() => mapper.Map<IEnumerable<ClienteModel>>(Repo.RecuperarClientes());


        public HabitacionesModel RecuperarHabitacion(int HabitacionID) => mapper.Map<HabitacionesModel>(Repo.RecuperarHabitacion(HabitacionID));


        public IEnumerable<HabitacionesModel> RecuperarHabitaciones(int TipoHabitacion) => mapper.Map<IEnumerable<HabitacionesModel>>(Repo.RecuperarHabitaciones(TipoHabitacion));


        public UsuarioModel RecuperarUsuario(string Usuario, string Pass) => mapper.Map<UsuarioModel>(Repo.RecuperarUsuario(Usuario, Pass));

        public ReservacionModel ReservarHabitacion(ReservacionModel NuevaReservacion)
        {
            var ReservacionDB = mapper.Map<Tra_Ventas_Reservacion>(NuevaReservacion);
            return mapper.Map<ReservacionModel>(Repo.ReservarHabitacion(ReservacionDB));
        }
    }
}