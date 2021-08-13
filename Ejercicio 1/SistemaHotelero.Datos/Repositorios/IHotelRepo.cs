using SistemaHotelero.Datos.Dto;
using SistemaHotelero.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotelero.Datos.Repositorios
{
    public interface IHotelRepo
    {
        IEnumerable<Cat_Seguridad_Rol> RecuperarCatalogoRoles();
        IEnumerable<Cat_Ventas_TipoCliente> RecuperarCatalogoTipoCliente();
        IEnumerable<Cat_Ventas_TipoHabitacion> RecuperarCatalogoTipoHabitacion();
        Cat_Seguridad_Usuario RecuperarUsuario(string Usuario, string Pass);
        IEnumerable<Habitaciones> RecuperarHabitaciones(int TipoHabitacion);
        Habitaciones RecuperarHabitacion(int HabitacionID);
        bool ActualizarPRecioHabitacion(int HabitacionID, decimal Precio);
        Cliente RecuperarClientePorID(int ClienteID);
        IEnumerable<Cliente> RecuperarClientes();
        Reservacion ReservarHabitacion(Tra_Ventas_Reservacion NuevaReservacion);
        bool CancelarReservacion(int ReservacionID);
        Ganancias CalculoGananciasMensuales(int Mes);
    }
}
