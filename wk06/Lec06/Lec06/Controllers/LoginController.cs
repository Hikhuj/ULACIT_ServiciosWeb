using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lec06.Data;
using Lec06.Models;

namespace Lec06.Controllers
{
    public class LoginController : ApiController
    {
        // GET: api/Login
        public List<Login> Get()
        {
            return Datos.listaUsuarios;
        }

        // GET: api/Login/5
        public Login Get(int id)
        {
            Crypt c = new Crypt();
            Login login = Datos.listaUsuarios.ElementAt(id);
            Login resultado = new Login();
            resultado.nombre = login.nombre;
            resultado.pass = c.Desencriptar(login.pass);
            return resultado;
        }

        // POST: api/Login
        public void Post([FromBody]Login usuario)
        {
            Crypt c = new Crypt();
            usuario.pass = c.Encriptar(usuario.pass);
            Datos.listaUsuarios.Add(usuario);
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
