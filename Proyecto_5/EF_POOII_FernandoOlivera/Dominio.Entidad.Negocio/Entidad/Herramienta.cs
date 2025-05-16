using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Dominio.Entidad.Negocio.Entidad
{
    public class Herramienta
    {
     [Display(Name = "Id Herramienta"), Required] public string idHerramienta { get; set; }
     [Display(Name = "Descripción"), Required] public string desHerramienta { get; set; }
     [Display(Name = "Medida"), Required] public string medHerramienta { get; set; }
     [Display(Name = "Id Categoría"), Required] public int Idcategoria { get; set; }
     [Display(Name = "Precio Unitario"), Required] public decimal preUnitario { get; set; }
     [Display(Name = "Stock Actual"), Required] public int stockActual { get; set; }
    }
}
