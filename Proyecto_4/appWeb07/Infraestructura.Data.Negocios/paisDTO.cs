using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Importar
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dominio.Entidad.Negocio.Entidad;
using Dominio.Entidad.Negocio.Abstraccion;

namespace Infraestructura.Data.Negocios
{
	public class paisDTO : IPais
	{
		public IEnumerable<Pais> GetAll()
		{
			List<Pais> temporal = new List<Pais>();

				using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
				{
					cn.Open();
					SqlCommand cmd = new SqlCommand("spU_Listar_Paises", cn);
					SqlDataReader dr = cmd.ExecuteReader();
					while (dr.Read())
					{
						temporal.Add(new Pais()
						{
							idpais = dr.GetString(0),
							nombrepais = dr.GetString(1),
						});
					}
					dr.Close();
					cn.Close();
				}
				return temporal;
		}

	}
}
