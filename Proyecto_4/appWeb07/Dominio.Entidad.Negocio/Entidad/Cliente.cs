using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidad.Negocio.Entidad
{
	public class Cliente
	{
		[Display(Name = "Id Cliente"), Required] public string idcliente { set; get; }
		[Display(Name = "Nombre"), Required] public string nombre { set; get; }
		[Display(Name = "Dirección"), Required] public string direccion { set; get; }
		[Display(Name = "Id Pais"), Required] public string idpais { set; get; }
		[Display(Name = "Teléfono"), Required] public string fono { set; get; }
	}
}
