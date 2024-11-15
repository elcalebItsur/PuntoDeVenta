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
            string cantidad = txtCantidad.Text;
            string precio = txtPrecio.Text;
            string codigoBarras = txtCodigo_Barras.Text;
            string cateoria = cmbCategoria.Text;

            // Verificamos que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo 'Nombre' no puede estar vacío.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("El campo 'Apellido' no puede estar vacío.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("El formato del correo electrónico no es válido.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCodigo_Barras.Text))
            {
                MessageBox.Show("El campo 'Correo Electrónico' no puede estar vacío.");
                return;
            }

            // Si todos los campos están llenos, llamamos al método para registrar el usuario
            try
            {
                productos.RegistrarProducto(txtNombre.Text, txtCantidad.Text, txtPrecio.Text, txtCodigo_Barras.Text, cmbCategoria.Text);
                MessageBox.Show("Usuario registrado correctamente.");

                // Limpiamos los campos después del registro exitoso
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el PRODUCTO: " + ex.Message);
            }

        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtCodigo_Barras.Clear();
        }
    }
}
