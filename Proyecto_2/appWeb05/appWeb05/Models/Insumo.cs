using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appWeb05.Models
{
    public class Insumo
    {
        [Display(Name = "Id Insumo"), Required] public int idInsumo { set; get; }
        [Display(Name = "Nombre Insumo"), Required] public string nomInsumo      { set; get; }
        [Display(Name = "Id Proveedor"), Required] public int idProveedor { set; get; }
        [Display(Name = "Nombre Proveedor"), Required] public string nomProveedor{ set; get; }
        [Display(Name = "Precio Unitario"), Required] public decimal preUnitario { set; get; }
        [Display(Name = "Stock Actual"), Required] public Int16 stockUnitario { set; get; }
    }
}