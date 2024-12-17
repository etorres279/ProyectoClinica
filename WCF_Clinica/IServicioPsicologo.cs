using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;

namespace WCF_Clinica
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioPsicologo" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioPsicologo
    {
        [OperationContract]
        PsicologoDC ConsultarPsicologo(Int16 strCodigo);
        [OperationContract]
        List<PsicologoDC> ListarPsicologo(Int16 Estade);

        [OperationContract]
        Boolean InsertarPsicologo(PsicologoDC objPsicologoDC);

        [OperationContract]
        Boolean ActualizarPsicologo(PsicologoDC objPsicologoDC);

        [OperationContract]
        Boolean EliminarPsicologo(Int16 strCodigo);
    }
    [DataContract]
    [Serializable]
    public class PsicologoDC
    {
        [DataMember]
        public Int16 Id_psicologo { get; set; }
        [DataMember]
        public String Nombre { get; set; }
        [DataMember]
        public String Especialidad { get; set; }
        [DataMember]
        public String Telefono { get; set; }
        [DataMember]
        public String Correo { get; set; }

        [DataMember]
        public String Id_ubigeo { get; set; }
        [DataMember]
        public String Departamento { get; set; }
        [DataMember]
        public String Provincia { get; set; }
        [DataMember]
        public String Distrito { get; set; }
        [DataMember]
        public Int16 Estado { get; set; }
        [DataMember]
        public Int16 Estade { get; set; }
        [DataMember]
        public String EstadoPsico { get; set; }


        [DataMember]
        public Byte[] Foto { get; set; }
        [DataMember]
        public DateTime? Fecha_registro { get; set; }
        [DataMember]
        public DateTime? Fecha_ult_modificacion { get; set; }
        [DataMember]
        public String Usuario_registro { get; set; }
        [DataMember]
        public String Usuario_ult_modificacion { get; set; }

    }
}

