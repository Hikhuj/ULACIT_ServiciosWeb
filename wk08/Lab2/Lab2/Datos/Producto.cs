using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab2.Models;

namespace Lab2.Datos
{
    public class Producto
    {
        public int Cod_Producto { get; set; }

        public string Nombre_Producto { get; set; }

        public int? Cod_Linea { get; set; }

        public int? Cod_Proveedor { get; set; }

        public bool Descontinuado { get; set; }

        // Metodo estatico que retorne un objeto de tipo lista de los articulos
        // Agrego la liberia de los modelos para referenciar
        // Este metodo va a ser usado en el controlador para obtener la lista de datos de la DB
        public static List<Producto> obtenerProductos()
        {
            using (ComercioEntities db = new ComercioEntities())
            {
                return (from a in db.Productos
                        select new Producto
                        {
                            Cod_Producto = a.Cod_Producto,
                            Cod_Proveedor = a.Cod_Proveedor,
                            Nombre_Producto = a.Nombre_Producto,
                            Cod_Linea = a.Cod_Linea
                        }).ToList();
            }
        }

        public static List<Producto> ordenAlfabetico()
        {
            using (ComercioEntities db = new ComercioEntities())
            {
                return (from a in db.Productos
                        orderby a.Nombre_Producto ascending
                        select new Producto
                        {
                            Cod_Producto = a.Cod_Producto,
                            Cod_Proveedor = a.Cod_Proveedor,
                            Nombre_Producto = a.Nombre_Producto,
                            Cod_Linea = a.Cod_Linea
                        }).ToList();
            }
        }

        public static List<Producto> productosVacunos(int codigo_linea_producto)
        {
            using (ComercioEntities db = new ComercioEntities())
            {
                return (from a in db.Productos
                        where a.Cod_Linea == codigo_linea_producto
                        select new Producto
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