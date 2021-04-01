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
    public class ProveedoresFiltro1Controller : ApiController
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
                new XElement("Proveedores", from Proveedores in ClassProveedoresFiltro1.obtenerProveedoresFiltro1()
                                          select new XElement("Código",
                                            new XAttribute("Nombre_Proveedor", Proveedores.Nombre_Proveedor),
                                            new XElement("Telefono", Proveedores.Telefono),
                                            new XElement("Cod_Linea", Proveedores.Direccion))
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