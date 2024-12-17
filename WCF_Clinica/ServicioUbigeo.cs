using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Clinica
{
    public class ServicioUbigeo : IServicioUbigeo
    {
        public List<UbigeoDC> ListarDepartamentos()
        {
            try
            {
                using (var context = new ClinPsicologicaEntities()) // Cambia aquí por tu contexto real
                {
                    var query = (from u in context.tb_Ubigeo // Asegúrate de que este sea el nombre correcto de tu DbSet
                                 group u by new { u.idDepa, u.Departamento } into g // Agrupar por idDepa y Departamento
                                 select new UbigeoDC
                                 {
                                     idDepa = g.Key.idDepa,
                                     Departamento = g.Key.Departamento
                                 }).ToList();

                    return query;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar departamentos: " + ex.Message);
            }
        }

        public List<UbigeoDC> ListarProvinciasPorDepartamento(string idDepartamento)
        {
            try
            {
                using (var context = new ClinPsicologicaEntities()) // Cambia aquí por tu contexto real
                {
                    var query = (from u in context.tb_Ubigeo // Asegúrate de que este sea el nombre correcto de tu DbSet
                                 where u.idDepa == idDepartamento && u.idProv != null // Provincias deben tener idProv
                                 group u by new { u.idProv, u.Provincia } into g // Agrupar por idProv y Provincia
                                 select new UbigeoDC
                                 {
                                     idProv = g.Key.idProv,
                                     Provincia = g.Key.Provincia
                                 }).ToList();

                    return query;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar provincias: " + ex.Message);
            }
        }

        public List<UbigeoDC> ListarDistritosPorDepartamentoYProvincia(string idDepartamento, string idProvincia)
        {
            try
            {
                using (var context = new ClinPsicologicaEntities()) // Cambia aquí por tu contexto real
                {
                    var query = (from u in context.tb_Ubigeo // Asegúrate de que este sea el nombre correcto de tu DbSet
                                 where u.idDepa == idDepartamento && u.idProv == idProvincia && u.idDist != null // Filtrar por Departamento y Provincia
                                 select new UbigeoDC
                                 {
                                     idDist = u.idDist,
                                     Distrito = u.Distrito,
                                     id_ubigeo = u.id_ubigeo // Concatenar o formatear el ID de Ubigeo
                                 }).ToList();

                    return query;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar distritos: " + ex.Message);
            }
        }

        public UbigeoDC ConsultarUbigeo(string idUbigeo)
        {
            try
            {
                using (var context = new ClinPsicologicaEntities()) // Cambia aquí por tu contexto real
                {
                    // Busca el ubigeo en la base de datos usando el idUbigeo
                    var ubigeo = context.tb_Ubigeo.FirstOrDefault(u => u.id_ubigeo == idUbigeo);

                    if (ubigeo == null)
                    {
                        throw new FaultException("Ubigeo no encontrado.");
                    }

                    // Mapea el resultado a UbigeoDC
                    return new UbigeoDC
                    {
                        id_ubigeo = ubigeo.id_ubigeo,
                        idDepa = ubigeo.idDepa,
                        idProv = ubigeo.idProv,
                        idDist = ubigeo.idDist,
                        Departamento = ubigeo.Departamento,
                        Provincia = ubigeo.Provincia,
                        Distrito = ubigeo.Distrito
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar ubigeo: " + ex.Message);
            }
        }
    }
}