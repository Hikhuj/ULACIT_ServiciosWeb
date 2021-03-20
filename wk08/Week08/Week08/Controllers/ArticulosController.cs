using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Xml.Linq;
using Week08.Datos;

namespace Week08.Controllers
{
    public class ArticulosController : Controller
    {
        // GET: api/Articulos
        public string Get()
        {
            XDocument documento = new XDocument(
                    new XDeclaration("1.0", "utf-8", null),
                    new XElement("Productos", from producto in Articulos.obtenerArticulos()
                                              select new XElement("Código", new XAttribute("Cod_Producto", producto.Cod_Producto),
                                              new XElement("Nombre", producto.Nombre_Producto),
                                              new XElement("Linea", producto.Cod_Linea),
                                              new XElement("Proveedor", producto.Cod_Proveedor),
                                              new XElement("Descontinuado", producto.Descontinuado))
                                              ));
            return documento.Document.ToString();
        }

        // GET: Articulos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Articulos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articulos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Articulos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Articulos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
