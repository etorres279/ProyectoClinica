using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Clinica
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicioCita" in both code and config file together.
    [ServiceContract]
    public interface IServicioCita
    {
        [OperationContract]
        List<CitaDC> ListarCitasPacientePorFecha(int codigo, DateTime FecIni, DateTime FecFin);

        [OperationContract]
        List<CitaDC> ListarCitasPorFecha(DateTime FecIni, DateTime FecFin, int estade);

        [OperationContract]
        CitaDC ConsultarCita(int codigo);

        [OperationContract]
        Boolean InsertarCita(CitaDC objCitaDC);
        [OperationContract]
        Boolean ActualizarCita(CitaDC objCitaDC);
        [OperationContract]
        Boolean EliminarCita(int codigo);
        [OperationContract]
        bool ExisteCitaConflicto(int idPsicologo, int idPaciente, DateTime fecha, TimeSpan hora, int duracion);
    }

    [DataContract]
    [Serializable]
    public class CitaDC
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public DateTime fecha { get; set; }
        [DataMember]
        public TimeSpan hora { get; set; }
        [DataMember]
        public int id_psicologo { get; set; }
        [DataMember]
        public String psicologo { get; set; }
        [DataMember]
        public int id_paciente { get; set; }
        [DataMember]
        public String paciente { get; set; }
        [DataMember]
        public int id_consultorio { get; set; }
        [DataMember]
        public int estado { get; set; }
        [DataMember]
        public int estade { get; set; }
        [DataMember]
        public int id_historial { get; set; }
        [DataMember]
        public DateTime fecha_registro { get; set; }
        [DataMember]
        public DateTime fecha_ult_modificacion { get; set; }
        [DataMember]
        public String usuario_registro { get; set; }
        [DataMember]
        public String usuario_ult_modificacion { get; set; }
        [DataMember]
        public string motivo_cita { get; set; }

        [DataMember]
        public int? duracion { get; set; }

        [DataMember]
        public string tipo_cita { get; set; }

        [DataMember]
        public decimal? precio { get; set; }

        [DataMember]
        public string estado_pago { get; set; }

        [DataMember]
        public int confirmacion_asistencia { get; set; }
    }
}
