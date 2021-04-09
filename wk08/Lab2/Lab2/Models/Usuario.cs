//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.Bitacoras = new HashSet<Bitacora>();
            this.Errores = new HashSet<Errore>();
            this.Privilegios_Usuarios = new HashSet<Privilegios_Usuarios>();
        }
    
        public int Cod_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Pri_Ape { get; set; }
        public string Seg_Ape { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public string Confirmar_Pass { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public Nullable<bool> Admin_Seg { get; set; }
        public Nullable<bool> Admin_Ad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bitacora> Bitacoras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Errore> Errores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Privilegios_Usuarios> Privilegios_Usuarios { get; set; }
    }
}