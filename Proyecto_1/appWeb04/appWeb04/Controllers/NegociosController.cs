using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using appWeb04.Models;

namespace appWeb04.Controllers
{
    public class NegociosController : Controller
    {
        // LOGICA=========================
       
        IEnumerable<Pedido> ListarPedidosYear(int y)
        {
            List<Pedido> temporal = new List<Pedido>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("spU_Pedidos_Año @y", cn);
                cmd.Parameters.AddWithValue("@y", y);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Pedido()
                    {
                        idPedido=dr.GetInt32(0),
                        fecha = dr.GetDateTime(1),
                        cliente = dr.GetString(2),
                        direccion=dr.GetString(3),
                        ciudad=dr.GetString(4)
                    });
                }
                dr.Close (); cn.Close();
            }
            return temporal;
        }

        IEnumerable<Pedido> ListarPedidosFechas(DateTime fecha1, DateTime fecha2)
        {
            List<Pedido> temporal = new List<Pedido>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("spU_Pedidos_Entre_Fechas @f1,@f2", cn);
                cmd.Parameters.AddWithValue("@f1", fecha1);
                cmd.Parameters.AddWithValue("@f2", fecha2);
                SqlDataReader dr = cmd.ExecuteReader();
                {
                    while (dr.Read())
                    {
                        temporal.Add(new Pedido()
                        {
                           idPedido =dr.GetInt32(0),
                           fecha = dr.GetDateTime(1),
                           cliente = dr.GetString(2),
                           direccion=dr.GetString(3),
                           ciudad=dr.GetString(4),
                        });
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            return temporal;
        }

        IEnumerable<Producto> productos()
        {
            List<Producto> temporal = new List<Producto>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_productos", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Producto()
                    {
                        idProducto = dr.GetInt32(0),
                        descripcion = dr.GetString(1),  
                        preUni = dr.GetDecimal(2),
                        stock = dr.GetInt16(3)
                    });
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

        // VISTAS============================================
        public ActionResult CpnsultarPedidosYear(int y=0)
        {
            return View(ListarPedidosYear(y));
        }
        public ActionResult ConsultarPedidosFechas(DateTime ? f1=null, DateTime ? f2 = null)
        {
            DateTime _f1 = f1 == null ? DateTime.Today :  (DateTime)f1;
            DateTime _f2 = f2 == null ? DateTime.Today :  (DateTime)f2;
            return View(ListarPedidosFechas(_f1, _f2));
        }
        public ActionResult Paginacion(int p = 0)
        {
            int c = productos().Count();
            int f = 11;

            int npagas = c % f == 0 ? c / f : c / f + 1;

            ViewBag.p = p;
            ViewBag.npagas = npagas;

            return View(productos().Skip(f* p).Take(f));
        }
    }
}