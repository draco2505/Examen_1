//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaHotelero.Datos.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tra_Ventas_Reservacion
    {
        public int Id { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public Nullable<int> HabitacionID { get; set; }
        public System.DateTime FechaIngreso { get; set; }
        public int DiasEstancia { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public decimal SubTotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public bool Estatus { get; set; }
    
        public virtual Cat_Ventas_Cliente Cat_Ventas_Cliente { get; set; }
        public virtual Cat_Ventas_Habitacion Cat_Ventas_Habitacion { get; set; }
    }
}
