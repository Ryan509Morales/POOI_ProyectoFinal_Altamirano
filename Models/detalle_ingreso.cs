//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POOI_ProyectoVentas_AltamiranoBryan.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class detalle_ingreso
    {
        public int iddetalle_ingreso { get; set; }
        public Nullable<int> idingreso { get; set; }
        public Nullable<int> idarticulo { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<decimal> precio_compra { get; set; }
        public Nullable<decimal> precio_venta { get; set; }
    
        public virtual articulo articulo { get; set; }
        public virtual ingreso ingreso { get; set; }
    }
}
