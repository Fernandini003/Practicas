﻿using System;
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
	public class clienteDTO : ICliente
	{
		public IEnumerable<Cliente> GetAll()
		{
			List<Cliente> temporal = new List<Cliente>();

			using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
			{
				cn.Open();
				SqlCommand cmd = new SqlCommand("spU_Listar_Clientes", cn);
				SqlDataReader dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					temporal.Add(new Cliente()
					{
						idcliente = dr.GetString(0),
						nombre = dr.GetString(1),
						direccion = dr.GetString(2),
						idpais = dr.GetString(4),
						fono = dr.GetString(5),
					});
				}
				dr.Close();
				cn.Close();
			}
			return temporal;
		}
		public Cliente Find(string id)
		{
			Cliente reg = new Cliente();

			using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
			{
				cn.Open();
				SqlCommand cmd = new SqlCommand("spU_Buscar_Clientes @idcliente", cn);
				cmd.Parameters.AddWithValue("@idcliente", id);
				SqlDataReader dr = cmd.ExecuteReader();
				if (dr.Read())
				{
					reg = new Cliente()
					{
						idcliente = dr.GetString(0),
						nombre = dr.GetString(1),
						direccion = dr.GetString(2),
						idpais = dr.GetString(3),
						fono = dr.GetString(4),
					};
				}
				dr.Close();
				cn.Close();
			}
			return reg;
		}
		public string Add(Cliente registro)
		{
			string mensaje = "";
			using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
			{
				try
				{
					cn.Open();
					SqlCommand cmd = new SqlCommand("sp_MergeCliente", cn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@idcliente", registro.idcliente);
					cmd.Parameters.AddWithValue("@nombre", registro.nombre);
					cmd.Parameters.AddWithValue("@direccion", registro.direccion);
					cmd.Parameters.AddWithValue("@idpais", registro.idpais);
					cmd.Parameters.AddWithValue("@fono", registro.fono);

					int i = cmd.ExecuteNonQuery();
					mensaje = $"Se ha insertado {i} insumo nuevo";
					cn.Close();
				}
				catch(SqlException ex) { mensaje = ex.Message; }

				finally { cn.Open(); }
				
			}
			return mensaje;
		}
		public string Update(Cliente registro)
		{
			string mensaje = "";
			using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
			{
				try
				{
					cn.Open();
					SqlCommand cmd = new SqlCommand("sp_MergeCliente", cn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@idcliente", registro.idcliente);
					cmd.Parameters.AddWithValue("@nombre", registro.nombre);
					cmd.Parameters.AddWithValue("@direccion", registro.direccion);
					cmd.Parameters.AddWithValue("@idpais", registro.idpais);
					cmd.Parameters.AddWithValue("@fono", registro.fono);

					int i = cmd.ExecuteNonQuery();
					mensaje = $"Se ha actualizado {i} cliente";
					cn.Close();
				}
				catch (SqlException ex) { mensaje = ex.Message; }

				finally { cn.Open(); }

			}
			return mensaje;
		}
		public string Delete(Cliente registro)
		{
			string mensaje = "";
			using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
			{
				try
				{
					cn.Open();
					SqlCommand cmd = new SqlCommand("sp_MergeCliente", cn); // Crear el Procedure
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@idcliente", registro.idcliente);
					int i = cmd.ExecuteNonQuery();
					mensaje = $"Se ha eliminado {i} el cliente elegido";
					cn.Close();
				}
				catch (SqlException ex) { mensaje = ex.Message; }

				finally { cn.Open(); }

			}
			return mensaje;
		}
	}
}
