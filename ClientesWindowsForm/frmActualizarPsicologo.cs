using PsicologoService;
using UbigeoService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientesWindowsForm;

namespace CitaWindowsForm
{
    public partial class frmActualizarPsicologo : Form
    {
        PsicologoService.ServicioPsicologoClient objServPsicologo = new PsicologoService.ServicioPsicologoClient();
        UbigeoService.ServicioUbigeoClient objServUbigeo = new UbigeoService.ServicioUbigeoClient();
        PsicologoDC psicologoDC;

        public frmActualizarPsicologo(Int16 Id_Psicologo)
        {
            InitializeComponent();
            psicologoDC = objServPsicologo.ConsultarPsicologo(Id_Psicologo);
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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Suprimir la entrada no válida
            }

            // Limitar a 9 caracteres
            if (txtTelefono.Text.Length == 9 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Suprimir la entrada si ya hay 9 caracteres
            }
        }

        private void frmActualizarPsicologo_Load(object sender, EventArgs e)
        {
            txtIdPsico.Text = psicologoDC.Id_psicologo.ToString();
            txtNomApe.Text = psicologoDC.Nombre;
            txtEspecialidad.Text = psicologoDC.Especialidad;
            txtTelefono.Text = psicologoDC.Telefono;
            txtCorreo.Text = psicologoDC.Correo;

            // Cargar Departamentos
            var departamentos = objServUbigeo.ListarDepartamentos();
            departamentos.Insert(0, new UbigeoDC { idDepa = "", Departamento = "--Departamento--" });
            cboDepartamento.DataSource = departamentos;
            cboDepartamento.DisplayMember = "Departamento";
            cboDepartamento.ValueMember = "idDepa";
            cboDepartamento.SelectedIndex = 0;

            // Cargar el ubigeo actual
            if (!string.IsNullOrEmpty(psicologoDC.Id_ubigeo))
            {
                var ubigeo = objServUbigeo.ConsultarUbigeo(psicologoDC.Id_ubigeo);
                cboDepartamento.SelectedValue = ubigeo.idDepa;
                CargarProvincias(ubigeo.idDepa);
                cboProvincia.SelectedValue = ubigeo.idProv;
                CargarDistritos(ubigeo.idDepa, ubigeo.idProv);
                cboDistrito.SelectedValue = ubigeo.idDist;
            }

            if (clsCredenciales.Nivel == 1)
            {
                checkActivo.Visible = true; // Mostrar el CheckBox
                checkActivo.Checked = psicologoDC.EstadoPsico == "Activo"; // Verificar que estado sea "Activo"
            }
            else
            {
                checkActivo.Visible = false; // Ocultar el CheckBox
                psicologoDC.Estado = 1; // Asegurar que el estado sea 1
            }
        }

        private void CargarProvincias(string idDepartamento)
        {
            var provincias = objServUbigeo.ListarProvinciasPorDepartamento(idDepartamento);
            provincias.Insert(0, new UbigeoDC { idProv = "", Provincia = "--Provincia--" });
            cboProvincia.DataSource = provincias;
            cboProvincia.DisplayMember = "Provincia";
            cboProvincia.ValueMember = "idProv";
            cboProvincia.SelectedIndex = 0;
        }

        private void CargarDistritos(string idDepartamento, string idProvincia)
        {
            var distritos = objServUbigeo.ListarDistritosPorDepartamentoYProvincia(idDepartamento, idProvincia);
            distritos.Insert(0, new UbigeoDC { idDist = "", Distrito = "--Distrito--" });
            cboDistrito.DataSource = distritos;
            cboDistrito.DisplayMember = "Distrito";
            cboDistrito.ValueMember = "idDist";
            cboDistrito.SelectedIndex = 0;
        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.SelectedValue != null && !string.IsNullOrEmpty(cboDepartamento.SelectedValue.ToString()))
            {
                string idDepartamento = cboDepartamento.SelectedValue.ToString();

                // Limpiar ComboBox de provincias y distritos
                cboProvincia.DataSource = null; // Limpiar provincias
                cboDistrito.DataSource = null; // Limpiar distritos

                // Cargar Provincias según el Departamento seleccionado
                CargarProvincias(idDepartamento);
            }
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedValue != null && !string.IsNullOrEmpty(cboProvincia.SelectedValue.ToString()))
            {
                string idDepartamento = cboDepartamento.SelectedValue.ToString();
                string idProvincia = cboProvincia.SelectedValue.ToString();

                // Limpiar ComboBox de distritos
                cboDistrito.DataSource = null; // Limpiar distritos

                // Cargar Distritos según la Provincia seleccionada
                CargarDistritos(idDepartamento, idProvincia);
            }
        }
        private void cboDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Este evento puede ser utilizado para realizar acciones adicionales si es necesario
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que no haya campos vacíos
                if (string.IsNullOrWhiteSpace(txtNomApe.Text) ||
                    string.IsNullOrWhiteSpace(txtEspecialidad.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(txtCorreo.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return; // Salir del método si hay campos vacíos
                }

                // Verificar que el teléfono tenga exactamente 9 números
                if (txtTelefono.Text.Length != 9 || !txtTelefono.Text.All(char.IsDigit))
                {
                    MessageBox.Show("El teléfono debe contener exactamente 9 números.");
                    return; // Salir del método si el teléfono no es válido
                }

                // Verificar que el correo contenga un '@'
                if (!txtCorreo.Text.Contains("@"))
                {
                    MessageBox.Show("Por favor, ingrese un correo electrónico válido.");
                    return; // Salir del método si el correo no es válido
                }

                // Verificar que se haya seleccionado un distrito
                if (cboDistrito.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, seleccione un distrito.");
                    return; // Salir del método si no hay selección
                }

                // Obtener el distrito seleccionado
                var distritoSeleccionado = (UbigeoDC)cboDistrito.SelectedItem;

                // Actualizar los campos del psicólogo
                psicologoDC.Nombre = txtNomApe.Text;
                psicologoDC.Especialidad = txtEspecialidad.Text;
                psicologoDC.Telefono = txtTelefono.Text;
                psicologoDC.Correo = txtCorreo.Text;
                psicologoDC.Id_ubigeo = distritoSeleccionado.id_ubigeo;

                if (checkActivo.Checked == true)
                {
                    psicologoDC.Estado = 1;
                }
                else
                {
                    psicologoDC.Estado = 0;
                }

                objServPsicologo.ActualizarPsicologo(psicologoDC);
                MessageBox.Show("Cita actualizada con éxito!");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
