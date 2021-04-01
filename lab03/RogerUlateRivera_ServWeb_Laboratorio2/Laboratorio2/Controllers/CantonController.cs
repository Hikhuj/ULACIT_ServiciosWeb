using System;
using System.Collections.Generic;
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
    public class CantonController : ApiController
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
                new XElement("Cantones", from canton in ClassCanton.obtenerCanton()
                                          select new XElement("Código",
                                            new XAttribute("Cod_Canton", canton.Cod_Canton),
                                            new XElement("Nombre", canton.Nombre),
                                            new XElement("Cod_Provincia", canton.Cod_Provincia))                                           
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
