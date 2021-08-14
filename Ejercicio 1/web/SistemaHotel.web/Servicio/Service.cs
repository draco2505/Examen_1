using SistemaHotel.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SistemaHotel.web.Servicio
{
    public class Service : BaseApi
    {
        private string UrlActualizarPRecioHabitacion = "api/Reservacion/ActualizarPRecioHabitacio";
        private string UrlCalculoGananciasMensuales = "api/Reservacion/CalculoGananciasMensuales";
        private string UrlCancelarReservacion = "api/Reservacion/CancelarReservacion";
        private string UrlRecuperarClientePorID = "api/Reservacion/RecuperarClientePorID";
        private string UrlRecuperarClientes = "api/Reservacion/RecuperarClientes";
        private string UrlRecuperarHabitacion = "api/Reservacion/RecuperarHabitacion";
        private string UrlRecuperarHabitaciones = "api/Reservacion/RecuperarHabitaciones";
        private string UrlRecuperarUsuario = "api/Reservacion/RecuperarUsuario";
        private string UrlReservarHabitacion = "api/Reservacion/ReservarHabitacion";
        public Service()
        {
            this.BaseUrl = "https://localhost:44354/";
        }

        public async Task<ApiResponse<bool>> ActualizarPrecioHabitacion(int HabitacionID, decimal Precio)
        {
            SetURL($"{UrlActualizarPRecioHabitacion}");
            PutData(HabitacionID);
            PutData(Precio);
            var response = await this.Request<bool>();
            return response;
        }

        public async Task<ApiResponse<GananciasModel>> CalculoGananciasMensuales(int Mes)
        {
            SetURL($"{UrlCalculoGananciasMensuales}?Mes={Mes}");
            var response = await this.Request<GananciasModel>();
            return response;
        }

        public async Task<ApiResponse<bool>> CancelarReservacion(int ReservacionID)
        {
            SetURL($"{UrlCancelarReservacion}");
            PutData(ReservacionID);
            var response = await this.Request<bool>();
            return response;
        }

        public async Task<ApiResponse<ClienteModel>> RecuperarClientePorID(int ClienteID)
        {
            SetURL($"{UrlRecuperarClientePorID}?ClienteID={ClienteID}");
            var response = await this.Request<ClienteModel>();
            return response;
        }

        public async Task<ApiResponse<List<ClienteModel>>> RecuperarClientes()
        {
            SetURL($"{UrlRecuperarClientes}");
            var response = await this.Request<List<ClienteModel>>();
            return response;
        }
        public async Task<ApiResponse<HabitacionesModel>> RecuperarHabitacion(int HabitacionID)
        {
            SetURL($"{UrlRecuperarHabitacion}?HabitacionID={HabitacionID}");
            var response = await this.Request<HabitacionesModel>();
            return response;
        }
        public async Task<ApiResponse<List<HabitacionesModel>>> RecuperarHabitaciones(int TipoHabitacionID = 1)
        {
            SetURL($"{UrlRecuperarHabitaciones}?TipoHabitacion={ TipoHabitacionID}");
            var response = await this.Request<List<HabitacionesModel>>();
            return response;
        }
        public async Task<ApiResponse<UsuarioModel>> RecuperarUsuario(string Usuario, string Password)
        {
            SetURL($"{UrlRecuperarUsuario}?Usuario={Usuario}&Pass={Password}");
            var response = await this.Request<UsuarioModel>();
            return response;
        }
        public async Task<ApiResponse<ReservacionModel>> ReservarHabitacio(ReservacionModel Reservacion)
        {
            SetURL($"{UrlReservarHabitacion}");
            PostData(Reservacion);
            var response = await this.Request<ReservacionModel>();
            return response;
        }
    }
}