using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lec03.Models
{
    public class GestorPersona
    {

        List<Persona> listaPersonas = new List<Persona>();
        string[] nombres = new string[] { 
            "Roger",
            "Esteban",
            "Carlos",
            "Daniel",
            "Javier",
            "Miguel",
            "Jose",
            "Javier",
            "Lucia",
            "Pedro"
        };

        string[] apellidos = new string[] {
            "Cerrano",
            "Brenes",
            "Gomez",
            "Solano",
            "Castro",
            "Tenorio",
            "Mora",
            "Solis",
            "Zeledon",
            "Madrigal"
        };

        public List<Persona> listarPersonas()
        {
            for (int i=0; i < 10; i++)
            {
                int numero = random.Next(0,9);
                string nombre = nombres[numero] + " ";
                numero = random.Next(0,9);
                nombre += apellidos[numero];
                GestorPersona p = new GestorPersona(i + 1, nombre, (int) i + 1 * 50 / 3);
                listaPersonas.Add(p);

            }
            return null;
        }


    }
}