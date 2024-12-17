using ClientesWindowsForm;
using System.Linq;
using static System.Windows.Forms.AxHost;

namespace CitaWindowsForm
{
    public partial class frmCita : Form
    {
        CitaService.ServicioCitaClient objServiceCita = new CitaService.ServicioCitaClient();

        public frmCita()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.frmCita_Load);
        }

        public void CargarDatos()
        {
            try
            {
                DateTime fechaInicio, fechaFin;

                if (dtpFecha.Checked) // Verifica si se seleccionó una fecha
                {
                    if (dtpFecha.Value.Date == DateTime.Parse("2024/01/01"))
                    {
                        // Si la fecha seleccionada es 01/01/2000, usar valores predeterminados
                        fechaInicio = DateTime.Parse("2000/01/01");
                        fechaFin = DateTime.Parse("2100/01/01");
                    }
                    else
                    {
                        // Si es otra fecha, calcular rango del día seleccionado
                        fechaInicio = dtpFecha.Value.Date;
                        fechaFin = fechaInicio.AddDays(1).AddTicks(-1);
                    }
                }
                else
                {
                    // Si no se selecciona ninguna fecha, usar valores predeterminados
                    fechaInicio = DateTime.Parse("2000/01/01");
                    fechaFin = DateTime.Parse("2100/01/01");
                }


                int estade = clsCredenciales.Nivel == 1 ? 0 : 1;

                // Obtener las citas y convertir a lista
                var citas = objServiceCita.ListarCitasPorFecha(fechaInicio, fechaFin, estade)?.ToList();

                if (!string.IsNullOrWhiteSpace(txtFiltroPaciente.Text))
                {
                    citas = citas?.Where(c => c.paciente.ToLower().Contains(txtFiltroPaciente.Text.ToLower())).ToList();
                }

                if (citas != null && citas.Any())
                {
                    dtgCita.DataSource = citas; // Asignar la lista al DataSource
                    dtgCita.Columns[0].Visible = false; // Ocultar la columna ID después de cargar los datos
                }
                else
                {
                    // Manejar el caso donde no hay citas
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.ToString());
            }
        }

        private void frmCita_Load(object sender, EventArgs e)
        {
            try
            {
                dtgCita.AutoGenerateColumns = false;
                ConfigurarColumnas();
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en frmCita_Load: " + ex.Message);
            }
        }

        private void txtFiltroPaciente_TextChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            CargarDatos(); // Recargar datos al cambiar la fecha
        }
        private void dtgCita_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Manejar el clic en el contenido de la celda si es necesario
        }
        private void ConfigurarColumnas()
        {
            dtgCita.Columns.Clear();

            dtgCita.Columns.Add(new DataGridViewTextBoxColumn { Name = "id", DataPropertyName = "id", HeaderText = "ID" });
            dtgCita.Columns.Add(new DataGridViewTextBoxColumn { Name = "fecha", DataPropertyName = "fecha", HeaderText = "Fecha" });
            dtgCita.Columns.Add(new DataGridViewTextBoxColumn { Name = "hora", DataPropertyName = "hora", HeaderText = "Hora" });
            dtgCita.Columns.Add(new DataGridViewTextBoxColumn { Name = "psicologo", DataPropertyName = "psicologo", HeaderText = "Psicólogo" });
            dtgCita.Columns.Add(new DataGridViewTextBoxColumn { Name = "paciente", DataPropertyName = "paciente", HeaderText = "Paciente" });
            dtgCita.Columns.Add(new DataGridViewTextBoxColumn { Name = "id_consultorio", DataPropertyName = "id_consultorio", HeaderText = "ID Consultorio" });
            dtgCita.Columns.Add(new DataGridViewTextBoxColumn { Name = "precio", DataPropertyName = "precio", HeaderText = "Precio" });
            dtgCita.Columns.Add(new DataGridViewTextBoxColumn { Name = "id_historial", DataPropertyName = "id_historial", HeaderText = "ID Historial" });
            dtgCita.Columns.Add(new DataGridViewTextBoxColumn { Name = "estado", DataPropertyName = "estado", HeaderText = "Estado" });

        }

        private void dtgCita_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificar si la columna es la de estado
            if (dtgCita.Columns[e.ColumnIndex].Name == "estado" && e.Value != null)
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


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dtgCita.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                var filaSeleccionada = dtgCita.SelectedRows[0];

                // Obtener el ID de la cita de la fila seleccionada
                var idCita = filaSeleccionada.Cells["id"].Value;

                frmConsultarCita frmConsultarCita = new frmConsultarCita(Convert.ToInt16(idCita));
                frmConsultarCita.ShowDialog();

            }
            else
            {
                // Mostrar un mensaje indicando que no hay ninguna fila seleccionada
                MessageBox.Show("Por favor, seleccione una cita.");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dtgCita.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                var filaSeleccionada = dtgCita.SelectedRows[0];

                // Obtener el ID de la cita de la fila seleccionada
                var idCita = filaSeleccionada.Cells["id"].Value;

                frmActualizarCita frmActualizarCita = new frmActualizarCita(Convert.ToInt16(idCita));
                frmActualizarCita.ShowDialog();
                CargarDatos();
            }
            else
            {
                // Mostrar un mensaje indicando que no hay ninguna fila seleccionada
                MessageBox.Show("Por favor, seleccione una cita.");
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            dtpFecha.Checked = false;
            CargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dtgCita.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una cita para eliminar.");
                return;
            }

            var filaSeleccionada = dtgCita.SelectedRows[0];

            // Obtener el ID de la cita de la fila seleccionada
            var idCita = filaSeleccionada.Cells["id"].Value;

            // Mostrar cuadro de confirmación
            var resultado = MessageBox.Show("¿Está seguro de que desea eliminar esta cita?",
                                             "Confirmar eliminación",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

            // Si el usuario selecciona "Sí", proceder con la eliminación
            if (resultado == DialogResult.Yes)
            {
                objServiceCita.EliminarCita(Convert.ToInt16(idCita));
                MessageBox.Show("Cita eliminada con éxito");
                CargarDatos();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmNuevaCita frmNuevaCita = new frmNuevaCita();
            frmNuevaCita.ShowDialog();
            CargarDatos();
        }
    }
}
