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
            List<KeyValuePair<string, string>> categorias = productoDAO.ObtenerCategorias();

            // Inserta la opción para añadir una nueva categoría
            categorias.Insert(0, new KeyValuePair<string, string>("0", "Añadir nueva categoría"));

            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "Value"; // Muestra el Nombre de la categoría
            cmbCategoria.ValueMember = "Key";    // Usa el ID como valor interno
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

            // Obtiene el ID de la categoría seleccionada
            string categoriaId = cmbCategoria.SelectedValue.ToString();

            if (categoriaId == "0") // Verifica si seleccionaron "Añadir nueva categoría"
            {
                MessageBox.Show("Por favor, seleccione una categoría válida.");
                return;
            }

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) || string.IsNullOrWhiteSpace(codigoBarras))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || !decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("El campo 'Cantidad' debe ser un número entero y el campo 'Precio' un número decimal.");
                return;
            }

            if (productos.ExisteProducto(codigoBarras))
            {
                MessageBox.Show("Ya existe un producto con el mismo código de barras.");
                LimpiarCampos();
                return;
            }

            try
            {
                productos.RegistrarProducto(nombre, cantidad, precio, codigoBarras, categoriaId);
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
            if (cmbCategoria.SelectedValue.ToString() == "0") // "Añadir nueva categoría"
            {
                string nuevaCategoria = PromptInput("Nueva Categoría", "Ingrese el nombre de la nueva categoría:");
                if (!string.IsNullOrWhiteSpace(nuevaCategoria))
                {
                    ProductoDAO productoDAO = new ProductoDAO();

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
