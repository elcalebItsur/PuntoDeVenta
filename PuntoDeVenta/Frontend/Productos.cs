using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuntoDeVenta.backend;
using PuntoDeVenta.backend.DAOs;
using System.Text.RegularExpressions;

namespace PuntoDeVenta.Frontend
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ProductoDAO productos = new ProductoDAO();
            string nombre = txtNombre.Text;
            string codigoBarras = txtCodigo_Barras.Text;
            string categoria = cmbCategoria.Text;
            cmbCategoria.Items.Insert(0, "");
            cmbCategoria.SelectedIndex = 0;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) || string.IsNullOrWhiteSpace(codigoBarras) ||
                string.IsNullOrWhiteSpace(categoria))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || !decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("El campo 'Cantidad' debe ser un número entero y el campo 'Precio' un número decimal.");
                return;
            }

            // Verificar si el producto ya existe
            if (productos.ExisteProducto(codigoBarras))
            {
                MessageBox.Show("Ya existe un producto con el mismo código de barras.");
                LimpiarCampos();
                return;
            }

            // Registrar el producto si no existe
            try
            {
                productos.RegistrarProducto(nombre, cantidad, precio, codigoBarras, categoria);
                MessageBox.Show("Producto registrado correctamente.");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el producto: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtCodigo_Barras.Clear();
            cmbCategoria.SelectedIndex = 0;
        }

       

        private void btnRegistrarNuevoProducto_Click(object sender, EventArgs e)
        {
            ProductoDAO productos = new ProductoDAO();
            productos.MostrarProductos(dataGridDatosP);
        }

        private void brnLimpiar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
