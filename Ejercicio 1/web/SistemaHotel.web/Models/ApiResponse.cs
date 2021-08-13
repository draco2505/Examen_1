using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.web.Models
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            this.Data = data;
        }

        public T Data { get; set; }
        public int status { get; set; }
        public bool _Error { get; set; }
        public string Mensaje { get; set; }
    }
}