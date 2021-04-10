using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Lec12.Streams
{
    public class VideoStream
    {
        private readonly string videoName;
        public VideoStream(string videoName)
        {
            this.videoName = videoName;
        }

        // vamos a hacer una tarea asincrona ya que es un hilo
        // public async Task WriteToStream(Stream outputStream, HttpContent content, TransportContext context)
        public async Task WriteToStream(Stream outputStream, 
                                        HttpContent content,
                                        TransportContext context)
        {
            // Vamos a indicar la ruta del video o donde este el video
            // string videoFileName = "\\Video\\Christmas.mp4";
            // otra forma interesante puede ser
            // De esta forma podriamos trabajar un poco mas dinamicos sin ser tan estaticos
            string videoFileName = "\\Video\\" + videoName + ".mp4";
            try
            {
                var buffer = new byte[65536];
                // vamos a usar using para describir un segmento que vamos a utilizar en un pequenio espacio del codigo
                // por eso lo usamos dentro de un try/catch sin que afecte la funcionalidad completa del proyecto
                using (var video = File.Open(videoFileName, FileMode.Open, FileAccess.Read))
                {
                    var length = (int)video.Length;
                    var bytesRead = 1;
                    while (length > 0 && bytesRead > 0)
                    {
                        bytesRead = video.Read(buffer, 0, Math.Min(length, buffer.Length));
                        await outputStream.WriteAsync(buffer, 0 ,bytesRead);
                        length -= bytesRead;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}