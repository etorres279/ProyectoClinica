using CitaWindowsForm;
using PacienteService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientesWindowsForm
{
    public partial class frmPaciente : Form
    {
        PacienteService.ServicioPacienteClient objServPaciente = new PacienteService.ServicioPacienteClient();

        public frmPaciente()
        {
            InitializeComponent();
            this.Load += new EventHandler(this.frmPaciente_Load);
        }

        private void frmPaciente_Load(object sender, EventArgs e)
        {
            try
            {
                dtgPaciente.AutoGenerateColumns = false;
                ConfigurarColumnas();
                CargarDatos();

                txtFiltroNombre.TextChanged += (s, args) => CargarDatos();
                txtFiltroApellido.TextChanged += (s, args) => CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en frmPaciente_Load: " + ex.Message);
            }
        }

        public void CargarDatos()
        {
            try
            {
                dtgPaciente.DataSource = null; // Limpiar el DataSource antes de cargar nuevos datos

                // Determinar el estado según el nivel de usuario
                short estado = clsCredenciales.Nivel == 1 ? (short)0 : (short)1;

                // Llamar al servicio pasando el estado
                List<PacienteDC> misPacientes = objServPaciente.ListarPaciente(estado);

                // Filtrar por nombre si hay texto en el filtro
                if (!string.IsNullOrWhiteSpace(txtFiltroNombre.Text))
                {
                    string filtroNombre = txtFiltroNombre.Text.ToLower();
                    misPacientes = misPacientes.Where(p => p.nombres.ToLower().Contains(filtroNombre)).ToList();
                }

                // Filtrar por apellidos si hay texto en el filtro
                if (!string.IsNullOrWhiteSpace(txtFiltroApellido.Text))
                {
                    string filtroApellido = txtFiltroApellido.Text.ToLower();
                    misPacientes = misPacientes.Where(p => p.apellidos.ToLower().Contains(filtroApellido)).ToList();
                }

                // Asignar la lista filtrada al DataSource
                if (misPacientes != null && misPacientes.Any())
                {
                    dtgPaciente.DataSource = misPacientes;
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void ConfigurarColumnas()
        {
            dtgPaciente.Columns.Clear();
            dtgPaciente.Columns.Add(new DataGridViewTextBoxColumn { Name = "id_paciente", DataPropertyName = "id_paciente", HeaderText = "ID Paciente", Visible = false });
            dtgPaciente.Columns.Add(new DataGridViewTextBoxColumn { Name = "nombres", DataPropertyName = "nombres", HeaderText = "Nombres" });
            dtgPaciente.Columns.Add(new DataGridViewTextBoxColumn { Name = "apellidos", DataPropertyName = "apellidos", HeaderText = "Apellidos" });
            dtgPaciente.Columns.Add(new DataGridViewTextBoxColumn { Name = "genero", DataPropertyName = "genero", HeaderText = "Género" });
            dtgPaciente.Columns.Add(new DataGridViewTextBoxColumn { Name = "correo", DataPropertyName = "correo", HeaderText = "Correo" });
            dtgPaciente.Columns.Add(new DataGridViewTextBoxColumn { Name = "telefono", DataPropertyName = "telefono", HeaderText = "Teléfono" });
            dtgPaciente.Columns.Add(new DataGridViewTextBoxColumn { Name = "Edad", DataPropertyName = "Edad", HeaderText = "Edad" });
            dtgPaciente.Columns.Add(new DataGridViewTextBoxColumn { Name = "estado", DataPropertyName = "estado", HeaderText = "Estado" });
        }

        private void dtgCita_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificar si la columna es la de estado
            if (dtgPaciente.Columns[e.ColumnIndex].Name == "estado" && e.Value != null)
            {
                // Intentar convertir el valor a entero
                if (int.TryParse(e.Value.ToString(), out int estado))
                {
                    // Asignar el texto correspondiente
                    e.Value = estado == 1 ? "Activo" : "Inactivo";
                    e.FormattingApplied = true; // Indicar que se ha aplicado el formato
                }
                else
                {
                    // Si no se puede convertir, puedes manejar el error o dejar el valor original
                    e.Value = "Desconocido"; // O cualquier otro valor que desees mostrar
                    e.FormattingApplied = true; // Indicar que se ha aplicado el formato
                }
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmNuevoPaciente frmNuevoPsico = new frmNuevoPaciente();
            frmNuevoPsico.ShowDialog();
            CargarDatos();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dtgPaciente.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dtgPaciente.SelectedRows[0];
                var idPaciente = filaSeleccionada.Cells["id_paciente"].Value;

                frmConsultarPaciente frmConsultarPsico = new frmConsultarPaciente(Convert.ToInt16(idPaciente));
                frmConsultarPsico.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un paciente.");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dtgPaciente.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dtgPaciente.SelectedRows[0];
                var idPaciente = filaSeleccionada.Cells["id_paciente"].Value;

                frmActualizarPaciente frmActualizarPaciente = new frmActualizarPaciente(Convert.ToInt16(idPaciente));
                frmActualizarPaciente.ShowDialog();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un paciente.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dtgPaciente.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dtgPaciente.SelectedRows[0];
                var idPaciente = filaSeleccionada.Cells["id_paciente"].Value;

                // Mostrar cuadro de confirmación
                var resultado = MessageBox.Show("¿Está seguro de que desea eliminar este paciente?",
                                                 "Confirmar eliminación",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);

                // Si el usuario selecciona "Sí", proceder con la eliminación
                if (resultado == DialogResult.Yes)
                {
                    objServPaciente.EliminarPaciente(Convert.ToInt16(idPaciente));
                    MessageBox.Show("Paciente eliminado con éxito");
                    CargarDatos();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un paciente.");
            }
        }
    }
}
