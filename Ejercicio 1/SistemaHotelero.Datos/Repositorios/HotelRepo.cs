using SistemaHotelero.Datos.Dto;
using SistemaHotelero.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotelero.Datos.Repositorios
{
    public class HotelRepo : IHotelRepo
    {
        public IEnumerable<Cat_Seguridad_Rol> RecuperarCatalogoRoles()
        {
            using (var db = new HotelEntities())
            {
                return db.Cat_Seguridad_Rol.ToList();
            }
        }

        public IEnumerable<Cat_Ventas_TipoCliente> RecuperarCatalogoTipoCliente()
        {
            using (var db = new HotelEntities())
            {
                return db.Cat_Ventas_TipoCliente.ToList();
            }
        }

        public IEnumerable<Cat_Ventas_TipoHabitacion> RecuperarCatalogoTipoHabitacion()
        {
            using (var db = new HotelEntities())
            {
                return db.Cat_Ventas_TipoHabitacion.ToList();
            }
        }

        public Cat_Seguridad_Usuario RecuperarUsuario(string Usuario, string Pass)
        {
            using (var db = new HotelEntities())
            {
                var Usuarios = (from u in db.Cat_Seguridad_Usuario
                                where u.Usuario.ToUpper() == Usuario.ToUpper() && u.Contrasena.ToUpper() == Pass.ToUpper()
                                select u).ToList();
                return Usuarios.Count() > 0 ? Usuarios.FirstOrDefault() : new Cat_Seguridad_Usuario();
            }
        }

        public IEnumerable<Habitaciones> RecuperarHabitaciones(int TipoHabitacion)
        {
            using (var db = new HotelEntities())
            {
                var ListaHAbitacioones = (from h in db.Cat_Ventas_Habitacion
                                          join t in db.Cat_Ventas_TipoHabitacion on h.TipoHabitacionID equals t.Id
                                          where h.TipoHabitacionID == TipoHabitacion && h.Disponible == true
                                          select new Habitaciones()
                                          {
                                              Id = h.Id,
                                              TipoHabitacionID = (int)h.TipoHabitacionID,
                                              TipoHabitacion = t.TipoHabitacion,
                                              Preciohabitacion = h.PrecioHabitacion,
                                              Nombre = h.Nombre,
                                              Foto = h.RutaFoto,
                                              NoHabitacion = h.NoHabitacion,
                                              Disponible = h.Disponible
                                          }).ToList();

                return ListaHAbitacioones;
            }
        }

        public Habitaciones RecuperarHabitacion(int HabitacionID)
        {
            using (var db = new HotelEntities())
            {
                var HAbitacion = (from h in db.Cat_Ventas_Habitacion
                                  join t in db.Cat_Ventas_TipoHabitacion on h.TipoHabitacionID equals t.Id
                                  where h.Id == HabitacionID
                                  select new Habitaciones()
                                  {
                                      Id = h.Id,
                                      TipoHabitacionID = (int)h.TipoHabitacionID,
                                      TipoHabitacion = t.TipoHabitacion,
                                      Preciohabitacion = h.PrecioHabitacion,
                                      Nombre = h.Nombre,
                                      Foto = h.RutaFoto,
                                      NoHabitacion = h.NoHabitacion,
                                      Disponible = h.Disponible
                                  }).FirstOrDefault();

                return HAbitacion;
            }
        }

        public bool ActualizarPRecioHabitacion(int HabitacionID, decimal Precio)
        {
            using (var db = new HotelEntities())
            {
                var Actualizada = false;
                var habitacion = db.Cat_Ventas_Habitacion.Find(HabitacionID);
                habitacion.PrecioHabitacion = Precio;
                if (db.SaveChanges() > 0)
                {
                    Actualizada = true;
                }
                return Actualizada;
            }
        }

        public Cliente RecuperarClientePorID(int ClienteID)
        {
            using (var db = new HotelEntities())
            {
                var Cliente = (from c in db.Cat_Ventas_Cliente
                               join t in db.Cat_Ventas_TipoCliente on c.TipoclienteID equals t.Id
                               where c.Id == ClienteID
                               select new Cliente()
                               {
                                   Id = c.Id,
                                   Nombre = c.Nombre,
                                   Apellidos = c.Apellidos,
                                   Descuento = (decimal)c.Descuento,
                                   TipoCliente = t.TipoCliente,
                                   TipoClienteID = c.TipoclienteID
                               }).FirstOrDefault();

                return Cliente;
            }
        }

        public IEnumerable<Cliente> RecuperarClientes()
        {
            using (var db = new HotelEntities())
            {
                var Clientes = (from c in db.Cat_Ventas_Cliente
                                join t in db.Cat_Ventas_TipoCliente on c.TipoclienteID equals t.Id
                                select new Cliente()
                                {
                                    Id = c.Id,
                                    Nombre = c.Nombre,
                                    Apellidos = c.Apellidos,
                                    Descuento = (decimal)c.Descuento,
                                    TipoCliente = t.TipoCliente,
                                    TipoClienteID = c.TipoclienteID
                                }).ToList();

                return Clientes;
            }
        }

        public Reservacion ReservarHabitacion(Tra_Ventas_Reservacion NuevaReservacion)
        {
            using (var db = new HotelEntities())
            {
                Reservacion ReservacionResultado = new Reservacion();
                NuevaReservacion.FechaRegistro = DateTime.Now;
                db.Tra_Ventas_Reservacion.Add(NuevaReservacion);
                db.SaveChanges();

                if (NuevaReservacion.Id != 0)
                {
                    ReservacionResultado = (from r in db.Tra_Ventas_Reservacion
                                            join c in db.Cat_Ventas_Cliente on r.ClienteID equals c.Id
                                            join h in db.Cat_Ventas_Habitacion on r.HabitacionID equals h.Id
                                            select new Reservacion()
                                            {
                                                ID = r.Id,
                                                ClienteID = (int)r.ClienteID,
                                                NombreCompletoCliente = $"{c.Nombre} {c.Apellidos}",
                                                HabitacionID = (int)r.HabitacionID,
                                                NombreHabitacion = h.Nombre,
                                                FechaIngreso = r.FechaIngreso,
                                                FechaRegistro = (DateTime)r.FechaRegistro,
                                                DiasEstancia = r.DiasEstancia,
                                                IVA = r.IVA,
                                                SubTotal = r.SubTotal,
                                                Total = r.Total,
                                                Estatus = r.Estatus
                                            }).FirstOrDefault();
                }

                return ReservacionResultado;
            }
        }


        public bool CancelarReservacion(int ReservacionID)
        {
            using (var db = new HotelEntities())
            {
                bool Cancelada = false;
                var _Reservacion = db.Tra_Ventas_Reservacion.Find(ReservacionID);
                _Reservacion.Estatus = false;
                if (db.SaveChanges() > 0)
                {
                    Cancelada = true;
                }
                return Cancelada;
            }
        }

        public Ganancias CalculoGananciasMensuales(int Mes)
        {
            using (var db = new HotelEntities())
            {
                var FechaActual = DateTime.Now;
                Ganancias GananciaMensual = new Ganancias();
                var Reservaciones = (from r in db.Tra_Ventas_Reservacion
                                      where r.FechaIngreso.Month == Mes && r.FechaIngreso.Year == FechaActual.Year && r.Estatus == true                                     
                                      select r).ToList();
                int ClientesMes = Reservaciones.Select(s => s.ClienteID).Distinct().Count();
                int DiasReservados = Reservaciones.Sum(s => s.DiasEstancia);
                decimal _SubTotal = Reservaciones.Where(w => w.FechaIngreso.Month == Mes).Sum(s => s.SubTotal);
                decimal _Iva = Reservaciones.Where(w => w.FechaIngreso.Month == Mes).Sum(s => s.IVA);
                decimal _Total = Reservaciones.Where(w => w.FechaIngreso.Month == Mes).Sum(s => s.Total);

                GananciaMensual.Mes = Mes;
                GananciaMensual.NombreMes = FechaActual.ToString("MMMM");
                GananciaMensual.NumeroClientes = ClientesMes;
                GananciaMensual.DiasReservados = DiasReservados;
                GananciaMensual.SubTotal = _SubTotal;
                GananciaMensual.Iva = _Iva;
                GananciaMensual.Total = _Total;

                return GananciaMensual;

            }
        }
    }
}
