using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Lec12.Streams;

namespace Lec12.Controllers
{
    public class CamaraController : ApiController
    {
        [HttpGet]
        // Para referenciar
        // Vamos a indicar lo que vamos a hacer
        public HttpResponseMessage FromImage()
        {
            var imageStream = new ImageStream();
            // Como para hacer la funcion asyncrona
            // Esta es una funcion anonima este ultimo Task es
            // el tipo de resultado de la tarea que tenemos en el Image
            // Aqui estamos poniendo los valores que se ocupan
            // las funciones anonimas indicar que los primeros valores son los que
            // ocupa de entrada y el ultimo es la salida de este
            Func<Stream, HttpContent, TransportContext, Task> func = imageStream.WriteToStream;
            var response = Request.CreateResponse();
            response.Content = new PushStreamContent(func);
            response.Content.Headers.Remove("Content-Type");
            response.Content.Headers.TryAddWithoutValidation("Content-Type", "multipart/x-mixed-replace:boundary=" + imageStream.Boundary);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage FromVideo(string videoName)
        {
            var video = new VideoStream(videoName);
            // Como para hacer la funcion asyncrona
            // Esta es una funcion anonima este ultimo Task es
            // el tipo de resultado de la tarea que tenemos en el Image
            // Aqui estamos poniendo los valores que se ocupan
            // las funciones anonimas indicar que los primeros valores son los que
            // ocupa de entrada y el ultimo es la salida de este
            Func<Stream, HttpContent, TransportContext, Task> func = video.WriteToStream;
            var response = Request.CreateResponse();
            response.Content = new PushStreamContent(func, new MediaTypeHeaderValue("video/mp4"));
            return response;

            // Esta nota es para desplegar el video
            // "camera/fromvideo/?videoName=" +
            // Para consumir el video.

            // Para el laboratorio es que se desplieguen todas las imagenes.

        }
    }
}
