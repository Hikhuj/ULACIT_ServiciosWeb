using Laboratorio2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio2
{
    public class ClassProductoLinea
    { 
        public int Cod_Producto { get; set; }

    public string Nombre_Producto { get; set; }

    public int? Cod_Linea { get; set; }

    public int? Cod_Proveedor { get; set; }

    public bool Descontinuado { get; set; }


    public static List<ClassProductoLinea> obtenerProductoLinea()
    {

        using (var db = new ComercioEntities())
        {
            return (from a in db.Productos
                    where a.Cod_Linea == 5
                    select new ClassProductoLinea
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

    