using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad.Negocio.Entidad
{
	public class ClienteLista
	{
		[Display(Name = "Id Cliente"), Required] public string idcliente { set; get; }
		[Display(Name = "Nombre Cliente"), Required] public string nombre { set; get; }
		[Display(Name = "Dirección Cliente"), Required] public string direccion { set; get; }
		[Display(Name = "Nombre Pais"), Required] public string nombrepais { set; get; }
		[Display(Name = "Teléfono"), Required] public string fono { set; get; }

	}
}
