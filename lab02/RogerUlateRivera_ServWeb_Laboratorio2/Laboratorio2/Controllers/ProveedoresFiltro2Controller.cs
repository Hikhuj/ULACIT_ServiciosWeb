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
    public class ProveedoresFiltro2Controller : ApiController
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
                new XElement("Proveedores", from Proveedores2 in ClassProveedoresFiltro2.obtenerProveedoresFiltro2()
                                          select new XElement("Código",
                                            new XAttribute("Nombre_Proveedor", Proveedores2.Nombre_Proveedor),
                                            new XElement("Telefono", Proveedores2.Telefono),
                                            new XElement("Cod_Linea", Proveedores2.Direccion))
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
