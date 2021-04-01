using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab2.Models;

namespace Lab2.Datos
{
    public class Canton
    {
        public int Cod_Canton { get; set; }
        public string Nombre { get; set; }
        public int? Cod_Provincia { get; set; }

        public static List<Canton> obtenerCantones()
        {
            using (ComercioEntities db = new ComercioEntities())
            {
                return (from a in db.Cantons
                        select new Canton
                        {
                            Cod_Canton = a.Cod_Canton,
                            Nombre = a.Nombre,
                            Cod_Provincia = a.Cod_Provincia
                        }).ToList();
            }
        }
    }
}