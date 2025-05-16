using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

// Importar las Bibliotecas de Clase
using Dominio.Entidad.Negocio.Entidad;
using Infraestructura.Data.Negocios;

namespace appWeb07.Controllers
{
    public class MantenimientoController : Controller
    {
        //================ Variables y Métodos =====================

        // Creamos dos objetos
        paisDTO _pais = new paisDTO();
        clienteDTO _cliente = new clienteDTO();

        // ================== Vistas ========================================================
        public ActionResult Index()
        {
            return View(_cliente.GetAll());
        }
		
		//----------------------------------------------------------------------------------

		public ActionResult Create() {
            ViewBag.paises = new SelectList(_pais.GetAll(), "idpais", "nombrepais");
            return View(new Cliente());
        }

        [HttpPost]
		public ActionResult Create(Cliente reg)
		{
            ViewBag.mensaje = _cliente.Add(reg);
			ViewBag.paises = new SelectList(_pais.GetAll(), "idpais", "nombrepais", reg.idpais);
			return View(reg);
		}

		//----------------------------------------------------------------------------------
		public ActionResult Edit(string id = "")
		{
			Cliente reg = _cliente.Find(id);
			ViewBag.paises = new SelectList(_pais.GetAll(), "idpais", "nombrepais", reg.idpais);
			return View(reg);
		}

		[HttpPost]
		public ActionResult Edit(Cliente reg)
		{
			ViewBag.mensaje = _cliente.Update(reg);
			ViewBag.paises = new SelectList(_pais.GetAll(), "idpais", "nombrepais", reg.idpais);
			return View(reg);
		}
	}
}