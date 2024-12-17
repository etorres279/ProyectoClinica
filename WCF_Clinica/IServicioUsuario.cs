using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Clinica
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioUsuario" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioUsuario
    {
        [OperationContract]
        UsuarioDC Login(string username, string password);
    }

    [DataContract]
    [Serializable]

    public class UsuarioDC
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int Nivel { get; set; }
        [DataMember]
        public int Estado { get; set; }
    }
}
