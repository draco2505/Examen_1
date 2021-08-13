using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotelero.Models
{
    public class RolModel
    {
        public int ID { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }
    }

    public class TipoHabitacionModel
    {
        public int ID { get; set; }
        public string TipoHabitacion { get; set; }
        public bool Activo { get; set; }
    }

    public class TipoClienteModel
    {
        public int ID { get; set; }
        public string TipoCliente { get; set; }
        public bool Activo { get; set; }
    }
}