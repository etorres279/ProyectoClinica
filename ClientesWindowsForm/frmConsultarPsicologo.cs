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
    public partial class frmConsultarPsicologo : Form
    {
        PsicologoService.ServicioPsicologoClient objServPsicologo = new PsicologoService.ServicioPsicologoClient();
        PsicologoDC psicologoDC;

        public frmConsultarPsicologo(Int16 idPsicologo)
        {
            InitializeComponent();
            psicologoDC = objServPsicologo.ConsultarPsicologo(idPsicologo);
        }

        private void frmConsultarPsicologo_Load(object sender, EventArgs e)
        {
            PsicologoDC psicologo = objServPsicologo.ConsultarPsicologo(Convert.ToInt16(psicologoDC.Id_psicologo));

            txtId.Text = psicologoDC.Id_psicologo.ToString();
            txtNomApe.Text = psicologoDC.Nombre.ToString();
            txtEspecialidad.Text = psicologoDC.Especialidad.ToString();
            txtTelefono.Text = psicologoDC.Telefono.ToString();
            txtCorreo.Text = psicologoDC.Correo.ToString();
            txtEstado.Text = psicologoDC.EstadoPsico.ToString();
            txtDepartamento.Text = psicologoDC.Departamento.ToString();
            txtProvincia.Text = psicologoDC.Provincia.ToString();
            txtDistrito.Text = psicologoDC.Distrito.ToString();
            txtFechRegis.Text = psicologoDC.Fecha_registro.ToString();
            txtFechModi.Text = psicologoDC.Fecha_ult_modificacion.ToString();

        }
    }
}
