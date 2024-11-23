using PuntoDeVenta.Frontend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta.Front_end
{
    public partial class LoginMain : Form
    {
        public LoginMain()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor, ingrese el usuario y la contraseña.");
                return;
            }

            UsuarioDAO usuarioDAO = new UsuarioDAO();

            try
            {
                if (usuarioDAO.IniciarSesion(usuario, contrasena, out string idEmpleado)) // Captura el IdEmpleado
                {
                    MessageBox.Show($"Inicio de sesión exitoso. Bienvenido {idEmpleado}.");
                    this.Hide();

                    // Abre el formulario principal pasando el IdEmpleado
                    VentanaPrincipal ventanaPrincipal = new VentanaPrincipal(idEmpleado);
                    ventanaPrincipal.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecto(s).");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar iniciar sesión: {ex.Message}");
            }
        }




        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
