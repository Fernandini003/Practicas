using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Importar Biblioteca de Clase
using Dominio.Repositorio;
using Dominio.Entidad.Negocio.Entidad;

namespace Dominio.Entidad.Negocio.Abstraccion
{
	public interface IPais: IRepositorioGET<Pais>
	{

	}
}
