﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ComercioEntities : DbContext
    {
        public ComercioEntities()
            : base("name=ComercioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bitacora> Bitacoras { get; set; }
        public virtual DbSet<Canton> Cantons { get; set; }
        public virtual DbSet<Consecutivo> Consecutivos { get; set; }
        public virtual DbSet<Detalle_Factura> Detalle_Factura { get; set; }
        public virtual DbSet<Detalle_Pedido> Detalle_Pedido { get; set; }
        public virtual DbSet<Distrito> Distritoes { get; set; }
        public virtual DbSet<Errore> Errores { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Linea> Lineas { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Privilegio> Privilegios { get; set; }
        public virtual DbSet<Privilegios_Usuarios> Privilegios_Usuarios { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedore> Proveedores { get; set; }
        public virtual DbSet<Provincia> Provincias { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tipo_Consecutivo> Tipo_Consecutivo { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
