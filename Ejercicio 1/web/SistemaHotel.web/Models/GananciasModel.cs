using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.web.Models
{
    public class GananciasModel
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