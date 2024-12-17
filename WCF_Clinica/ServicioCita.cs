using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Clinica
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioCita" in both code and config file together.
    public class ServicioCita : IServicioCita   
    {
        public List<CitaDC> ListarCitasPacientePorFecha(int codigo, DateTime FecIni, DateTime FecFin)
        {
            try
            {
                ClinPsicologicaEntities MiServicio = new ClinPsicologicaEntities();

                List<CitaDC> objListaCitas = new List<CitaDC>();

                var query = (from miCita in MiServicio.tb_cita
                             where miCita.id_paciente == codigo
                             && miCita.fecha >= FecIni && miCita.fecha <= FecFin
                             select new CitaDC
                             {
                                 id = miCita.id_cita,
                                 fecha = miCita.fecha,
                                 hora = miCita.hora ?? TimeSpan.Zero,
                                 id_psicologo = miCita.id_psicologo,
                                 id_paciente = miCita.id_paciente,
                                 id_consultorio = miCita.id_consultorio,
                                 estado = miCita.estado ?? 0,
                                 id_historial = miCita.id_historial ?? 0
                             }).ToList();

                return query;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CitaDC> ListarCitasPorFecha(DateTime FecIni, DateTime FecFin, int estade)
        {
            try
            {
                using (ClinPsicologicaEntities MiServicio = new ClinPsicologicaEntities())
                {
                    var query = (from miCita in MiServicio.tb_cita
                                 join psicologo in MiServicio.tb_psicologo on miCita.id_psicologo equals psicologo.id_psicologo
                                 join paciente in MiServicio.tb_paciente on miCita.id_paciente equals paciente.id_paciente
                                 where miCita.fecha >= FecIni && miCita.fecha <= FecFin
                                       && (miCita.estado == estade || miCita.estado == 1)// Filtrar según el estado proporcionado
                                 select new CitaDC
                                 {
                                     id = miCita.id_cita,
                                     fecha = miCita.fecha,
                                     hora = miCita.hora ?? TimeSpan.Zero,
                                     psicologo = psicologo.nombre,
                                     paciente = paciente.nombres + " " + paciente.apellidos,
                                     id_consultorio = miCita.id_consultorio,
                                     precio = miCita.precio,
                                     id_historial = miCita.id_historial ?? 0,
                                     estado = miCita.estado ?? 0
                                 }).ToList();

                    return query;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar citas por fecha: " + ex.Message);
            }
        }
        
        public CitaDC ConsultarCita(int codigo)
        {
            using (ClinPsicologicaEntities MiServicio = new ClinPsicologicaEntities())
            {
                tb_cita objCita = (from miCita in MiServicio.tb_cita
                                   where miCita.id_cita == codigo
                                   select miCita).FirstOrDefault();

                if (objCita == null)
                {
                    return null;
                }

                CitaDC objCitaDC = new CitaDC
                {
                    id = objCita.id_cita,
                    fecha = objCita.fecha,
                    hora = objCita.hora ?? TimeSpan.Zero,
                    id_psicologo = objCita.id_psicologo,
                    id_paciente = objCita.id_paciente,
                    id_consultorio = objCita.id_consultorio,
                    motivo_cita = objCita.motivo_cita,
                    duracion = objCita.duracion,
                    estado = objCita.estado ?? 0,
                    tipo_cita = objCita.tipo_cita,
                    precio = objCita.precio,
                    estado_pago = objCita.estado_pago,
                    confirmacion_asistencia = objCita.confirmacion_asistencia ?? 0,
                    id_historial = objCita.id_historial ?? 0,
                };

                return objCitaDC;
            }
        }

        public Boolean InsertarCita(CitaDC objCitaDC)
        {
            try
            {
                using (ClinPsicologicaEntities MiServicio = new ClinPsicologicaEntities())
                {
                    // Generar un nuevo ID para la cita
                    int nuevoId = MiServicio.tb_cita.Any() ? MiServicio.tb_cita.Max(c => c.id_cita) + 1 : 1;

                    // Crear un nuevo objeto de cita y asignar los valores de CitaDC
                    tb_cita cita = new tb_cita
                    {
                        id_cita = nuevoId,
                        fecha = objCitaDC.fecha,
                        hora = objCitaDC.hora,
                        id_psicologo = objCitaDC.id_psicologo,
                        id_paciente = objCitaDC.id_paciente,
                        id_consultorio = objCitaDC.id_consultorio,
                        estado = objCitaDC.estado,
                        motivo_cita = objCitaDC.motivo_cita,
                        duracion = objCitaDC.duracion,
                        tipo_cita = objCitaDC.tipo_cita,
                        precio = objCitaDC.precio,
                        estado_pago = objCitaDC.estado_pago,
                        confirmacion_asistencia = objCitaDC.confirmacion_asistencia,
                        id_historial = objCitaDC.id_historial
                    };

                    // Agregar la cita a la base de datos
                    MiServicio.tb_cita.Add(cita);
                    MiServicio.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la cita: " + ex.Message);
            }
        }


        public Boolean ActualizarCita(CitaDC objCitaDC)
        {
            try
            {
                using (ClinPsicologicaEntities MiServicio = new ClinPsicologicaEntities())
                {
                    MiServicio.usp_ActualizarCita(
                        objCitaDC.id,
                        objCitaDC.fecha,
                        objCitaDC.hora,
                        objCitaDC.id_psicologo,
                        objCitaDC.id_paciente,
                        objCitaDC.id_consultorio,
                        objCitaDC.estado,
                        objCitaDC.motivo_cita,
                        objCitaDC.duracion,
                        objCitaDC.tipo_cita,
                        objCitaDC.precio,
                        objCitaDC.estado_pago,
                        objCitaDC.confirmacion_asistencia
                    );

                    MiServicio.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la cita: " + ex.Message);
            }
        }


        public Boolean EliminarCita(int codigo)
        {
            try
            {
                ClinPsicologicaEntities MiServicio = new ClinPsicologicaEntities();

                MiServicio.usp_EliminarCita(codigo);

                MiServicio.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ExisteCitaConflicto(int idPsicologo, int idPaciente, DateTime fecha, TimeSpan hora, int duracion)
        {
            using (ClinPsicologicaEntities MiServicio = new ClinPsicologicaEntities())
            {
                List<CitaDC> citasExistentes = ListarCitasPorPsicologoYFecha(idPsicologo, fecha);

                foreach (var cita in citasExistentes)
                {
                    if (cita.fecha.Date == fecha.Date)
                    {
                        TimeSpan inicioCitaExistente = cita.hora;
                        TimeSpan finCitaExistente = cita.hora.Add(TimeSpan.FromMinutes(cita.duracion ?? 0));

                        TimeSpan inicioNuevaCita = hora;
                        TimeSpan finNuevaCita = hora.Add(TimeSpan.FromMinutes(duracion));

                        if ((inicioNuevaCita >= inicioCitaExistente && inicioNuevaCita < finCitaExistente) ||
                            (finNuevaCita > inicioCitaExistente && finNuevaCita <= finCitaExistente) ||
                            (inicioNuevaCita <= inicioCitaExistente && finNuevaCita >= finCitaExistente))
                        {
                            return true; // Hay un conflicto
                        }
                    }
                }

                citasExistentes = ListarCitasPorPacienteYFecha(idPaciente, fecha);

                foreach (var cita in citasExistentes)
                {
                    if (cita.fecha.Date == fecha.Date)
                    {
                        TimeSpan inicioCitaExistente = cita.hora;
                        TimeSpan finCitaExistente = cita.hora.Add(TimeSpan.FromMinutes(cita.duracion ?? 0));

                        TimeSpan inicioNuevaCita = hora;
                        TimeSpan finNuevaCita = hora.Add(TimeSpan.FromMinutes(duracion));

                        if ((inicioNuevaCita >= inicioCitaExistente && inicioNuevaCita < finCitaExistente) ||
                            (finNuevaCita > inicioCitaExistente && finNuevaCita <= finCitaExistente) ||
                            (inicioNuevaCita <= inicioCitaExistente && finNuevaCita >= finCitaExistente))
                        {
                            return true; // Hay un conflicto
                        }
                    }
                }

                return false; // No hay conflicto
            }
        }

        private List<CitaDC> ListarCitasPorPsicologoYFecha(int idPsicologo, DateTime fecha)
        {
            using (ClinPsicologicaEntities MiServicio = new ClinPsicologicaEntities())
            {
                var query = (from miCita in MiServicio.tb_cita
                             where miCita.id_psicologo == idPsicologo && miCita.fecha == fecha
                             select new CitaDC
                             {
                                 id = miCita.id_cita,
                                 fecha = miCita.fecha,
                                 hora = miCita.hora ?? TimeSpan.Zero,
                                 id_psicologo = miCita.id_psicologo,
                                 id_paciente = miCita.id_paciente,
                                 id_consultorio = miCita.id_consultorio,
                                 estado = miCita.estado ?? 0,
                                 motivo_cita = miCita.motivo_cita,
                                 duracion = miCita.duracion,
                                 tipo_cita = miCita.tipo_cita,
                                 precio = miCita.precio,
                                 estado_pago = miCita.estado_pago,
                                 confirmacion_asistencia = miCita.confirmacion_asistencia ?? 0,
                                 id_historial = miCita.id_historial ?? 0
                             }).ToList();

                return query;
            }
        }

        private List<CitaDC> ListarCitasPorPacienteYFecha(int idPaciente, DateTime fecha)
        {
            using (ClinPsicologicaEntities MiServicio = new ClinPsicologicaEntities())
            {
                var query = (from miCita in MiServicio.tb_cita
                             where miCita.id_paciente == idPaciente && miCita.fecha == fecha
                             select new CitaDC
                             {
                                 id = miCita.id_cita,
                                 fecha = miCita.fecha,
                                 hora = miCita.hora ?? TimeSpan.Zero,
                                 id_psicologo = miCita.id_psicologo,
                                 id_paciente = miCita.id_paciente,
                                 id_consultorio = miCita.id_consultorio,
                                 estado = miCita.estado ?? 0,
                                 motivo_cita = miCita.motivo_cita,
                                 duracion = miCita.duracion,
                                 tipo_cita = miCita.tipo_cita,
                                 precio = miCita.precio,
                                 estado_pago = miCita.estado_pago,
                                 confirmacion_asistencia = miCita.confirmacion_asistencia ?? 0,
                                 id_historial = miCita.id_historial ?? 0
                             }).ToList();

                return query;
            }
        }

    }
}
