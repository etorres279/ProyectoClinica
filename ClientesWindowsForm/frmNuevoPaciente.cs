﻿using System;
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
    public partial class frmNuevoPaciente : Form
    {
        PacienteService.ServicioPacienteClient objServPaciente = new PacienteService.ServicioPacienteClient();
        UbigeoService.ServicioUbigeoClient objServUbigeo = new UbigeoService.ServicioUbigeoClient(); // Asegúrate de tener este servicio
        PacienteDC pacienteDC;

        public Byte[]? fotoData = null;

        public frmNuevoPaciente()
        {
            InitializeComponent();
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

        private void frmNuevoPaciente_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargar Departamentos
                var departamentos = objServUbigeo.ListarDepartamentos();
                departamentos.Insert(0, new UbigeoDC { idDepa = "", Departamento = "--Departamento--" }); // Agregar marcador de posición
                cboDepartamento.DataSource = departamentos;
                cboDepartamento.DisplayMember = "Departamento";
                cboDepartamento.ValueMember = "idDepa";
                cboDepartamento.SelectedIndex = 0; // Seleccionar el marcador de posición

                // Suscribirse al evento SelectedIndexChanged
                cboDepartamento.SelectedIndexChanged += CboDepartamento_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar departamentos: " + ex.Message);
            }
        }

        private void CboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Limpiar ComboBox de provincias y distritos
                cboProvincia.DataSource = null;
                cboDistrito.DataSource = null;

                // Desuscribirse de eventos para evitar llamadas múltiples
                cboProvincia.SelectedIndexChanged -= CboProvincia_SelectedIndexChanged;
                cboDistrito.SelectedIndexChanged -= cboDistrito_SelectedIndexChanged;

                // Cargar Provincias según el Departamento seleccionado
                if (cboDepartamento.SelectedValue != null && !string.IsNullOrEmpty(cboDepartamento.SelectedValue.ToString()))
                {
                    string idDepartamento = cboDepartamento.SelectedValue.ToString();
                    var provincias = objServUbigeo.ListarProvinciasPorDepartamento(idDepartamento);
                    provincias.Insert(0, new UbigeoDC { idProv = "", Provincia = "--Provincia--" }); // Agregar marcador de posición
                    cboProvincia.DataSource = provincias;
                    cboProvincia.DisplayMember = "Provincia";
                    cboProvincia.ValueMember = "idProv";
                    cboProvincia.SelectedIndex = 0; // Seleccionar el marcador de posición

                    // Suscribirse al evento SelectedIndexChanged
                    cboProvincia.SelectedIndexChanged += CboProvincia_SelectedIndexChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar provincias: " + ex.Message);
            }
        }

        private void CboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Limpiar ComboBox de distritos
                cboDistrito.DataSource = null;

                // Cargar Distritos según la Provincia seleccionada
                if (cboProvincia.SelectedValue != null && !string.IsNullOrEmpty(cboProvincia.SelectedValue.ToString()))
                {
                    string idDepartamento = cboDepartamento.SelectedValue.ToString();
                    string idProvincia = cboProvincia.SelectedValue.ToString();
                    var distritos = objServUbigeo.ListarDistritosPorDepartamentoYProvincia(idDepartamento, idProvincia);
                    distritos.Insert(0, new UbigeoDC { idDist = "", Distrito = "--Distrito--" }); // Agregar marcador de posición
                    cboDistrito.DataSource = distritos;
                    cboDistrito.DisplayMember = "Distrito";
                    cboDistrito.ValueMember = "idDist";
                    cboDistrito.SelectedIndex = 0; // Seleccionar el marcador de posición
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar distritos: " + ex.Message);
            }
        }

        private void cboDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Este evento puede ser utilizado para realizar acciones adicionales si es necesario
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que no haya campos vacíos
                if (string.IsNullOrWhiteSpace(txtNom.Text))
                {
                    MessageBox.Show("Por favor, ingrese el nombre.");
                    txtNom.Focus(); // Enfocar el campo correspondiente
                    return; // Salir del método si hay campos vacíos
                }

                if (string.IsNullOrWhiteSpace(txtApe.Text))
                {
                    MessageBox.Show("Por favor, ingrese el apellido.");
                    txtApe.Focus(); // Enfocar el campo correspondiente
                    return; // Salir del método si hay campos vacíos
                }

                if (string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    MessageBox.Show("Por favor, ingrese el teléfono.");
                    txtTelefono.Focus(); // Enfocar el campo correspondiente
                    return; // Salir del método si hay campos vacíos
                }

                if (string.IsNullOrWhiteSpace(txtCorreo.Text))
                {
                    MessageBox.Show("Por favor, ingrese el correo electrónico.");
                    txtCorreo.Focus(); // Enfocar el campo correspondiente
                    return; // Salir del método si hay campos vacíos
                }

                // Verificar que el teléfono tenga exactamente 9 números
                if (txtTelefono.Text.Length != 9 || !txtTelefono.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Por favor, ingrese un telefono valido.");
                    txtTelefono.Focus(); // Enfocar el campo correspondiente
                    return; // Salir del método si el teléfono no es válido
                }

                // Verificar que el correo contenga un '@'
                if (!txtCorreo.Text.Contains("@"))
                {
                    MessageBox.Show("Por favor, ingrese un correo electrónico válido.");
                    txtCorreo.Focus(); // Enfocar el campo correspondiente
                    return; // Salir del método si el correo no es válido
                }

                // Verificar que se haya seleccionado un distrito
                if (cboDistrito.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, seleccione un distrito.");
                    cboDistrito.Focus(); // Enfocar el campo correspondiente
                    return; // Salir del método si no hay selección
                }

                // Obtener el distrito seleccionado
                var distritoSeleccionado = (UbigeoDC)cboDistrito.SelectedItem;

                PacienteDC pacienteDC = new PacienteDC
                {
                    nombres = txtNom.Text,
                    apellidos = txtApe.Text,
                    genero = rbM.Checked ? "M" : "F", // Asignar género basado en la selección
                    telefono = txtTelefono.Text,
                    correo = txtCorreo.Text,
                    id_ubigeo = distritoSeleccionado.id_ubigeo, // Asignar el id_ubigeo del distrito seleccionado
                    estado = 1,
                    Usuario_Registro = null,
                    Usuario_ult_modificacion = null,
                    Fecha_ult_modificacion = null,
                    Fecha_Registro = null,
                    foto = fotoData,
                    FechaNacimiento = dtpFechNaci.Value
                };

                objServPaciente.InsertarPaciente(pacienteDC);
                MessageBox.Show("Paciente creado con éxito!");
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
