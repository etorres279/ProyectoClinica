using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacienteService;

namespace ClientesWindowsForm
{
    public partial class frmConsultarPaciente : Form
    {
        PacienteService.ServicioPacienteClient objServPaciente = new PacienteService.ServicioPacienteClient();

        PacienteDC pacienteDC;

        public frmConsultarPaciente(Int16 idPaciente)
        {
            InitializeComponent();
            pacienteDC = objServPaciente.ConsultarPaciente(idPaciente);
            LoadPaciente();
        }

        private void LoadPaciente()
        {
            txtId.Text = pacienteDC.id_paciente.ToString();
            txtNom.Text = pacienteDC.nombres.ToString();
            txtApe.Text = pacienteDC.apellidos.ToString();
            txtGenero.Text = pacienteDC.genero.ToString();
            txtCorreo.Text = pacienteDC.correo.ToString();
            txtTelefono.Text = pacienteDC.telefono.ToString();
            txtEdad.Text = pacienteDC.Edad.ToString();
            txtEstado.Text = pacienteDC.estado.ToString();
            txtDepartamento.Text = pacienteDC.Departamento.ToString();
            txtProvincia.Text = pacienteDC.Provincia.ToString();
            txtDistrito.Text = pacienteDC.Distrito.ToString();

            byte[] fotoEmpleadoBytes = pacienteDC.foto;
            if (fotoEmpleadoBytes != null && fotoEmpleadoBytes.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(fotoEmpleadoBytes))
                    {
                        pbFoto.Image = Image.FromStream(ms);
                    }
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("La foto del paciente no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pbFoto.Image = null;
                }
            }
            else
            {
                pbFoto.Image = null;
            }
        }
    }
}
