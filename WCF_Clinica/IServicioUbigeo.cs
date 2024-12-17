using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Clinica
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioUbigeo" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioUbigeo
    {
        [OperationContract]
        List<UbigeoDC> ListarDepartamentos();

        [OperationContract]
        List<UbigeoDC> ListarProvinciasPorDepartamento(string idDepartamento);

        [OperationContract]
        List<UbigeoDC> ListarDistritosPorDepartamentoYProvincia(string idDepartamento, string idProvincia);

        [OperationContract]
        UbigeoDC ConsultarUbigeo(string idUbigeo);

    }

    // Clase de datos para representar la información de Ubigeo
    [DataContract]
    public class UbigeoDC
    {
        [DataMember]
        public string id_ubigeo { get; set; } // id_ubigeo completo

        [DataMember]
        public string idDepa { get; set; } // id del departamento

        [DataMember]
        public string idProv { get; set; } // id de la provincia

        [DataMember]
        public string idDist { get; set; } // id del distrito

        [DataMember]
        public string Departamento { get; set; } // Nombre del departamento

        [DataMember]
        public string Provincia { get; set; } // Nombre de la provincia

        [DataMember]
        public string Distrito { get; set; } // Nombre del distrito
    }
}
