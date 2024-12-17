using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Clinica
{
    [ServiceContract]
    public interface IServicioPaciente
    {
        [OperationContract]
        PacienteDC ConsultarPaciente(Int16 id_paciente);

        [OperationContract]
        List<PacienteDC> ListarPaciente(Int16 estade);

        [OperationContract]
        Boolean InsertarPaciente(PacienteDC objPacienteDC);

        [OperationContract]
        Boolean ActualizarPaciente(PacienteDC objPacienteDC);

        [OperationContract]
        Boolean EliminarPaciente(Int16 id_paciente);


    }
    [DataContract]
    [Serializable]

    public class PacienteDC
    {
        [DataMember]
        public Int16 id_paciente { get; set; }
        [DataMember]
        public String nombres { get; set; }
        [DataMember]
        public String apellidos { get; set; }
        [DataMember]
        public String genero { get; set; }

        [DataMember]
        public String telefono { get; set; }
        [DataMember]
        public Byte[] foto { get; set; }

        [DataMember]
        public String correo { get; set; }
        [DataMember]
        public String id_ubigeo { get; set; }
        [DataMember]
        public Int16 estado { get; set; }
        [DataMember]
        public Int16 estade { get; set; }
        [DataMember]
        public DateTime? FechaNacimiento { get; set; }

        [DataMember]
        public DateTime? Fecha_Registro { get; set; }

        [DataMember]
        public DateTime? Fecha_ult_modificacion { get; set; }
        [DataMember]
        public String Usuario_Registro { get; set; }

        [DataMember]
        public String Usuario_ult_modificacion { get; set; }

        [DataMember]
        public String Distrito { get; set; }

        [DataMember]
        public String Departamento { get; set; }

        [DataMember]
        public String Provincia { get; set; }

        [DataMember]
        public Int16 Edad {  get; set; }
    }   


}
