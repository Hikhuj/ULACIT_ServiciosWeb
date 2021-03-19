using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;
using wk08.Datos;

namespace wk08.Controllers
{
    public class ArticulosController : ApiController
    {
        // GET: api/Articulos
        public string Get()
        {
            XDocument documento = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                // va a declarar elementos por dentro
                new XElement("Productos", from producto in Articulos.obtenerArticulos()
                                          select new XElement("Código",
                                          new XAttribute("Cod_Producto", producto.Cod_Producto),
                                          new XElement("Nombre", producto.Nombre_Producto),
                                          new XElement("Linea", producto.Cod_Linea),
                                          new XElement("Proveedor", producto.Cod_Proveedor),
                                          new XElement("Descontinuado", producto.Nombre_Producto))
                                          ));
            return documento.Document.ToString();
        }

        // GET: api/Articulos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Articulos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Articulos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Articulos/5
        public void Delete(int id)
        {
        }
    }
}
