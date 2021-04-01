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
    public class PedidosController : ApiController
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
                new XElement("Pedidos", from Pedidos in ClassPedidos.retornarPedidos()
                                          select new XElement("Código",
                                            new XAttribute("Num_Pedido", Pedidos.Num_Pedido),
                                            new XElement("Fecha_Pedido", Pedidos.Fecha_Pedido),
                                            new XElement("Monto_Pedido", Pedidos.Monto_Pedido),
                                            new XElement("Cod_Proveedor", Pedidos.Cod_Proveedor))
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


