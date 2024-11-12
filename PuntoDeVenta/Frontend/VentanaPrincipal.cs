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

namespace PuntoDeVenta.Frontend
{
    public partial class VentanaPrincipal : Form
    {
        private int usuarioId; // Almacenar el usuario logueado
        public VentanaPrincipal(int usuarioId)
        {
            InitializeComponent();
            this.usuarioId = usuarioId;
            //this.WindowState = FormWindowState.Maximized;
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
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            subMenuReportes.Visible = false;
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
    }
}
