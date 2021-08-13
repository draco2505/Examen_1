using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.web.Models
{
    public class HabitacionesModel
    {
        public int Id { get; set; }
        public int TipoHabitacionID { get; set; }
        public string TipoHabitacion { get; set; }
        public decimal Preciohabitacion { get; set; }
        public string Nombre { get; set; }
        public string Foto { get; set; }
        public int NoHabitacion { get; set; }
        public bool Disponible { get; set; }
    }
}