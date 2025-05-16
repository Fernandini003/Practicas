using Dominio.Entidad.Negocio.Abstraccion;
using Dominio.Entidad.Negocio.Entidad;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.Negocios
{
    public class herramientaDTO : IHerramienta
    {
        public string Add(Herramienta registro)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("SP_INSERTAR_HERRAMIENTA", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idHerramienta", registro.idHerramienta);
                    cmd.Parameters.AddWithValue("@desHerramienta", registro.desHerramienta);
                    cmd.Parameters.AddWithValue("@medHerramienta", registro.medHerramienta);
                    cmd.Parameters.AddWithValue("@Idcategoria", registro.Idcategoria);
                    cmd.Parameters.AddWithValue("@preUnitario", registro.preUnitario);
                    cmd.Parameters.AddWithValue("@stockActual", registro.stockActual);

                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha insertado {i} insumo nuevo";
                    cn.Close();
                }
                catch (SqlException ex) { mensaje = ex.Message; }

                finally { cn.Open(); }

            }
            return mensaje;
        }

        public string Delete(Herramienta registro)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("SP_ELIMINAR_HERRAMIENTA", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idHerramienta", registro.idHerramienta);
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha eliminado {i}";
                    cn.Close();
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.Open(); }
            }
            return mensaje;
        }

        public Herramienta find(string id)
        {
            Herramienta reg = new Herramienta();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_BUSCAR_HERRAMIENTA @idHerramienta", cn);
                cmd.Parameters.AddWithValue("@idHerramienta", id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    reg = new Herramienta()
                    {
                        idHerramienta = dr.GetString(0),
                        desHerramienta = dr.GetString(1),
                        medHerramienta = dr.GetString(2),
                        Idcategoria = dr.GetInt32(3),
                        preUnitario = dr.GetDecimal(4),
                        stockActual = dr.GetInt32(5)
                    };
                }
                dr.Close();
                cn.Close();
            }
            return reg;
        }

        public IEnumerable<Herramienta> GetAll()
        {
            List<Herramienta> temporal = new List<Herramienta>();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_LISTAR_HERRAMIENTAS", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Herramienta herra = new Herramienta
                    {
                        idHerramienta = dr.GetString(0),
                        desHerramienta = dr.GetString(1),
                        medHerramienta = dr.GetString(2),
                        Idcategoria = dr.GetInt32(3),
                        preUnitario = dr.GetDecimal(4),
                        stockActual = dr.GetInt32(5)
                    };
                    temporal.Add(herra);
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

        public string Update(Herramienta registro)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("SP_EDITAR_HERRAMIENTA", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idHerramienta", registro.idHerramienta);
                    cmd.Parameters.AddWithValue("@desHerramienta", registro.desHerramienta);
                    cmd.Parameters.AddWithValue("@medHerramienta", registro.medHerramienta);
                    cmd.Parameters.AddWithValue("@Idcategoria", registro.Idcategoria);
                    cmd.Parameters.AddWithValue("@preUnitario", registro.preUnitario);
                    cmd.Parameters.AddWithValue("@stockActual", registro.stockActual);

                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha actualizado {i} herramienta";
                    cn.Close();
                }
                catch (SqlException ex) { mensaje = ex.Message; }

                finally { cn.Open(); }

            }
            return mensaje;
        }
    }
}
