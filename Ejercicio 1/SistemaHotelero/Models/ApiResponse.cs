using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotelero.Models
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool HuboError { get; set; }
        public string Mensaje { get; set; }
        public int Status { get; set; }

    }
}