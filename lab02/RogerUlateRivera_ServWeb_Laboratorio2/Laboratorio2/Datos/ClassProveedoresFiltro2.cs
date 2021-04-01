using Laboratorio2.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Web;

namespace Laboratorio2
{
    public class ClassProveedoresFiltro2
    {
   

        public int Cod_Proveedor { get; set; }
        public string Nombre_Proveedor { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public static List<ClassProveedoresFiltro2> obtenerProveedoresFiltro2()
        {

            using (var db = new ComercioEntities())
            {
                return (from a in db.Proveedores
                        where a.Direccion.Contains("Cartago") || a.Direccion.Contains("Guanacaste")
                        select new ClassProveedoresFiltro2
                        {
                            Cod_Proveedor = a.Cod_Proveedor,
                            Nombre_Proveedor = a.Nombre_Proveedor,
                            Telefono = a.Telefono,
                            Direccion = a.Direccion
                        }).ToList();
            }
        }
    }
}