using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotelero.Datos.Dto
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int TipoClienteID { get; set; }
        public string TipoCliente { get; set; }
        public decimal Descuento { get; set; }
    }
}
