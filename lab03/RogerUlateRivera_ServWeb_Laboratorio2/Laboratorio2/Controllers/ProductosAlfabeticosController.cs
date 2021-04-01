using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;
using Laboratorio2.Datos;
using Newtonsoft.Json;

namespace Laboratorio2.Controllers
{
    public class ProductosAlfabeticosController : ApiController
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
                    new XElement("Productos", from productos in ClassProductosAlfabetico.obtenerProductosAlfabetico()
                                              select new XElement("Código",
                                                new XAttribute("Cod_Producto", productos.Cod_Producto),
                                                new XElement("Nombre_Producto", productos.Nombre_Producto),
                                                new XElement("Cod_Linea", productos.Cod_Linea),
                                                new XElement("Descontinuado", productos.Descontinuado))
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

