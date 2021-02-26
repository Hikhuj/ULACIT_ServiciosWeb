using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lec06.Data
{
    public class Login
    {

        private string _nombre;
        private string _pass;

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string pass
        {
            get { return _pass; }
            set { _pass = value; }
        }

    }
}