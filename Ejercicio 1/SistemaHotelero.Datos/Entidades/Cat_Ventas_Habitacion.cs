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
    
    public partial class Cat_Ventas_Habitacion
    {
        public Cat_Ventas_Habitacion()
        {
            this.Tra_Ventas_Reservacion = new HashSet<Tra_Ventas_Reservacion>();
        }
    
        public int Id { get; set; }
        public Nullable<int> TipoHabitacionID { get; set; }
        public decimal PrecioHabitacion { get; set; }
        public string Nombre { get; set; }
        public string RutaFoto { get; set; }
        public int NoHabitacion { get; set; }
        public bool Disponible { get; set; }
    
        public virtual Cat_Ventas_TipoHabitacion Cat_Ventas_TipoHabitacion { get; set; }
        public virtual ICollection<Tra_Ventas_Reservacion> Tra_Ventas_Reservacion { get; set; }
    }
}
