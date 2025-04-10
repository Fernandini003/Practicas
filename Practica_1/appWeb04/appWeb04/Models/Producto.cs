using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Compilation;

namespace appWeb04.Models
{
    public class Producto
    {
        [Display(Name = "Id de Producto")] public int idProducto { get; set; }
        [Display(Name = "Descripción")] public string descripcion { get; set; }
        [Display(Name = "Precio Unitario")] public Decimal preUni { get; set; }
        [Display(Name = "Stock")] public Int16 stock { get; set; }
        [Display(Name = "SubTotal")] public decimal subTotal { get { return preUni * stock; } }

    }
}