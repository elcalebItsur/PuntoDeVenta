using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace PuntoDeVenta.Frontend
{
    public partial class VentanaPrincipal : Form
    {
        private string idEmpleado;

        public VentanaPrincipal(string idEmpleado)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;
        }
    


    private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnMinimizarTamaño.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void btnMinimizarTamaño_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMinimizarTamaño.Visible= false;
            btnMaximizar.Visible= true;
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
           subMenuReportes.Visible = true;
        }

        private void btnrpVenta_Click(object sender, EventArgs e)
        {
            subMenuReportes.Visible= false;
        }

        private void btnrpCompra_Click(object sender, EventArgs e)
        {
            subMenuReportes.Visible = false;
        }

        private void btnrpPago_Click(object sender, EventArgs e)
        {
            subMenuReportes.Visible = false;
        }

        private void contendor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            subMenuReportes.Visible= false ;
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            subMenuReportes.Visible = false;

            // Pedir contraseña
            string contraseñaCorrecta = "12345"; // Contraseña correcta (puedes obtenerla de una configuración o base de datos)
            string contraseñaIngresada = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingrese la contraseña de 5 dígitos para acceder a los productos:",
                "Verificación de contraseña");

            // Validar contraseña
            if (contraseñaIngresada == contraseñaCorrecta)
            {
                SesionActual.IdEmpleado = idEmpleado;

                abrirFormHoja(new Productos()); // Abre el formulario si la contraseña es correcta
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta. Acceso denegado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static class SesionActual
        {
            public static string IdEmpleado { get; set; }
        }


        private void btnVenta_Click(object sender, EventArgs e)
        {
            subMenuReportes.Visible = false;
            abrirFormHoja(new Venta());
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            subMenuReportes.Visible = false;
        }

        private void btnVerificarPrecios_Click(object sender, EventArgs e)
        {
            subMenuReportes.Visible = false;
        }

        private void btnConsultarVenta_Click(object sender, EventArgs e)
        {
            subMenuReportes.Visible = false;
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            subMenuReportes.Visible = false;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void abrirFormHoja(object formHija)
        {
            if (this.contendor.Controls.Count > 0)
            {
                this.contendor.Controls.Clear();    
            }
            Form fh = formHija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.contendor.Controls.Add(fh);
            this.contendor.Tag = fh;
            fh.Show();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            subMenuReportes.Visible = false;
            abrirFormHoja(new Empleados());
        }
    }
}
