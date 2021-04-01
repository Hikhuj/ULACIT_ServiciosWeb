using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Laboratorio2.Models;
namespace Laboratorio2.Datos
{
    public class ClassProductosAlfabetico
    {
        public int Cod_Producto { get; set; }

        public string Nombre_Producto { get; set; }

        public int? Cod_Linea { get; set; }

        public int? Cod_Proveedor { get; set; }

        public bool Descontinuado { get; set; }


        public static List<ClassProductosAlfabetico> obtenerProductosAlfabetico()
        {

            using (var db = new ComercioEntities())
            {
                return (from a in db.Productos
                        orderby a.Nombre_Producto ascending
                        select new ClassProductosAlfabetico
                        {
                            Cod_Producto = a.Cod_Producto,
                            Nombre_Producto = a.Nombre_Producto,
                            Cod_Linea = a.Cod_Linea,
                            Cod_Proveedor = a.Cod_Proveedor,
                            Descontinuado = a.Descontinuado
                        }).ToList();
            }
        }
    }
}

    