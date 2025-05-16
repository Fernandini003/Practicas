using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Dominio.Entidad.Negocio.Entidad;
using Infraestructura.Data.Negocios;

namespace EF_FernandoOlivera_POOII.Controllers
{
    public class MantenimientoController : Controller
    {
        // GET: Mantenimiento
        herramientaDTO _herramienta = new herramientaDTO();
        CategoriaDTO _categoria = new CategoriaDTO();

        // Vistas

        //----------------------------------------------------------------------------------

        public ActionResult Index()
        {
            return View(_herramienta.GetAll());
        }

        //--CREATE-------------------------------------------------------------------
        public ActionResult Create()
        {
            ViewBag.categoria = new SelectList(_categoria.GetAll(), "IdCategoria", "NombreCategoria");
            return View(new Herramienta());
        }

        [HttpPost]
        public ActionResult Create(Herramienta reg)
        {
            ViewBag.mensaje = _herramienta.Add(reg);
            ViewBag.categoria = new SelectList(_categoria.GetAll(), "IdCategoria", "NombreCategoria", reg.Idcategoria);
            return View(reg);

        }

        //--UPDATE-------------------------------------------------------------------
        public ActionResult Edit(string id = "")
        {
            Herramienta reg = _herramienta.find(id);
            ViewBag.categoria = new SelectList(_categoria.GetAll(), "IdCategoria", "NombreCategoria", reg.Idcategoria);
            return View(reg);
        }

        [HttpPost]
        public ActionResult Edit(Herramienta reg)
        {
            ViewBag.mensaje = _herramienta.Update(reg);
            ViewBag.categoria = new SelectList(_categoria.GetAll(), "IdCategoria", "NombreCategoria", reg.Idcategoria);
            return View(reg);
        }

        //--DETAILS-------------------------------------------------------------------
        public ActionResult Detail(int id) { 
        }

        //--DELETE--------------------------------------------------------------------



    }
}