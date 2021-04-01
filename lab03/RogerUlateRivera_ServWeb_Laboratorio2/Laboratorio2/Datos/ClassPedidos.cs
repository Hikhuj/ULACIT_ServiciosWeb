using Laboratorio2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio2
{
    public class ClassPedidos
    {

        public int Num_Pedido { get; set; }

        public DateTime Fecha_Pedido { get; set; }

        public decimal Monto_Pedido { get; set; }

        public int? Cod_Proveedor { get; set; }

        public static List<ClassPedidos> retornarPedidos()
        {

            using (var db = new ComercioEntities())
            {
                return (from a in db.Pedidos
                        where a.Cod_Proveedor == 3
                        select new ClassPedidos
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