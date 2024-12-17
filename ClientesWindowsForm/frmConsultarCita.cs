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
    public partial class frmConsultarCita : Form
    {
        CitaService.ServicioCitaClient objCitaServicio = new CitaService.ServicioCitaClient();
        PacienteService.ServicioPacienteClient objPacienteServicio = new PacienteService.ServicioPacienteClient();
        PsicologoService.ServicioPsicologoClient objPsicologoServicio = new PsicologoService.ServicioPsicologoClient();
        CitaDC citaDC;

        private int citaId;

        public frmConsultarCita(int idCita)
        {
            InitializeComponent();
            this.citaId = idCita;
            citaDC = objCitaServicio.ConsultarCita(idCita);

        }

        private void frmConsultarCita_Load(object sender, EventArgs e)
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
                cboPsicologo.Enabled = false;

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
                cboPaciente.Enabled = false;

                // Llenar ComboBox de Tipo de Cita
                cboTipo.Items.Clear();
                cboTipo.Items.Add("--Seleccione--");
                cboTipo.Items.Add("Consulta inicial");
                cboTipo.Items.Add("Terapia individual");
                cboTipo.Items.Add("Terapia de pareja");
                cboTipo.Items.Add("Terapia familiar");
                cboTipo.Items.Add("Evaluación psicológica");
                cboTipo.Items.Add("Seguimiento");
                cboTipo.Items.Add("Psicoeducación");
                cboTipo.Items.Add("Terapia grupal");

                cboTipo.SelectedItem = citaDC.tipo_cita;
                cboTipo.Enabled = false;

                // Llenar ComboBox de Duración según el tipo de cita
                cboDuracion.Items.Clear();
                cboDuracion.Items.Add("--Seleccione--");
                switch (citaDC.tipo_cita)
                {
                    case "Consulta inicial":
                        cboDuracion.Items.Add(60);
                        cboDuracion.Items.Add(90);
                        break;
                    case "Terapia individual":
                        cboDuracion.Items.Add(45);
                        cboDuracion.Items.Add(60);
                        break;
                    case "Terapia de pareja":
                        cboDuracion.Items.Add(60);
                        cboDuracion.Items.Add(90);
                        break;
                    case "Terapia familiar":
                        cboDuracion.Items.Add(60);
                        cboDuracion.Items.Add(120);
                        break;
                    case "Evaluación psicológica":
                        cboDuracion.Items.Add(90);
                        cboDuracion.Items.Add(120);
                        break;
                    case "Seguimiento":
                        cboDuracion.Items.Add(30);
                        cboDuracion.Items.Add(45);
                        break;
                    case "Psicoeducación":
                        cboDuracion.Items.Add(30);
                        cboDuracion.Items.Add(60);
                        break;
                    case "Terapia grupal":
                        cboDuracion.Items.Add(60);
                        cboDuracion.Items.Add(90);
                        break;
                }

                cboDuracion.SelectedItem = citaDC.duracion;
                cboDuracion.Enabled = false;

                // Llenar ComboBox de Estado de Pago
                cboEstPago.Items.Clear();
                cboEstPago.Items.Add("Pagado");
                cboEstPago.Items.Add("Pendiente");
                cboEstPago.SelectedItem = citaDC.estado_pago == "1" ? "Pagado" : "Pendiente";
                cboEstPago.Enabled = false;

                // Llenar ComboBox de Confirmación de Asistencia
                cboConfiAsis.Items.Clear();
                cboConfiAsis.Items.Add("Confirmada");
                cboConfiAsis.Items.Add("No Confirmada");
                cboConfiAsis.SelectedItem = citaDC.confirmacion_asistencia == 1 ? "Confirmada" : "No Confirmada";
                cboConfiAsis.Enabled = false;

                // Cargar el resto de los datos de la cita
                if (citaDC != null)
                {
                    txtId.Text = citaDC.id.ToString();
                    dtpFecha.Value = citaDC.fecha;
                    dtpHora.Value = DateTime.Today.Add(citaDC.hora);

                    cboPsicologo.SelectedValue = citaDC.id_psicologo;
                    cboPaciente.SelectedValue = citaDC.id_paciente;

                    txtConsultorio.Text = citaDC.id_consultorio.ToString();
                    txtHistorial.Text = citaDC.id_historial.ToString();

                    txtMotivo.Text = citaDC.motivo_cita;
                    txtPrecio.Text = citaDC.precio.ToString();

                    // Desactivar controles de entrada de texto
                    txtId.ReadOnly = true;
                    dtpFecha.Enabled = false;
                    dtpHora.Enabled = false;
                    txtConsultorio.ReadOnly = true;
                    txtHistorial.ReadOnly = true;
                    txtMotivo.ReadOnly = true;
                    txtPrecio.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("No se encontró la cita.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la cita: " + ex.Message);
            }
        }
    }
}
