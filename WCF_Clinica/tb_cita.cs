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
    
    public partial class tb_cita
    {
        public int id_cita { get; set; }
        public System.DateTime fecha { get; set; }
        public Nullable<System.TimeSpan> hora { get; set; }
        public int id_psicologo { get; set; }
        public int id_paciente { get; set; }
        public int id_consultorio { get; set; }
        public Nullable<int> estado { get; set; }
        public Nullable<int> id_historial { get; set; }
        public Nullable<System.DateTime> Fecha_registro { get; set; }
        public Nullable<System.DateTime> Fecha_ult_modificacion { get; set; }
        public string Usuario_registro { get; set; }
        public string Usuario_ult_modificacion { get; set; }
        public string motivo_cita { get; set; }
        public Nullable<int> duracion { get; set; }
        public string tipo_cita { get; set; }
        public Nullable<decimal> precio { get; set; }
        public string estado_pago { get; set; }
        public Nullable<int> confirmacion_asistencia { get; set; }
    
        public virtual tb_historial_clinico tb_historial_clinico { get; set; }
    }
}
