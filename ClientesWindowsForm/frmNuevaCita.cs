using CitaService;
using PacienteService;
using PsicologoService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitaWindowsForm
{
    public partial class frmNuevaCita : Form
    {
        CitaService.ServicioCitaClient objCitaServicio = new CitaService.ServicioCitaClient();
        PacienteService.ServicioPacienteClient objPacienteServicio = new PacienteService.ServicioPacienteClient();
        PsicologoService.ServicioPsicologoClient objPsicologoServicio = new PsicologoService.ServicioPsicologoClient();

        public frmNuevaCita()
        {
            InitializeComponent();
        }
        private void frmNuevaCita_Load(object sender, EventArgs e)
        {
            try
            {

                // Llenamos el ComboBox de Psicólogos
                List<PsicologoService.PsicologoDC> psicologos = objPsicologoServicio.ListarPsicologo(1).ToList();
                DataTable dtPsicologo = new DataTable();
                dtPsicologo.Columns.Add("id_psicologo", typeof(int));
                dtPsicologo.Columns.Add("nombre", typeof(string));

                DataRow drPsicologo = dtPsicologo.NewRow();
                drPsicologo["id_psicologo"] = 0;
                drPsicologo["nombre"] = "--Seleccione--";
                dtPsicologo.Rows.Add(drPsicologo);

                foreach (var psicologo in psicologos)
                {
                    DataRow row = dtPsicologo.NewRow();
                    row["id_psicologo"] = psicologo.Id_psicologo;
                    row["nombre"] = psicologo.Nombre;
                    dtPsicologo.Rows.Add(row);
                }

                cboPsicologo.DataSource = dtPsicologo;
                cboPsicologo.ValueMember = "id_psicologo";
                cboPsicologo.DisplayMember = "nombre";
                cboPsicologo.SelectedIndex = 0; // Seleccionamos "--Seleccione--" como predeterminado

                // Llenamos el ComboBox de Pacientes
                List<PacienteService.PacienteDC> pacientes = objPacienteServicio.ListarPaciente(1).ToList();
                DataTable dtPaciente = new DataTable();
                dtPaciente.Columns.Add("id_paciente", typeof(int));
                dtPaciente.Columns.Add("nombre", typeof(string));

                DataRow drPaciente = dtPaciente.NewRow();
                drPaciente["id_paciente"] = 0;
                drPaciente["nombre"] = "--Seleccione--";
                dtPaciente.Rows.Add(drPaciente);

                foreach (var paciente in pacientes)
                {
                    DataRow row = dtPaciente.NewRow();
                    row["id_paciente"] = paciente.id_paciente;
                    row["nombre"] = paciente.nombres + " " + paciente.apellidos;
                    dtPaciente.Rows.Add(row);
                }

                cboPaciente.DataSource = dtPaciente;
                cboPaciente.ValueMember = "id_paciente";
                cboPaciente.DisplayMember = "nombre";
                cboPaciente.SelectedIndex = 0; // Seleccionamos "--Seleccione--" como predeterminado

                // Desactivamos temporalmente el evento SelectedIndexChanged de cboMotivo
                cboTipo.SelectedIndexChanged -= cboMotivo_SelectedIndexChanged;

                // Llenamos el ComboBox de Tipo de la cita
                cboTipo.Items.Clear(); // Limpiamos cualquier elemento previo
                cboTipo.Items.Add("--Seleccione--");
                cboTipo.Items.Add("Consulta inicial");
                cboTipo.Items.Add("Terapia individual");
                cboTipo.Items.Add("Terapia de pareja");
                cboTipo.Items.Add("Terapia familiar");
                cboTipo.Items.Add("Evaluación psicológica");
                cboTipo.Items.Add("Seguimiento");
                cboTipo.Items.Add("Psicoeducación");
                cboTipo.Items.Add("Terapia grupal");

                // Seleccionamos el primer elemento por defecto
                cboTipo.SelectedIndex = 0;

                // Configuramos cboDuracion para que muestre "--Seleccione--" al inicio
                cboDuracion.Items.Clear();
                cboDuracion.Items.Add("--Seleccione--");
                cboDuracion.SelectedIndex = 0;

                // Reactivamos el evento SelectedIndexChanged de cboMotivo
                cboTipo.SelectedIndexChanged += cboMotivo_SelectedIndexChanged;

                // Llenamos el ComboBox de Estado de Pago (cboEstPago)
                cboEstPago.Items.Clear();
                cboEstPago.Items.Add("--Seleccione--");
                cboEstPago.Items.Add("Pagado");
                cboEstPago.Items.Add("Pendiente");

                // Seleccionamos "--Seleccione--" como predeterminado para cboEstPago
                cboEstPago.SelectedIndex = 0;

                // Llenamos el ComboBox de Confirmación de Asistencia (cboConfiAsis) con valores 1 y 0
                DataTable dtConfiAsis = new DataTable();
                dtConfiAsis.Columns.Add("Value", typeof(int));
                dtConfiAsis.Columns.Add("Text", typeof(string));

                DataRow drConfiAsisDefault = dtConfiAsis.NewRow();
                drConfiAsisDefault["Value"] = -1; // Valor por defecto
                drConfiAsisDefault["Text"] = "--Seleccione--";
                dtConfiAsis.Rows.Add(drConfiAsisDefault);

                DataRow drConfiAsisConfirmado = dtConfiAsis.NewRow();
                drConfiAsisConfirmado["Value"] = 1;
                drConfiAsisConfirmado["Text"] = "Confirmado";
                dtConfiAsis.Rows.Add(drConfiAsisConfirmado);

                DataRow drConfiAsisSinConfirmar = dtConfiAsis.NewRow();
                drConfiAsisSinConfirmar["Value"] = 0;
                drConfiAsisSinConfirmar["Text"] = "Sin Confirmar";
                dtConfiAsis.Rows.Add(drConfiAsisSinConfirmar);

                cboConfiAsis.DataSource = dtConfiAsis;
                cboConfiAsis.ValueMember = "Value";
                cboConfiAsis.DisplayMember = "Text";
                cboConfiAsis.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void cboMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Limpiamos las opciones de cboDuracion y añadimos "--Seleccione--"
            cboDuracion.Items.Clear();
            cboDuracion.Items.Add("--Seleccione--");

            // Añadimos opciones según el motivo seleccionado
            if (cboTipo.SelectedIndex > 0) // Verificamos que no sea el primer elemento
            {
                switch (cboTipo.SelectedItem.ToString())
                {
                    case "Consulta inicial":
                        cboDuracion.Items.Add(60); // Duración en minutos
                        cboDuracion.Items.Add(90);
                        break;
                    case "Terapia individual":
                        cboDuracion.Items.Add(45); // Duración en minutos
                        cboDuracion.Items.Add(60);
                        break;
                    case "Terapia de pareja":
                        cboDuracion.Items.Add(60); // Duración en minutos
                        cboDuracion.Items.Add(90);
                        break;
                    case "Terapia familiar":
                        cboDuracion.Items.Add(60); // Duración en minutos
                        cboDuracion.Items.Add(120);
                        break;
                    case "Evaluación psicológica":
                        cboDuracion.Items.Add(90); // Duración en minutos
                        cboDuracion.Items.Add(120);
                        break;
                    case "Seguimiento":
                        cboDuracion.Items.Add(30); // Duración en minutos
                        cboDuracion.Items.Add(45);
                        break;
                    case "Psicoeducación":
                        cboDuracion.Items.Add(30); // Duración en minutos
                        cboDuracion.Items.Add(60);
                        break;
                    case "Terapia grupal":
                        cboDuracion.Items.Add(60); // Duración en minutos
                        cboDuracion.Items.Add(90);
                        break;
                }
            }

            // Establecemos "--Seleccione--" como opción predeterminada en cboDuracion
            cboDuracion.SelectedIndex = 0;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar selección de Psicólogo
                int idPsicologo = cboPsicologo.SelectedValue != null ? Convert.ToInt16(cboPsicologo.SelectedValue) : 0;
                if (idPsicologo == 0)
                {
                    MessageBox.Show("Seleccione un psicólogo.");
                    return;
                }

                // Verificar selección de Paciente
                int idPaciente = cboPaciente.SelectedValue != null ? Convert.ToInt16(cboPaciente.SelectedValue) : 0;
                if (idPaciente == 0)
                {
                    MessageBox.Show("Seleccione un paciente.");
                    return;
                }

                // Verificar el valor de Consultorio y Historial
                int consultorio, historial;
                if (!int.TryParse(txtConsultorio.Text, out consultorio))
                {
                    MessageBox.Show("El campo de consultorio debe contener un valor numérico.");
                    return;
                }
                if (!int.TryParse(txtHistorial.Text, out historial))
                {
                    MessageBox.Show("El campo de historial debe contener un valor numérico.");
                    return;
                }

                // Verificar selección de Tipo de Cita
                if (cboTipo.SelectedIndex == 0)
                {
                    MessageBox.Show("Seleccione un tipo de cita.");
                    return;
                }

                // Verificar la Duración
                int duracion = cboDuracion.SelectedItem != null ? Convert.ToInt32(cboDuracion.SelectedItem) : 0;
                if (duracion == 0)
                {
                    MessageBox.Show("Seleccione una duración para la cita.");
                    return;
                }

                // Verificar el Precio
                decimal precio;
                if (!decimal.TryParse(txtPrecio.Text, out precio))
                {
                    MessageBox.Show("El campo de precio debe contener un valor numérico.");
                    return;
                }

                // Verificar selección de Estado de Pago
                if (cboEstPago.SelectedIndex == 0)
                {
                    MessageBox.Show("Seleccione un estado de pago.");
                    return;
                }

                // Verificar selección de Confirmación de Asistencia
                int confirmacionAsistencia = cboConfiAsis.SelectedValue != null ? Convert.ToInt32(cboConfiAsis.SelectedValue) : -1;
                if (confirmacionAsistencia == -1)
                {
                    MessageBox.Show("Seleccione una opción de confirmación de asistencia.");
                    return;
                }

                DateTime fecha = dtpFecha.Value.Date;
                TimeSpan hora = dtpHora.Value.TimeOfDay;

                bool conflicto = objCitaServicio.ExisteCitaConflicto(idPsicologo, idPaciente, fecha, hora, duracion);

                if (conflicto)
                {
                    MessageBox.Show("Ya existe una cita en la misma fecha y hora para el psicólogo o paciente seleccionado.");
                    return;
                }

                // Crear instancia de CitaDC y asignar los valores
                CitaDC citaDC = new CitaDC
                {
                    id = 0,
                    fecha = dtpFecha.Value,
                    hora = new TimeSpan(dtpHora.Value.Hour, dtpHora.Value.Minute, 0),
                    id_paciente = idPaciente,
                    id_psicologo = idPsicologo,
                    id_consultorio = consultorio,
                    id_historial = historial,
                    estado = 1,
                    motivo_cita = txtMotivo.Text, // Suponiendo que tienes un TextBox para el motivo
                    duracion = duracion,
                    tipo_cita = cboTipo.SelectedItem.ToString(),
                    precio = precio,
                    estado_pago = cboEstPago.SelectedItem.ToString() == "Pagado" ? "1" : "0",
                    confirmacion_asistencia = confirmacionAsistencia
                };

                // Insertar la cita a través del servicio
                bool resultado = objCitaServicio.InsertarCita(citaDC);
                if (resultado)
                {
                    MessageBox.Show("Cita creada con éxito!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al crear la cita. Inténtelo de nuevo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la cita: " + ex.Message);
            }
        }

    }
}
