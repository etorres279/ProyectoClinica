//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCF_Clinica
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_local
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_local()
        {
            this.tb_consultorio = new HashSet<tb_consultorio>();
        }
    
        public int id_local { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public int id_administrador { get; set; }
        public string id_ubigeo { get; set; }
        public Nullable<System.DateTime> Fecha_registro { get; set; }
        public Nullable<System.DateTime> Fecha_ult_modificacion { get; set; }
        public string Usuario_registro { get; set; }
        public string Usuario_ult_modificacion { get; set; }
        public Nullable<System.TimeSpan> inicio { get; set; }
        public Nullable<System.TimeSpan> fin { get; set; }
    
        public virtual tb_administrador tb_administrador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_consultorio> tb_consultorio { get; set; }
        public virtual tb_Ubigeo tb_Ubigeo { get; set; }
    }
}
