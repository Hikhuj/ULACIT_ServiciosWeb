using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;

namespace Laboratorio2.Controllers
{
    public class ProductoLineaController : ApiController
    {
        public string Get()
        {

            string resultado = string.Empty;
            using (MemoryStream ms = new MemoryStream())
            {
                XmlWriterSettings xws = new XmlWriterSettings();
                xws.OmitXmlDeclaration = true;
                xws.Indent = true;

                using (XmlWriter xw = XmlWriter.Create(ms, xws))
                {
                    XDocument documento = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("Productos", from productos2 in ClassProductoLinea.obtenerProductoLinea()
                                          select new XElement("Código",
                                            new XAttribute("Cod_Producto", productos2.Cod_Producto),
                                            new XElement("Nombre_Producto", productos2.Nombre_Producto),
                                            new XElement("Cod_Linea", productos2.Cod_Linea),
                                            new XElement("Descontinuado", productos2.Descontinuado))
                                          ));
                    documento.WriteTo(xw);
                }
                var json = new
                {
                    archivo = ms.ToArray()
                };
                resultado = JsonConvert.SerializeObject(json);
            }

            return resultado;
        }
    }

}