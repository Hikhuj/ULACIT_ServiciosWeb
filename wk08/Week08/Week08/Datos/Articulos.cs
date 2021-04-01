using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Week08.Models;

namespace Week08.Datos
{
    public class Articulos
    {

        public int Cod_Producto { get; set; }

        public string Nombre_Producto { get; set; }

        // EL signo de interrogacion le permite al sistema hacer una conversion
        // implicita para evitar errores, entonces si no hay numero, lo convierte a cero.
        public int? Cod_Linea { get; set; }

        public int? Cod_Proveedor { get; set; }

        public bool Descontinuado { get; set; }

        // Metodo estatico que retorne un objeto de tipo lista de los articulos
        // Agrego la liberia de los modelos para referenciar
        // Este metodo va a ser usado en el controlador para obtener la lista de datos de la DB
        public static List<Articulos> obtenerArticulos()
        {
            using (ComercioEntities db = new ComercioEntities())
            {
                return (from a in db.Productos
                    // aqui estoy dando nombre a un nuevo objeto del que ocupo usar
                        select new Articulos
                        {
                            Cod_Producto = a.Cod_Producto,
                            Cod_Proveedor = a.Cod_Proveedor,
                            Nombre_Producto = a.Nombre_Producto,
                            Cod_Linea = a.Cod_Linea
                        }).ToList();
            } 
        }
    }
}