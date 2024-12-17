using CitaWindowsForm;
using ClientesWindowsForm;
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
    public partial class MDIPrincipal : Form
    {
        public MDIPrincipal()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void MDIPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MDIPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult vrpta;
            vrpta = MessageBox.Show("Seguro de salir ?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (vrpta == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void MDIPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = clsCredenciales.Usuario;
        }

        private void btnPsicologos_Click(object sender, EventArgs e)
        {
            frmPsicologo frmPsicologos = new frmPsicologo();
            frmPsicologos.ShowDialog();
           
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            frmCita frmCitas = new frmCita();
            frmCitas.ShowDialog();
   
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            frmPaciente frmPacientes = new frmPaciente();
            frmPacientes.ShowDialog();
       
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
