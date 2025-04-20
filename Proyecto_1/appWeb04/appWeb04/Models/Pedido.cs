using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appWeb04.Models
{
    public class Pedido
    {
        [Display(Name = "Id pedido")] public int idPedido { get; set; }
        [Display(Name = "Fecha Pedido"),DisplayFormat(DataFormatString ="{0:dd/MM//yyyy}")] public DateTime fecha { get; set; }
        [Display(Name = "Nombre Cliente")] public string cliente { get; set; }
        [Display(Name = "Dirección de Destino")] public string direccion { get; set; }
        [Display(Name = "Ciudad de Destino")] public string ciudad { get; set; }
    }
}
