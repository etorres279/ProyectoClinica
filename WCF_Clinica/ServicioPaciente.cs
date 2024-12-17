using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Entity.Core;

namespace WCF_Clinica
{
    public class ServicioPaciente : IServicioPaciente
    {
        public PacienteDC ConsultarPaciente(Int16 id_paciente)
        {
            try
            {
                using (var objClinica = new ClinPsicologicaEntities())
                {
                    var resultado = objClinica.usp_ConsultarPaciente(Convert.ToInt16(id_paciente)).FirstOrDefault();
                    if (resultado == null) return null;

                    // Calcular la edad
                    int edad = resultado.fecha_nacimiento.HasValue ?
                        (DateTime.Now.Year - resultado.fecha_nacimiento.Value.Year -
                        (DateTime.Now < resultado.fecha_nacimiento.Value.AddYears(DateTime.Now.Year - resultado.fecha_nacimiento.Value.Year) ? 1 : 0)) : 0;

                    return new PacienteDC
                    {
                        id_paciente = Convert.ToInt16(resultado.id_paciente),
                        nombres = resultado.nombres,
                        apellidos = resultado.apellidos,
                        genero = resultado.genero,
                        telefono = resultado.telefono,
                        correo = resultado.correo,
                        id_ubigeo = resultado.id_ubigeo,
                        estado = Convert.ToInt16(resultado.estado),
                        FechaNacimiento = resultado.fecha_nacimiento, // Asegúrate de que este campo se esté recuperando
                        Fecha_Registro = resultado.Fecha_registro,
                        Fecha_ult_modificacion = resultado.Fecha_ult_modificacion,
                        Usuario_Registro = resultado.Usuario_registro,
                        Usuario_ult_modificacion = resultado.Usuario_ult_modificacion,
                        foto = resultado.foto,
                        Departamento = resultado.nombre_departamento,
                        Provincia = resultado.nombre_provincia,
                        Distrito = resultado.nombre_distrito,
                        Edad = Convert.ToInt16(edad) // Agregar la propiedad Edad
                    };
                }
            }
            catch (EntityException ex)
            {
                throw new Exception("Error al consultar el paciente: " + ex.Message);
            }
        }

        public List<PacienteDC> ListarPaciente(Int16 estade)
        {
            try
            {
                using (var objClinica = new ClinPsicologicaEntities())
                {
                    // Filtrar pacientes según el estado proporcionado
                    var pacientes = from p in objClinica.tb_paciente // Asegúrate de que "tb_paciente" sea el nombre correcto de la tabla
                                    where (p.estado == estade || p.estado == 1) // Filtrar por estado
                                    select new
                                    {
                                        p.id_paciente,
                                        p.nombres,
                                        p.apellidos,
                                        p.genero,
                                        p.fecha_nacimiento,
                                        p.telefono,
                                        p.correo,
                                        p.id_ubigeo,
                                        p.estado,
                                        p.Fecha_registro,
                                        p.Fecha_ult_modificacion,
                                        p.Usuario_registro,
                                        p.Usuario_ult_modificacion,
                                    };

                    // Proyectar a PacienteDC y realizar las conversiones necesarias
                    return pacientes.AsEnumerable().Select(p => new PacienteDC
                    {
                        id_paciente = Convert.ToInt16(p.id_paciente), // Conversión a short
                        nombres = p.nombres,
                        apellidos = p.apellidos,
                        genero = p.genero,
                        FechaNacimiento = p.fecha_nacimiento,
                        telefono = p.telefono,
                        correo = p.correo,
                        id_ubigeo = p.id_ubigeo,
                        estado = Convert.ToInt16(p.estado), // Conversión a short
                        Fecha_Registro = p.Fecha_registro,
                        Fecha_ult_modificacion = p.Fecha_ult_modificacion,
                        Usuario_Registro = p.Usuario_registro,
                        Usuario_ult_modificacion = p.Usuario_ult_modificacion,
                        // Calcular la edad directamente en la proyección
                        Edad = Convert.ToInt16(p.fecha_nacimiento.HasValue ?
                            (DateTime.Now.Year - p.fecha_nacimiento.Value.Year -
                            (DateTime.Now < p.fecha_nacimiento.Value.AddYears(DateTime.Now.Year - p.fecha_nacimiento.Value.Year) ? 1 : 0)) : 0)
                    }).ToList();
                }
            }
            catch (EntityException ex)
            {
                // Implementar logging aquí
                throw new Exception("Error al listar los pacientes: " + ex.Message);
            }
        }

        public Boolean InsertarPaciente(PacienteDC objPacienteDC)
        {
            try
            {
                using (var objClinica = new ClinPsicologicaEntities())
                {
                    objClinica.usp_InsertarPaciente(
                        objPacienteDC.nombres, objPacienteDC.apellidos, objPacienteDC.genero,
                        objPacienteDC.telefono, objPacienteDC.correo, objPacienteDC.id_ubigeo,
                        objPacienteDC.estado, objPacienteDC.foto, objPacienteDC.FechaNacimiento, objPacienteDC.Usuario_Registro,
                        objPacienteDC.Usuario_ult_modificacion
                    );

                    objClinica.SaveChanges();
                    return true;
                }
            }
            catch (EntityException ex)
            {
                // Implementar logging aquí
                throw new Exception("Error al insertar el paciente: " + ex.Message);
            }
        }

        public Boolean ActualizarPaciente(PacienteDC objPacienteDC)
        {
            try
            {
                using (var objClinica = new ClinPsicologicaEntities())
                {
                    objClinica.usp_UpdatePaciente(
                        objPacienteDC.id_paciente, objPacienteDC.nombres, objPacienteDC.apellidos,
                        objPacienteDC.genero, objPacienteDC.telefono, objPacienteDC.correo,
                        objPacienteDC.id_ubigeo, Convert.ToInt16(objPacienteDC.estado), objPacienteDC.foto,
                         objPacienteDC.Usuario_ult_modificacion,objPacienteDC.FechaNacimiento
                    );

                    objClinica.SaveChanges();
                    return true;
                }
            }
            catch (EntityException ex)
            {
                throw new Exception("Error al actualizar el paciente: " + ex.Message);
            }
        }

        public Boolean EliminarPaciente(Int16 id_paciente)
        {
            try
            {
                using (var objClinica = new ClinPsicologicaEntities())
                {
                    objClinica.usp_EliminarPaciente(id_paciente);

                    objClinica.SaveChanges();
                    return true;
                }
            }
            catch (EntityException ex)
            {
                // Implementar logging aquí
                throw new Exception("Error al eliminar el paciente: " + ex.Message);
            }
        }


    }
}
