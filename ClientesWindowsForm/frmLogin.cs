using CitaWindowsForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsuarioService;

namespace ClientesWindowsForm
{
    public partial class frmLogin : Form
    {
        Int16 intentos = 0;
        Int16 tiempo = 60;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUsuario.Text) && !string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                try
                {
                    // Crear cliente del servicio WCF
                    ServicioUsuarioClient client = new ServicioUsuarioClient();

                    // Llamar al método Login del servicio
                    UsuarioDC usuario = client.Login(txtUsuario.Text.Trim(), txtContraseña.Text.Trim());

                    // Validar que el usuario existe y está activo
                    if (usuario != null && usuario.Estado == 1)
                    {
                        // Asignar valores a clsCredenciales
                        clsCredenciales.Usuario = usuario.Username;
                        clsCredenciales.Nivel = usuario.Nivel;
                        clsCredenciales.Estado = usuario.Estado;

                        MessageBox.Show("¡Bienvenido!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        timer1.Enabled = false;

                        // Abrir la ventana principal
                        MDIPrincipal objMDI = new MDIPrincipal();
                        objMDI.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña inválidos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        intentos += 1;
                        ValidaAccesos();
                    }

                    client.Close(); // Cerrar el cliente del servicio
                }
                catch (FaultException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intentos += 1;
                    ValidaAccesos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intentos += 1;
                    ValidaAccesos();
                }
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña son obligatorios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                intentos += 1;
                ValidaAccesos();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tiempo -= 1;
            this.Text = "Ingrese su usuario y contraseña. Le quedan..." + tiempo;
            if (tiempo == 0)
            {
                MessageBox.Show("Ha sobrepasado el tiempo de espera", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void ValidaAccesos()
        {
            if (intentos == 3)
            {
                MessageBox.Show("Ha sobrepasado el número de intentos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIngresar.PerformClick();
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
            Application.Exit();
        }
    }
}