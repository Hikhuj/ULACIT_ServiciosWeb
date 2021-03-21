using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;
using Week08.Datos;
using Newtonsoft.Json;
using System.Web;

namespace Week08.Controllers
{
    public class ArticulosController : ApiController
    {
        // GET: api/Articulos
        public string Get()
        {

            string resultado = string.Empty;

            // Creamos un MemoryStream para gestionar el XML para poder tener un documento 
            using (MemoryStream ms = new MemoryStream())
            {
                XmlWriterSettings xws = new XmlWriterSettings();
                xws.OmitXmlDeclaration = true;
                xws.Indent = true;

                // ms es un valor por referencia (de salida)
                using (XmlWriter xw = XmlWriter.Create(ms, xws))
                {
                    // Vamos a buscar obtener un XML de una lista de cosas, en este caso vamos a obtener la lista de articulos o producto de forma completa de la DB
                    XDocument documento = new XDocument(
                            new XDeclaration("1.0", "utf-8", null),
                            // "Productos" es igual al nombre de la lista
                            // Esta funcion de obtenerArticulos() esta asociado a la funcion que se creo en Datos/Articulos para obtenerlos
                            new XElement("Productos", from producto in Articulos.obtenerArticulos()
                                                      select new XElement("Codigo",
                                                          new XAttribute("Cod_Producto", producto.Cod_Producto),
                                                          new XElement("Nombre", producto.Nombre_Producto),
                                                          new XElement("Linea", producto.Cod_Linea),
                                                          new XElement("Proveedor", producto.Cod_Proveedor),
                                                          new XElement("Descontinuado", producto.Descontinuado))
                                                      ));
                    // Ya para aca genera el documento
                    documento.WriteTo(xw);
                }

                // Cuando tengo el archivo, lo mando a serializar con JSON
                var json = new
                {
                    archivo = ms.ToArray()
                };

                // Este mae me va a regresar el amigo
                // Va a serializar el objeto
                // La serializacion y descerializacion de objetos permite, en este caso
                // tomar un objeto de tipo JSON y convertirlo en string
                // por el contrario, la deserealizacion es tomar ese string y convertirlo en un JSON
                resultado = JsonConvert.SerializeObject(json);

            }



            // Retorma todo el documento en formato String para el API client
            return resultado;

        }

        // POST: api/Articulos
        public void Post()
        {
            // En esta funcion vamos a subir archivos

            // Con el Files va a tomar los archivos que le vamos a mandar
            var archivo = HttpContext.Current.Request.Files;
            byte[] datosArchivo = null;
            // usando este using nos permite declarar un ambito local y no global como hariamos cuando
            // llamamos arriba
            using (var binaryReader = new BinaryReader(archivo[0].InputStream))
            {
                datosArchivo = binaryReader.ReadBytes(archivo[0].ContentLength);
                // Dar un path especifico a donde enviar un archivo y donde guardarlo
                File.WriteAllBytes(@"C:\Prueba\test.txt", datosArchivo);
            }
        }

    }
}
