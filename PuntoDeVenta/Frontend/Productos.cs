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
            CargarCategorias();
        }


        private void CargarCategorias()
        {
            ProductoDAO productoDAO = new ProductoDAO();
            List<string> categorias = productoDAO.ObtenerCategorias();

            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Añadir nueva categoría"); // Opción para añadir categoría
            cmbCategoria.Items.AddRange(categorias.ToArray());
            cmbCategoria.SelectedIndex = 0;
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

        private void btnModificarPrecio_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRegistrarNuevoProducto_Click(object sender, EventArgs e)
        {
            ProductoDAO productos = new ProductoDAO();
            productos.MostrarProductos(dataGridDatosP);
        }

        private void brnLimpiar_Click(object sender, EventArgs e)
        {
            dataGridDatosP.DataSource = null;
        }

        private void txtCodigoBarrasBorrar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            String codigoBarras = txtCodigoBarrasBorrar.Text;

            if (string.IsNullOrEmpty(codigoBarras))
            {
                MessageBox.Show("Por favor, ingrese un código de barras.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mostrar cuadro de confirmación
            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea eliminar el producto con el código de barras '{codigoBarras}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Si el usuario selecciona "No", no se ejecuta la eliminación
            if (confirmacion != DialogResult.Yes)
            {
                MessageBox.Show("OPeracion cancelada por el usuario","", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Instancia de ProductosDao
            ProductoDAO productosDao = new ProductoDAO();

            // Llama al método para eliminar el producto
            bool productoEliminado = productosDao.EliminarProductoPorCodigoBarras(codigoBarras);

            // Muestra un mensaje dependiendo del resultado
            if (productoEliminado)
            {
                MessageBox.Show("Producto eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoBarrasBorrar.Text = "";
            }
            else
            {
                MessageBox.Show("No se encontró un producto con ese código de barras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnModificarPrecio_Click_1(object sender, EventArgs e)
        {
            string codigoBarras = txtCódigoBarrasNuevoPrecio.Text.Trim();
            if (string.IsNullOrEmpty(codigoBarras))
            {
                MessageBox.Show("Por favor, ingrese un código de barras.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtNuevoPrecio.Text.Trim(), out decimal nuevoPrecio) || nuevoPrecio <= 0)
            {
                MessageBox.Show("Por favor, ingrese un precio válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmar la acción
            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea modificar el precio del producto con código de barras '{codigoBarras}' a {nuevoPrecio:C}?",
                "Confirmar modificación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
            {
                MessageBox.Show("OPeracion cancelada por el usuario", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Instancia de ProductosDao
            ProductoDAO productosDao = new ProductoDAO();

            // Llama al método para modificar el precio
            bool precioModificado = productosDao.ModificarPrecioPorCodigoBarras(codigoBarras, nuevoPrecio);

            // Muestra un mensaje dependiendo del resultado
            if (precioModificado)
            {
                txtCódigoBarrasNuevoPrecio.Text = "";
                txtNuevoPrecio.Text = "";
                MessageBox.Show("Precio modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se encontró un producto con ese código de barras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCódigoBarrasNuevoPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNuevoPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            ProductoDAO productos = new ProductoDAO();
            productos.MostrarProductos(dataGridDatosP);
        }

        private string PromptInput(string title, string promptText)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textLabel = new Label() { Left = 50, Top = 20, Text = promptText, AutoSize = true };
            TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 300 };
            Button confirmation = new Button() { Text = "OK", Left = 250, Width = 100, Top = 100, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : string.Empty;
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedItem.ToString() == "Añadir nueva categoría")
            {
                string nuevaCategoria = PromptInput("Nueva Categoría", "Ingrese el nombre de la nueva categoría:");
                if (!string.IsNullOrWhiteSpace(nuevaCategoria))
                {
                    ProductoDAO productoDAO = new ProductoDAO();

                    // Evitar duplicados
                    if (productoDAO.AgregarCategoria(nuevaCategoria, "Añadido por el usuario"))
                    {
                        MessageBox.Show("Categoría añadida exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCategorias();
                    }
                    else
                    {
                        MessageBox.Show("Ya existe una categoría con ese nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
