using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dominio.Entidad.Negocio.Entidad;
using Dominio.Entidad.Negocio.Abstraccion;
using Dominio.Repositorio;


namespace Infraestructura.Data.Negocios
{
    public class CategoriaDTO : Icategoria
    {
        public IEnumerable<Categoria> GetAll()
        {
            List<Categoria> temporal = new List<Categoria>();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_LISTAR_CATEGORIAS", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Categoria()
                    {
                        IdCategoria = dr.GetInt32(0),
                        NombreCategoria = dr.GetString(1),
                    });
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

    }

}


