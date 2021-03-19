using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wk08.Models;

namespace wk08.Datos
{
    public class Articulos
    {
        public int Cod_Producto { get; set; }
        public string Nombre_Producto { get; set; }
        // el int? permite que haga un casteo que por si el valor viene NULL
        // haga una conversion implicita a 0
        public int? Cod_Linea { get; set; }
        public int? Cod_Proveedor { get; set; }
        public bool Descontinuado { get; set; }

        // Usar un elemento propio de Entity Framework
        // Retornaremos una lista de la propia clase de articulos
        public static List<Articulos> obtenerArticulos()
        {
            // Una forma de programacion avanzada
            using (ComercioEntities db = new ComercioEntities())
            {
                // expresion LINQ
                // con esta expresion el sistema siempre va a devolver una lista
                return (from a in db.Productos
                        select new Articulos
                        {
                            Cod_Producto = a.Cod_Producto,
                            Cod_Proveedor = a.Cod_Proveedor,
                            Nombre_Producto = a.Nombre_Producto,
                            Cod_Linea = a.Cod_Linea,
                            Descontinuado = a.Descontinuado
                        }).ToList();
            }
        }
    }
}