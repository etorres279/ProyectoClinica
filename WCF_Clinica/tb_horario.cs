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
    
    public partial class tb_horario
    {
        public int id_horario { get; set; }
        public Nullable<int> id_psicologo { get; set; }
        public Nullable<int> id_consultorio { get; set; }
        public Nullable<System.TimeSpan> hora_inicio { get; set; }
        public Nullable<System.TimeSpan> hora_fin { get; set; }
    
        public virtual tb_consultorio tb_consultorio { get; set; }
        public virtual tb_psicologo tb_psicologo { get; set; }
    }
}
