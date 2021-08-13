using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotelero.Datos.Dto
{
    public class Ganancias
    {
        public int Mes { get; set; }
        public string NombreMes { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public int NumeroClientes { get; set; }
        public int DiasReservados { get; set; }
    }
}
