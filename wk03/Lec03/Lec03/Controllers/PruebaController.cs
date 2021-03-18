using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lec03.Models;
using Lec03.Data;

namespace Lec03.Controllers
{
    public class PruebaController : ApiController
    {
        // GET: api/Prueba
        public IEnumerable<string> Get()
        {
            return new GestorPersona().listarPersonas();
        }

        // GET: api/Prueba/5
        public string Get(int id)
        {
            // FirstOrDefault() = Devuelve el primer elemento de la secuencia
            // o si no tiene devuelve un valor por defautl.
            // Tiene que ser un enumerable para poder usar esa funcion.
            return GestorPersona.listarPersonas.Where(e=>e.id==id).FirstOrDefault();
        }


    }
}
