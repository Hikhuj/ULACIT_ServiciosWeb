﻿using System;
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

        public int? Cod_Linea { get; set; }

        public int? Cod_Proveedor { get; set; }

        public bool Descontinuado { get; set; }

        // Metodo estatico que retorne un objeto de tipo lista de los articulos
        // Agrego la liberia de los modelos para referenciar
        public static List<Articulos> obtenerArticulos()
        {
            using (ComercioEntities db = new ComerEntities())
            {
                return (from a in db.Productos
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