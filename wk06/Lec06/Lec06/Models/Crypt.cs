using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Lec06.Models
{
    public class Crypt
    {

        public string Encriptar(string cadena)
        {
            string resultado = string.Empty;
            Byte[] encriptar = new UnicodeEncoding().GetBytes(cadena);
            resultado = Convert.ToBase64String(encriptar);
            return resultado;
        }

        public string Desencriptar(string cadena)
        {
            string resultado = string.Empty;
            Byte[] desencriptar = Convert.FromBase64String(cadena);
            resultado = new UnicodeEncoding().GetString(desencriptar);
            return resultado;
        }

    }
}