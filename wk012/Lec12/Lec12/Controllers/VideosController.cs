using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lec12.Controllers
{
    public class VideosController : ApiController
    {
        public HttpResponseMessage Get()
        {
            // Para pasar los videos que tenemos
            IEnumerable<string> videos = new List<string>() { "Christmas", "Illumination" };
            // esta es una forma de retornar los videos de la lista que tenemos
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, videos);
            return response;
        }
    }
}
