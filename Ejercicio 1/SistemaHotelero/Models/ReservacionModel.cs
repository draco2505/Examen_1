using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotelero.Models
{
    public class ReservacionModel
    {
        public int ID { get; set; }
        public int ClienteID { get; set; }
        public string NombreCompletoCliente { get; set; }
        public int HabitacionID { get; set; }
        public string NombreHabitacion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int DiasEstancia { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal SubTotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public bool Estatus { get; set; }
    }
}
