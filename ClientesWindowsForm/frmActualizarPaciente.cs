using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacienteService;
using UbigeoService;

namespace ClientesWindowsForm
{
    public partial class frmActualizarPaciente : Form
    {
        PacienteService.ServicioPacienteClient objServPaciente = new PacienteService.ServicioPacienteClient();
        UbigeoService.ServicioUbigeoClient objServUbigeo = new UbigeoService.ServicioUbigeoClient();
        PacienteDC pacienteDC;

        public Byte[]? fotoData = null;

        public frmActualizarPaciente(Int16 idPaciente)
        {
            InitializeComponent();
            pacienteDC = objServPaciente.ConsultarPaciente(idPaciente);
            LoadPaciente();
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

        private void LoadPaciente()
        {
            PacienteDC paciente = objServPaciente.ConsultarPaciente(Convert.ToInt16(pacienteDC.id_paciente));

            txtId.Text = pacienteDC.id_paciente.ToString();
            txtNom.Text = pacienteDC.nombres.ToString();
            txtApe.Text = pacienteDC.apellidos.ToString();

            if (pacienteDC.genero.ToString() == "M")
            {
                rbM.Checked = true;
            }
            else
            {
                rbF.Checked = true;
            }

            txtCorreo.Text = pacienteDC.correo.ToString();
            txtTelefono.Text = pacienteDC.telefono.ToString();
            var departamentos = objServUbigeo.ListarDepartamentos();
            departamentos.Insert(0, new UbigeoDC { idDepa = "", Departamento = "--Departamento--" });
            cboDepartamento.DataSource = departamentos;
            cboDepartamento.DisplayMember = "Departamento";
            cboDepartamento.ValueMember = "idDepa";
            cboDepartamento.SelectedIndex = 0;

            // Cargar el ubigeo actual
            if (!string.IsNullOrEmpty(pacienteDC.id_ubigeo))
            {
                var ubigeo = objServUbigeo.ConsultarUbigeo(pacienteDC.id_ubigeo);
                cboDepartamento.SelectedValue = ubigeo.idDepa;
                CargarProvincias(ubigeo.idDepa);
                cboProvincia.SelectedValue = ubigeo.idProv;
                CargarDistritos(ubigeo.idDepa, ubigeo.idProv);
                cboDistrito.SelectedValue = ubigeo.idDist;
            }


            if (clsCredenciales.Nivel == 1)
            {
                checkActivo.Visible = true; // Mostrar el CheckBox
                checkActivo.Checked = pacienteDC.estado != 0; // Verificar que estado no sea igual a 0
            }
            else
            {
                checkActivo.Visible = false; // Ocultar el CheckBox
                pacienteDC.estado = 1; // Asegurar que el estado sea 1
            }

            fotoData = pacienteDC.foto;
            byte[] fotoEmpleadoBytes = pacienteDC.foto;
            if (fotoEmpleadoBytes != null && fotoEmpleadoBytes.Length > 0)
            {
                Image fotoEmpleado;
                using (MemoryStream ms = new MemoryStream(fotoEmpleadoBytes))
                {
                    fotoEmpleado = Image.FromStream(ms);
                }

                pbFoto.Image = fotoEmpleado;
            }
            else
            {
                pbFoto.Image = null;
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

                if (string.IsNullOrWhiteSpace(txtNom.Text) ||
                    string.IsNullOrWhiteSpace(txtApe.Text) ||
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

                pacienteDC.nombres = txtNom.Text;
                pacienteDC.apellidos = txtApe.Text;

                if (rbM.Checked)
                {
                    pacienteDC.genero = "M";
                }
                else
                {
                    pacienteDC.genero = "F";
                }

                pacienteDC.telefono = txtTelefono.Text;
                pacienteDC.correo = txtCorreo.Text;
                pacienteDC.id_ubigeo = distritoSeleccionado.id_ubigeo;

                if (checkActivo.Checked == true)
                {
                    pacienteDC.estado = 1;
                }
                else
                {
                    pacienteDC.estado = 0;
                }

                pacienteDC.foto = fotoData;

                objServPaciente.ActualizarPaciente(pacienteDC);
                MessageBox.Show("Cita actualizada con éxito!");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Archivos de imagen (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
            openFileDialog1.Title = "Seleccionar foto";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFileDialog1.FileName;

                FileInfo fileInfo = new FileInfo(rutaArchivo);
                long tamanoArchivoBytes = fileInfo.Length;
                long tamanoMaximoBytes = 5 * 1024 * 1024; // 5 MB

                if (tamanoArchivoBytes > tamanoMaximoBytes)
                {
                    MessageBox.Show("El tamaño del archivo excede el límite permitido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                byte[] contenidoArchivo = File.ReadAllBytes(rutaArchivo);
                fotoData = contenidoArchivo;


                pbFoto.Image = Image.FromFile(rutaArchivo);
            }
        }
    }
}
