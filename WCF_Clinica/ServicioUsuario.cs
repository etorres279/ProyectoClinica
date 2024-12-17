using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Clinica
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioUsuario" en el código y en el archivo de configuración a la vez.
    public class ServicioUsuario : IServicioUsuario
    {
        public UsuarioDC Login(string username, string password)
        {
            try
            {
                // Validación básica de los parámetros
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    throw new FaultException("El nombre de usuario y la contraseña son obligatorios.");
                }

                using (ClinPsicologicaEntities db = new ClinPsicologicaEntities())
                {
                    // Obtener el usuario de la base de datos
                    var user = db.tb_Usuarios
                                 .Where(u => u.UsuarioID == username)
                                 .Select(u => new
                                 {
                                     u.UsuarioID,
                                     u.Pass_Usuario,
                                     u.Niv_Usuario, // Nivel del usuario
                                     u.est_usuario  // Estado del usuario (bool o bit)
                                 })
                                 .FirstOrDefault();

                    // Validar que el usuario exista
                    if (user == null)
                        throw new FaultException("Usuario o contraseña incorrectos.");

                    // Verificar la contraseña (asumiendo que está almacenada como hash)
                    if (!VerifyPassword(password, user.Pass_Usuario))
                        throw new FaultException("Usuario o contraseña incorrectos.");

                    // Mapear los datos al objeto UsuarioDC
                    return new UsuarioDC
                    {
                        Username = user.UsuarioID,
                        Password = null, // No se devuelve la contraseña por seguridad
                        Nivel = user.Niv_Usuario, // Asignación directa si es int
                        Estado = user.est_usuario ? 1 : 0 // Conversión explícita de bool a int
                    };
                }
            }
            catch (FaultException)
            {
                // Relanzar excepciones conocidas
                throw;
            }
            catch (Exception)
            {
                // Manejo genérico de excepciones
                throw new FaultException("Ocurrió un error inesperado al iniciar sesión.");
            }
        }
        /// <param name="password">Contraseña proporcionada por el usuario.</param>
        /// <param name="hashedPassword">Hash de la contraseña almacenada.</param>
        private bool VerifyPassword(string password, string hashedPassword)
        {
            // Simulación de verificación de hash (reemplazar con una implementación real, como BCrypt)
            return password == hashedPassword;
        }
    }
}
