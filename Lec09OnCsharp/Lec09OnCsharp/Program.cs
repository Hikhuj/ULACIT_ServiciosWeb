using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lec09OnCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string xml = @"";

            Console.WriteLine(xml);
            Console.ReadLine();

            // Que vamos a hacer, vamos a usar la libreria XmlDocument
            XmlDocument doc = new XmlDocument();

            doc.loadXml(xml);

            string json = JsonConvert.SerializeXmlNode(doc);

            Console.WriteLine(json);
        }
    }
}
