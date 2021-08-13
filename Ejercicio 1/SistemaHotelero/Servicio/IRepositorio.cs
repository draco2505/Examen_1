using SistemaHotelero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaHotelero.Servicio
{
    public interface IRepositorio
    {
        IEnumerable<RolModel> RecuperarCatalogoRoles();
        IEnumerable<TipoClienteModel> RecuperarCatalogoTipoCliente();
        IEnumerable<TipoHabitacionModel> RecuperarCatalogoTipoHabitacion();
        UsuarioModel RecuperarUsuario(string Usuario, string Pass);
        IEnumerable<HabitacionesModel> RecuperarHabitaciones(int TipoHabitacion);
        HabitacionesModel RecuperarHabitacion(int HabitacionID);
        bool ActualizarPRecioHabitacion(int HabitacionID, decimal Precio);
        ClienteModel RecuperarClientePorID(int ClienteID);
        IEnumerable<ClienteModel> RecuperarClientes();
        ReservacionModel ReservarHabitacion(ReservacionModel NuevaReservacion);
        bool CancelarReservacion(int ReservacionID);
        GananciasModel CalculoGananciasMensuales(int Mes);
    }
}
