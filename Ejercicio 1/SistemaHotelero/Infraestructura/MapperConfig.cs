using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaHotelero.Models;
using SistemaHotelero.Datos.Entidades;
using SistemaHotelero.Datos.Dto;

namespace SistemaHotelero.Infraestructura
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg => {
                cfg.CreateMap<Cat_Seguridad_Rol, RolModel>();
                cfg.CreateMap<Cat_Ventas_TipoCliente, TipoClienteModel>();
                cfg.CreateMap<Cat_Ventas_TipoHabitacion, TipoHabitacionModel>();
                cfg.CreateMap<Cliente, ClienteModel>().ReverseMap();
                cfg.CreateMap<Habitaciones, HabitacionesModel>().ReverseMap();
                cfg.CreateMap<Ganancias, GananciasModel>().ReverseMap();
                cfg.CreateMap<Reservacion, ReservacionModel>().ReverseMap();
                cfg.CreateMap<Cat_Seguridad_Usuario, UsuarioModel>().ReverseMap();
            });
        }
    }
}