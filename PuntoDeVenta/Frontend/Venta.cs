using PuntoDeVenta.backend.DAOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta.Frontend
{
    public partial class Venta : Form
    {
        public Venta()
        {
            InitializeComponent();
        }

        private void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            VentaDAO empleadoDAO = new VentaDAO();

            string empleadoId = txtEmpleadoId.Text;
            string productoId = txtProductoId.Text;
            int cantidadVendida;

            if (string.IsNullOrWhiteSpace(empleadoId) || string.IsNullOrWhiteSpace(productoId) || !int.TryParse(txtCantidad.Text, out cantidadVendida))
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.");
                return;
            }

            bool ventaExitosa = empleadoDAO.RealizarVenta(empleadoId, productoId, cantidadVendida);

            if (ventaExitosa)
            {
                MessageBox.Show("Venta realizada con éxito.");
                // Actualizar la interfaz o los datos mostrados, si es necesario
            }
            else
            {
                MessageBox.Show("No se pudo realizar la venta.");
            }
        }










    }
}
