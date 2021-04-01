using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab2.Models;

namespace Lab2.Datos
{
    public class Proveedor
    {

        public int Cod_Proveedor { get; set; }

        public string Nombre_Proveedor { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public static List<Proveedor> obtenerProveedores()
        {
            using (ComercioEntities db = new ComercioEntities())
            {
                return (from a in db.Proveedores
                        // Proveedores
                        select new Proveedor
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