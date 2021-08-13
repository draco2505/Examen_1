using SistemaHotel.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.web.Servicio
{
    public interface IBaseApi
    {
         void SetURL(string action);
        void PostData<T>(T data);
        void PutData<T>(T data);
        void AddBodyData<T>(T data);
        Task<ApiResponse<T>> Request<T>();
    }
}
