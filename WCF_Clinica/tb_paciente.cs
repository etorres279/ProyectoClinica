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
    
    public partial class tb_paciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_paciente()
        {
            this.tb_historial_clinico = new HashSet<tb_historial_clinico>();
        }
    
        public int id_paciente { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string genero { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string id_ubigeo { get; set; }
        public Nullable<int> estado { get; set; }
        public byte[] foto { get; set; }
        public Nullable<System.DateTime> Fecha_registro { get; set; }
        public Nullable<System.DateTime> Fecha_ult_modificacion { get; set; }
        public string Usuario_registro { get; set; }
        public string Usuario_ult_modificacion { get; set; }
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_historial_clinico> tb_historial_clinico { get; set; }
        public virtual tb_Ubigeo tb_Ubigeo { get; set; }
    }
}
