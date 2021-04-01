using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Laboratorio2.Models;
namespace Laboratorio2.Datos
{

    public class ClassCanton
    {
        public int Cod_Canton { get; set; }

        public string Nombre { get; set; }

        public int? Cod_Provincia { get; set; }


  
        public static List<ClassCanton> obtenerCanton()
        {

            using (var db = new ComercioEntities())
            {
                return (from a in db.Canton
                        where a.Cod_Provincia == 4 || a.Cod_Provincia == 6
                        select new ClassCanton
                        {
                            Cod_Canton = a.Cod_Canton,
                            Nombre = a.Nombre,
                            Cod_Provincia = a.Cod_Provincia
                        }).ToList();
            }
        }
    }
}
