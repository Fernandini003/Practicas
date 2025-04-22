using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// Importar
using appWeb05.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Ajax.Utilities;

namespace appWeb05.Controllers
{
    public class MantenimientoController : Controller
    {
        // ========================= Variables y Métodos ===================================
        IEnumerable<Insumo> listarInsumos()
        {
            List<Insumo> temporal = new List<Insumo>();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.
                                ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("spU_Listar_Insumos", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Insumo()
                    {
                        idInsumo = dr.GetInt32(0),
                        nomInsumo = dr.GetString(1),
                        nomProveedor = dr.GetString(2),
                        preUnitario = dr.GetDecimal(3),
                        stockUnitario = dr.GetInt16(4)
                    });
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

        IEnumerable<Proveedor> cargarProveedores()
        {
            List<Proveedor> temporal = new List<Proveedor>();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.
                        ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("spU_Cargar_Proveedores", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Proveedor()
                    {
                        IdProveedor = dr.GetInt32(0),
                        NomProveedor = dr.GetString(1),
                    });
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

        string agregarInsumo(Insumo reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.
                            ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_Insertar_Insumos @nomInsumo, @IdProveedor," +
                    "@preUnitario, @stockUnitario", cn);
                cmd.Parameters.AddWithValue("@nomInsumo", reg.nomInsumo);
                cmd.Parameters.AddWithValue("@idProveedor", reg.idProveedor);
                cmd.Parameters.AddWithValue("@preUnitario", reg.preUnitario);
                cmd.Parameters.AddWithValue("@stockUnitario", reg.stockUnitario);

                int i = cmd.ExecuteNonQuery();
                mensaje = $"Se ha insertado {i} insumo: {reg.nomInsumo}";
                cn.Close();
            }
            return mensaje;
        }

        string actualizar(Insumo reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            { 
                cn.Open() ;
                SqlCommand cmd = new SqlCommand("sp_Alterar_Insumos @idInsumo, @nomInsumo, @IdProveedor, @preUnitario,@stockUnitario", cn);
                cmd.Parameters.AddWithValue("@idInsumo", reg.idInsumo);
                cmd.Parameters.AddWithValue("@nomInsumo", reg.nomInsumo);
                cmd.Parameters.AddWithValue("@IdProveedor", reg.idProveedor);
                cmd.Parameters.AddWithValue("@preUnitario", reg.preUnitario);
                cmd.Parameters.AddWithValue("@stockUnitario", reg.stockUnitario);

                int i = cmd.ExecuteNonQuery();
                mensaje = $"Se ha actualizado {i} insumo";
                
            }

            return mensaje;
        }

        //pagina 142
        Insumo buscar(int id)
        {
            return listarInsumos().FirstOrDefault(x => x.idInsumo == id);
        }

        string Eliminar(int id)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_Eliminar_Insumos @idInsumo", cn);
                cmd.Parameters.AddWithValue("@idInsumo", id);

                int i = cmd. ExecuteNonQuery();
                mensaje = $"se ha elminado {i} insumo";
            }
            return mensaje;
        }





        // ======================== Abajo para las VISTAS ==================================
        public ActionResult Index()         // Vista Principal de los Insumos
        {
            return View(listarInsumos());
        }

        public ActionResult Create()
        {
            ViewBag.proveedor = new SelectList(cargarProveedores(), "IdProveedor", "NomProveedor");
            return View(new Insumo());
        }

        [HttpPost]
        public ActionResult Create(Insumo reg)
        {
            ViewBag.mensaje = agregarInsumo(reg);
            ViewBag.proveedor = new SelectList(cargarProveedores(), "IdProveedor", "NomProveedor", reg.idProveedor);
            return View(reg);
        }

        public ActionResult Edit(int id)
        {
            Insumo reg = buscar(id);

            ViewBag.proveedor = new SelectList(cargarProveedores(), "IdProveedor", "NomProveedor", reg.idProveedor);

            return View(reg);
        }

        [HttpPost]
        public ActionResult Edit(Insumo reg)
        {
            ViewBag.mensaje = actualizar(reg);
            ViewBag.proveedor = new SelectList(cargarProveedores(), "IdProveedor", "NomProveedor", reg.idProveedor);
            return View(reg);   
        }

        public ActionResult Details(int? id = null)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Insumo reg = listarInsumos().FirstOrDefault(x => x.idInsumo == id);
            return View(reg);
        }

        public ActionResult Delete(int? id = null)
        {
            if (id == null)
                return RedirectToAction("Index");
            ViewBag.mensaje = Eliminar(id.Value);
            return RedirectToAction("Index");

        }


    }
}