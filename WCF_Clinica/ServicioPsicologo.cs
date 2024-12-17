using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Entity.Core;
using System.Collections;
using WCF_Clinica;

namespace WCF_Clinica
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioPsicologo" en el código y en el archivo de configuración a la vez.
    public class ServicioPsicologo : IServicioPsicologo
    {
        public PsicologoDC ConsultarPsicologo(Int16 strCodigo)
        {
            using (ClinPsicologicaEntities MisPsicos = new ClinPsicologicaEntities())
            {
                var objPsicologo = MisPsicos.usp_ConsultarPsicologo(Convert.ToInt16(strCodigo)).FirstOrDefault();

                if (objPsicologo != null)
                {
                    PsicologoDC psicologoDC = new PsicologoDC
                    {
                        Id_psicologo = Convert.ToInt16(objPsicologo.id_psicologo),
                        Nombre = objPsicologo.nombre,
                        Especialidad = objPsicologo.especialidad,
                        Telefono = objPsicologo.telefono,
                        Correo = objPsicologo.correo,
                        Id_ubigeo = objPsicologo.id_ubigeo.ToString(),
                        Departamento = objPsicologo.Departamento,
                        Provincia = objPsicologo.Provincia,
                        Distrito = objPsicologo.Distrito,
                        EstadoPsico = objPsicologo.estadoPsico,
                        Fecha_registro = Convert.ToDateTime(objPsicologo.Fecha_registro),
                        Fecha_ult_modificacion = Convert.ToDateTime(objPsicologo.Fecha_ult_modificacion)


                    };

                    return psicologoDC;
                }
                else
                {
                    return null;
                }
            }
        }
        public List<PsicologoDC> ListarPsicologo(Int16 Estade)
        {
            try
            {
                using (var objClinica = new ClinPsicologicaEntities())
                {
                    // Realizar la consulta usando LINQ
                    var query = from psicologo in objClinica.tb_psicologo
                                join ubigeo in objClinica.tb_Ubigeo on psicologo.id_ubigeo equals ubigeo.id_ubigeo
                                where psicologo.estado == Estade || psicologo.estado == 1 // Filtrar por estado
                                select new
                                {
                                    psicologo.id_psicologo,
                                    psicologo.nombre,
                                    psicologo.especialidad,
                                    psicologo.telefono,
                                    psicologo.correo,
                                    psicologo.id_ubigeo,
                                    ubigeo.Departamento,
                                    ubigeo.Provincia,
                                    ubigeo.Distrito,
                                    psicologo.estado
                                };

                    // Convertir a lista y luego proyectar a PsicologoDC
                    return query.AsEnumerable().Select(psicologo => new PsicologoDC
                    {
                        Id_psicologo = Convert.ToInt16(psicologo.id_psicologo),
                        Nombre = psicologo.nombre,
                        Especialidad = psicologo.especialidad,
                        Telefono = psicologo.telefono,
                        Correo = psicologo.correo,
                        Id_ubigeo = psicologo.id_ubigeo,
                        Departamento = psicologo.Departamento,
                        Provincia = psicologo.Provincia,
                        Distrito = psicologo.Distrito,
                        Estado = Convert.ToInt16(psicologo.estado)
                    }).ToList(); // Convertir a lista y devolver
                }
            }
            catch (EntityException ex)
            {
                // Implementar logging aquí
                throw new Exception("Error al listar los psicólogos: " + ex.Message);
            }
        }
        public Boolean InsertarPsicologo(PsicologoDC objPsicologoDC)
        {
            try
            {
                ClinPsicologicaEntities MisPsicos = new ClinPsicologicaEntities();

                MisPsicos.usp_InsertarPsicologo
                    (
                     objPsicologoDC.Nombre, objPsicologoDC.Especialidad, objPsicologoDC.Telefono,
                     objPsicologoDC.Correo, objPsicologoDC.Id_ubigeo, Convert.ToInt16(objPsicologoDC.Estado)
                     , objPsicologoDC.Foto, objPsicologoDC.Usuario_registro, objPsicologoDC.Usuario_ult_modificacion
                    );
                MisPsicos.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
                return false;
            }

        }
        public Boolean ActualizarPsicologo(PsicologoDC objPsicologoDC)
        {
            try
            {
                ClinPsicologicaEntities MisPsicos = new ClinPsicologicaEntities();

                MisPsicos.usp_UpdatePsicologo
                    (
                     Convert.ToInt16(objPsicologoDC.Id_psicologo),
                     objPsicologoDC.Nombre, objPsicologoDC.Especialidad, objPsicologoDC.Telefono, objPsicologoDC.Correo,
                     objPsicologoDC.Id_ubigeo, Convert.ToInt16(objPsicologoDC.Estado), objPsicologoDC.Foto, objPsicologoDC.Usuario_ult_modificacion

                    );
                MisPsicos.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
                return false;
            }
        }
        public Boolean EliminarPsicologo(Int16 strCodigo)
        {
            try
            {
                ClinPsicologicaEntities MisPsicos = new ClinPsicologicaEntities();

                MisPsicos.usp_DeletePsicologo(strCodigo);

                MisPsicos.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
                return true;
            }
        }
    }
}
