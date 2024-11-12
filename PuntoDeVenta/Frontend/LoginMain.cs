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
            string usuario = txtUsuario.Text;
            string contrasena = txtPassword.Text;

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            if (usuarioDAO.IniciarSesion(usuario, contrasena, out int usuarioId))
            {
                MessageBox.Show("Inicio de sesión exitoso.");
                this.Hide();

                // Abre el formulario Mensaje pasando el usuarioId
                VentanaPrincipal mensajeForm = new VentanaPrincipal(usuarioId);
                mensajeForm.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecto(s).");
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
