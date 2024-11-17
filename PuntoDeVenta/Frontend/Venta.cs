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

            // Calcular IVA (suponiendo una tasa del 16%)
            decimal iva = subtotal * 0.16m;

            // Realiza la venta
            VentaDAO dao = new VentaDAO();
            bool ventaExitosa = dao.RealizarVenta(
                "EMP001",  // Id del empleado (o nombre, ajusta según sea necesario)
                carrito,                     // Carrito (DataTable con productos)
                total,
                descuento,                   // Descuento
                iva                          // IVA calculado
            );

            // Manejar resultado
            if (ventaExitosa)
            {
                MessageBox.Show("Venta realizada con éxito.");
                carrito.Clear();  // Limpia el carrito después de la venta
                subtotal = 0;     // Resetea el subtotal
                ActualizarTotales(); // Actualiza la interfaz
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
            try
            {
                // Obtener el código de barras y cantidad
                string codigoBarras = txtCodigo_Barras.Text.Trim();
                if (string.IsNullOrWhiteSpace(codigoBarras))
                {
                    MessageBox.Show("Ingrese un código de barras válido.");
                    return;
                }

                if (!int.TryParse(txtCantidadProducto.Text, out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida.");
                    return;
                }

                // Buscar el producto en la base de datos
                VentaDAO dao = new VentaDAO();
                var producto = dao.ObtenerProductoPorCodigo(codigoBarras);

                if (producto == null)
                {
                    MessageBox.Show("Producto no encontrado.");
                    return;
                }

                // Desempaquetar el producto encontrado
                var (nombre, precio, stockProductos) = producto.Value;

                // Validar stock disponible
                if (stockProductos < cantidad)
                {
                    MessageBox.Show($"Stock insuficiente. Disponible: {stockProductos}");
                    return;
                }

                // Calcular el precio total y agregar al carrito
                decimal precioTotal = cantidad * precio;

                if (carrito == null)
                {
                    // Inicializar carrito si está nulo
                    carrito = new DataTable();
                    carrito.Columns.Add("Código de Barras", typeof(string));
                    carrito.Columns.Add("Nombre", typeof(string));
                    carrito.Columns.Add("Cantidad", typeof(int));
                    carrito.Columns.Add("Precio Unitario", typeof(decimal));
                    carrito.Columns.Add("Precio Total", typeof(decimal));
                }

                carrito.Rows.Add(codigoBarras, nombre, cantidad, precio, precioTotal);

                // Actualizar subtotal y totales
                subtotal += precioTotal;
                ActualizarTotales();

                // Limpiar campos de entrada
                txtCodigo_Barras.Clear();
                txtCantidadProducto.Clear();
            }
            catch (Exception ex)
            {
                // Manejo general de errores
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }



        private void btnCodigoBarrasElimiarProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminarProductoSeleccionado_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el valor del código de barras ingresado
                string codigoBarras = btnCodigoBarrasElimiarProducto.Text.Trim();

                // Validar que el campo no esté vacío
                if (string.IsNullOrWhiteSpace(codigoBarras))
                {
                    MessageBox.Show("Por favor, ingrese un código de barras válido.");
                    return;
                }

                // Asegúrate de que el carrito no sea nulo
                if (carrito == null || carrito.Rows.Count == 0)
                {
                    MessageBox.Show("El carrito está vacío.");
                    return;
                }

                // Buscar la fila correspondiente al código de barras
                var filas = carrito.Select($"[Código de Barras] = '{codigoBarras}'");

                if (filas.Length > 0)
                {
                    // Si la fila existe, elimínala
                    DataRow fila = filas[0];
                    decimal precioTotal = Convert.ToDecimal(fila["Precio Total"]);
                    subtotal -= precioTotal;

                    fila.Delete();
                    carrito.AcceptChanges();

                    // Actualiza la fuente de datos del DataGridView
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = carrito;

                    // Actualizar los totales
                    ActualizarTotales();
                }
                else
                {
                    MessageBox.Show("Producto no encontrado en el carrito.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
            finally
            {
                // Limpiar el campo de código de barras
                txtCodigo_Barras.Clear();
            }
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
