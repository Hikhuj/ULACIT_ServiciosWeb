using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab2.Models;

namespace Lab2.Datos
{
    public class Pedido
    {
        public int Num_Pedido { get; set; }
        public DateTime Fecha_Pedido { get; set; }
        public decimal Monto_Pedido { get; set; }
        public int? Cod_Proveedor { get; set; }

        public static List<Pedido> obtenerPedido()
        {
            using (ComercioEntities db = new ComercioEntities())
            {
                return (from a in db.Pedidos
                        // Pedidos
                        select new Pedido
                        {
                            Num_Pedido = a.Num_Pedido,
                            Fecha_Pedido = a.Fecha_Pedido,
                            Monto_Pedido = a.Monto_Pedido,
                            Cod_Proveedor = a.Cod_Proveedor
                        }).ToList();
            }
        }
    }
}