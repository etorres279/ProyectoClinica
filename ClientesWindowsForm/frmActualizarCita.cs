using CitaService;
using ClientesWindowsForm;
using PacienteService;
using PsicologoService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CitaWindowsForm
{
    public partial class frmActualizarCita : Form
    {
        CitaService.ServicioCitaClient objCitaServicio = new CitaService.ServicioCitaClient();
        PacienteService.ServicioPacienteClient objPacienteServicio = new PacienteService.ServicioPacienteClient();
        PsicologoService.ServicioPsicologoClient objPsicologoServicio = new PsicologoService.ServicioPsicologoClient();
        CitaDC citaDC;

        // Variable para almacenar el id de la cita
        private int citaId;

        public frmActualizarCita(int idCita)
        {
            InitializeComponent();
            this.citaId = idCita; // Asignar el ID de la cita al atributo citaId
            citaDC = objCitaServicio.ConsultarCita(citaId); // Obtener la cita
        }

        private void TextBox_Letra_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras y la tecla de retroceso
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Suprimir la entrada no válida
            }

            // Verificar si se está intentando insertar un espacio
            if (e.KeyChar == ' ')
            {
                // Comprobar si el texto actual está vacío o si el último carácter es un espacio
                if (string.IsNullOrWhiteSpace(((TextBox)sender).Text) || ((TextBox)sender).Text.EndsWith(" "))
                {
                    e.Handled = true; // Suprimir la entrada si es el primer carácter o si ya hay un espacio al final
                }
            }
        }

        private void TextBox_Numeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Suprimir la entrada no válida
            }
        }

        private void frmActualizarCita_Load(object sender, EventArgs e)
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

                if (!string.IsNullOrEmpty(citaDC.tipo_cita))
                {
                    cboTipo.SelectedItem = citaDC.tipo_cita;
                }
                else
                {
                    cboTipo.SelectedIndex = 0;  // "--Seleccione--"
                }

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

                ActualizarDuracion();  // Llamada para cargar las duraciones correspondientes al tipo de cita

                // Asignar la duración registrada
                if (citaDC.duracion > 0 && cboDuracion.Items.Contains(citaDC.duracion))
                {
                    cboDuracion.SelectedItem = citaDC.duracion;  // Selecciona la duración registrada
                }
                else
                {
                    cboDuracion.SelectedIndex = 0;  // "--Seleccione--"
                }

                cboTipo.SelectedIndexChanged += cboTipo_SelectedIndexChanged;

                // Llenar ComboBox de Estado de Pago
                cboEstPago.Items.Clear();
                cboEstPago.Items.Add("Pagado");
                cboEstPago.Items.Add("Pendiente");
                cboEstPago.SelectedItem = citaDC.estado_pago == "1" ? "Pagado" : "Pendiente";

                // Llenar ComboBox de Confirmación de Asistencia
                cboConfiAsis.Items.Clear();
                cboConfiAsis.Items.Add("Confirmada");
                cboConfiAsis.Items.Add("No Confirmada");
                cboConfiAsis.SelectedItem = citaDC.confirmacion_asistencia == 1 ? "Confirmada" : "No Confirmada";

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

                    txtMotivo.Text = citaDC.motivo_cita; // Mostrar el tipo de cita como motivo
                    txtPrecio.Text = citaDC.precio.ToString(); // Mostrar el precio
                    if (clsCredenciales.Nivel == 1)
                    {
                        chkActivo.Visible = true; // Mostrar el CheckBox
                        chkActivo.Checked = citaDC.estado != 0; // Corregido: Verificar que estado no sea igual a 0
                    }
                    else
                    {
                        chkActivo.Visible = false; // Ocultar el CheckBox
                        citaDC.estado = 1; // Asegurar que el estado sea 1
                    }
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

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Llamar a ActualizarDuracion cada vez que se cambia el tipo de cita
            ActualizarDuracion();
        }

        private void ActualizarDuracion()
        {
            cboDuracion.Items.Clear();
            cboDuracion.Items.Add("--Seleccione--");

            switch (cboTipo.SelectedItem.ToString())
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
            cboDuracion.SelectedIndex = 0;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Actualizar los valores de citaDC con los valores de los controles
                citaDC.fecha = dtpFecha.Value;
                citaDC.hora = dtpHora.Value.TimeOfDay;
                citaDC.id_paciente = Convert.ToInt32(cboPaciente.SelectedValue);
                citaDC.id_psicologo = Convert.ToInt32(cboPsicologo.SelectedValue);
                citaDC.id_consultorio = Convert.ToInt32(txtConsultorio.Text);
                citaDC.id_historial = Convert.ToInt32(txtHistorial.Text);
                citaDC.precio = Convert.ToDecimal(txtPrecio.Text);

                // Actualizar los nuevos campos
                citaDC.tipo_cita = cboTipo.SelectedItem.ToString();
                citaDC.duracion = Convert.ToInt32(cboDuracion.SelectedItem.ToString().Split(' ')[0]); // Extraer el número de minutos
                citaDC.estado_pago = cboEstPago.SelectedItem.ToString() == "Pagado" ? "1" : "0"; // Correcta asignación de estado_pago
                citaDC.confirmacion_asistencia = cboConfiAsis.SelectedItem.ToString() == "Confirmada" ? 1 : 0; // Asignación de confirmacion_asistencia como int
                citaDC.motivo_cita = txtMotivo.Text;
                if (clsCredenciales.Nivel == 1)
                {
                    citaDC.estado = chkActivo.Checked ? 1 : 0; // Tomar el valor del CheckBox
                }
                else
                {
                    citaDC.estado = 1; // Estado fijo en 1 para niveles distintos de 1
                }

                // Llamada al servicio para actualizar la cita
                objCitaServicio.ActualizarCita(citaDC);

                // Mensaje de éxito
                MessageBox.Show("Cita actualizada con éxito!");
                this.Close();
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error
                MessageBox.Show("Error al actualizar la cita: " + ex.Message);
            }
        }
    }
}
