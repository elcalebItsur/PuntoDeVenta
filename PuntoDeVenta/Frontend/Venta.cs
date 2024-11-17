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
        private DataTable carrito; // Carrito de compras
        private decimal subtotal = 0; // Subtotal acumulado
        private decimal descuento = 0; // Descuento aplicado
        private decimal total = 0; // Total con IVA

        private void InicializarCarrito()
        {
            carrito = new DataTable();
            carrito.Columns.Add("Código de Barras");
            carrito.Columns.Add("Nombre");
            carrito.Columns.Add("Cantidad");
            carrito.Columns.Add("Precio Unitario");
            carrito.Columns.Add("Precio Total");

            dataGridView1.DataSource = carrito; // Vincular al DataGridView
        }


        public Venta()
        {
            InitializeComponent();
            InicializarCarrito();
        }

        private void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRealizarVenta_Click_1(object sender, EventArgs e)
        {
            if (carrito.Rows.Count == 0)
            {
                MessageBox.Show("El carrito está vacío.");
                return;
            }

            VentaDAO dao = new VentaDAO();
            if (dao.RealizarVenta(lblNombreUsuarioCajero.Text, carrito, descuento))
            {
                MessageBox.Show("Venta realizada con éxito.");
                carrito.Clear();
                subtotal = 0;
                ActualizarTotales();
            }
            else
            {
                MessageBox.Show("Error al realizar la venta.");
            }
        }


        private void txtCodigo_Barras_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidadProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarProductos_Click(object sender, EventArgs e)
        {
            string codigoBarras = txtCodigo_Barras.Text.Trim();
            int cantidad;

            if (!int.TryParse(txtCantidadProducto.Text, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.");
                return;
            }

            VentaDAO dao = new VentaDAO();
            var producto = dao.ObtenerProductoPorCodigo(codigoBarras);

            if (producto == null)
            {
                MessageBox.Show("Producto no encontrado.");
                return;
            }

            var (nombre, precio, stockProductos) = producto.Value;

            if (stockProductos < cantidad)
            {
                MessageBox.Show("No hay suficiente stock del producto.");
                return;
            }

            decimal precioTotal = cantidad * precio;
            carrito.Rows.Add(codigoBarras, nombre, cantidad, precio, precioTotal);

            subtotal += precioTotal;
            ActualizarTotales();

            txtCodigo_Barras.Clear();
            txtCantidadProducto.Clear();
        }




        private void btnCodigoBarrasElimiarProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminarProductoSeleccionado_Click(object sender, EventArgs e)
        {
            string codigoBarras = txtCodigo_Barras.Text.Trim();

            // Asegúrate de que el carrito es un DataTable
            DataTable carrito = (DataTable)dataGridView1.DataSource;

            if (carrito != null)
            {
                // Busca la fila en el carrito por código de barras
                var filas = carrito.Select($"[Código de Barras] = '{codigoBarras}'");

                if (filas.Length > 0)
                {
                    DataRow fila = filas[0];
                    decimal precioTotal = Convert.ToDecimal(fila["Precio Total"]);
                    subtotal -= precioTotal;

                    // Elimina la fila del DataTable
                    fila.Delete();

                    // Actualiza los totales
                    ActualizarTotales();
                }
                else
                {
                    MessageBox.Show("Producto no encontrado en el carrito.");
                }
            }
            else
            {
                MessageBox.Show("El carrito está vacío.");
            }

            txtCodigo_Barras.Clear();
        }



        private void lblNombreUsuarioCajero_Click(object sender, EventArgs e)
        {

        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotales();
        }


        private void txtSubtotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIVA_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlFinal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalSolo_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            carrito.Clear();
            subtotal = 0;
            ActualizarTotales();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ActualizarTotales()
        {
            descuento = string.IsNullOrEmpty(txtDescuento.Text) ? 0 : Convert.ToDecimal(txtDescuento.Text);
            total = (subtotal - descuento) * 1.16m;

            txtSubtotal.Text = subtotal.ToString("C");
            txtTotal.Text = total.ToString("C");
            txtIVA.Text = (total - (subtotal - descuento)).ToString("C");
            lblTotalSolo.Text = $"Total: {total:C}";
        }

    }
}
