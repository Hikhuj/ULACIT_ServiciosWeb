using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lec12.Streams
{
    public class ImageStream
    {
        public object Boundary { get; set; } = "HintDesk";

        public async Task WriteToStream(Stream outputStream, HttpContent content, TransportContext context)
        {
            byte[] newLine = Encoding.UTF8.GetBytes("\r\n");
            foreach (var file in Directory.GetFiles(@"\Images", "*.jpg"))
            {
                var fileinfo = new FileInfo(file);
                // el simbolo de $ me permite tener escritura sobre esto.
                var header = $"--{Boundary}\r\nContent-Type: image/jpeg\r\nContent-Length:{fileinfo.Length}\r\n\r\n";
                // para decirle el tipo de dato y encoding que le vamos a enviar
                // header = al header anterior que creamos
                var headerData = Encoding.UTF8.GetBytes(header);
                // el await me va a permitir que funcione fuera del hilo principal
                await outputStream.WriteAsync(headerData, 0, headerData.Length);
                // todo debe ser asincrono o vamos a tener problemas
                await fileinfo.OpenRead().CopyToAsync(outputStream);
                await outputStream.WriteAsync(newLine, 0, newLine.Length);
                await Task.Delay(1000 / 30);

            }
        }
    }
}