using ClientesWindowsForm;
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
    public partial class frmPsicologo : Form
    {
        PsicologoService.ServicioPsicologoClient objServPsicologo = new PsicologoService.ServicioPsicologoClient();

        public frmPsicologo()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.frmPsicologo_Load);
        }

        public void CargarDatos()
        {
            try
            {
                dtgPsicologo.DataSource = null; // Limpiar el DataSource antes de cargar nuevos datos

                // Determinar el estado según el nivel de usuario
                short estade = clsCredenciales.Nivel == 1 ? (short)0 : (short)1;

                // Llamar al servicio pasando el estado
                List<PsicologoDC> misPsicologos = objServPsicologo.ListarPsicologo(estade);

                // Filtrar por nombre si hay texto en el filtro
                if (!string.IsNullOrWhiteSpace(txtFiltroNombre.Text))
                {
                    string filtroNombre = txtFiltroNombre.Text.ToLower();
                    misPsicologos = misPsicologos.Where(p => p.Nombre.ToLower().Contains(filtroNombre)).ToList();
                }

                // Asignar la lista filtrada al DataSource
                if (misPsicologos != null && misPsicologos.Any())
                {
                    dtgPsicologo.DataSource = misPsicologos;
                }
                else
                {
                    MessageBox.Show("No se encontraron psicólogos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void frmPsicologo_Load(object sender, EventArgs e)
        {
            try
            {
                dtgPsicologo.AutoGenerateColumns = false;
                ConfigurarColumnas();
                CargarDatos();

                // Suscribirse al evento TextChanged del filtro
                txtFiltroNombre.TextChanged += (s, args) => CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en frmPsicologo_Load: " + ex.Message);
            }
        }
        private void dtgCita_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Manejar el clic en el contenido de la celda si es necesario
        }
        private void ConfigurarColumnas()
        {
            dtgPsicologo.Columns.Clear();

            dtgPsicologo.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id_psicologo", DataPropertyName = "Id_psicologo", HeaderText = "ID", Visible = false });
            dtgPsicologo.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", DataPropertyName = "Nombre", HeaderText = "Nombre" });
            dtgPsicologo.Columns.Add(new DataGridViewTextBoxColumn { Name = "Especialidad", DataPropertyName = "Especialidad", HeaderText = "Especialidad" });
            dtgPsicologo.Columns.Add(new DataGridViewTextBoxColumn { Name = "Telefono", DataPropertyName = "Telefono", HeaderText = "Telefono" });
            dtgPsicologo.Columns.Add(new DataGridViewTextBoxColumn { Name = "Correo", DataPropertyName = "Correo", HeaderText = "Correo" });
            dtgPsicologo.Columns.Add(new DataGridViewTextBoxColumn { Name = "Departamento", DataPropertyName = "Departamento", HeaderText = "Departamento" });
            dtgPsicologo.Columns.Add(new DataGridViewTextBoxColumn { Name = "Provincia", DataPropertyName = "Provincia", HeaderText = "Provincia" });
            dtgPsicologo.Columns.Add(new DataGridViewTextBoxColumn { Name = "Distrito", DataPropertyName = "Distrito", HeaderText = "Distrito" });
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmNuevoPsicologo frmNuevoPsico = new frmNuevoPsicologo();
            frmNuevoPsico.ShowDialog();
            CargarDatos();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dtgPsicologo.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                var filaSeleccionada = dtgPsicologo.SelectedRows[0];

                // Obtener el ID de la cita de la fila seleccionada
                var idPsicologo = filaSeleccionada.Cells["Id_psicologo"].Value;

                frmConsultarPsicologo frmConsultarPsico = new frmConsultarPsicologo(Convert.ToInt16(idPsicologo));
                frmConsultarPsico.ShowDialog();

            }
            else
            {
                // Mostrar un mensaje indicando que no hay ninguna fila seleccionada
                MessageBox.Show("Por favor, seleccione una cita.");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dtgPsicologo.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                var filaSeleccionada = dtgPsicologo.SelectedRows[0];

                // Obtener el ID de la cita de la fila seleccionada
                var idPsicologo = filaSeleccionada.Cells["Id_psicologo"].Value;

                frmActualizarPsicologo frmActualizarPsicologo = new frmActualizarPsicologo(Convert.ToInt16(idPsicologo));
                frmActualizarPsicologo.ShowDialog();
                CargarDatos();
            }
            else
            {
                // Mostrar un mensaje indicando que no hay ninguna fila seleccionada
                MessageBox.Show("Por favor, seleccione un Psicologo.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dtgPsicologo.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dtgPsicologo.SelectedRows[0];
                var idPsicologo = filaSeleccionada.Cells["Id_psicologo"].Value;

                // Mostrar cuadro de confirmación
                var resultado = MessageBox.Show("¿Está seguro de que desea eliminar este psicólogo?",
                                                 "Confirmar eliminación",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);

                // Si el usuario selecciona "Sí", proceder con la eliminación
                if (resultado == DialogResult.Yes)
                {
                    objServPsicologo.EliminarPsicologo(Convert.ToInt16(idPsicologo));
                    MessageBox.Show("Psicólogo eliminado con éxito");
                    CargarDatos();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un psicólogo.");
            }
        }
    }
}
