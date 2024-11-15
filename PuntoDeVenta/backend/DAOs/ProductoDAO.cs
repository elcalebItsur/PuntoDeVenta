using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta.backend.DAOs
{
    internal class ProductoDAO
    {
        private MySqlConnection connection;

        public ProductoDAO()
        {
            string connectionString = "Server=proyectobh.mysql.database.azure.com;Database=PuntoDeVenta;Uid=ProyectoU4;Pwd=SQL55H7#;";
            connection = new MySqlConnection(connectionString);
        }

        public bool RegistrarProducto(string nombre, int stock, decimal precio, string Codigo_barras, string categoria)
        {
            try
            {
                connection.Open();

                string query = "INSERT INTO productos (Nombre, Stock_productos, Precio, Codigo_Barras, idCategoria) "
                             + "VALUES (@nombre, @stock, @precio, @Codigo_Barras, @categoria)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@Codigo_Barras", Codigo_barras);
                cmd.Parameters.AddWithValue("@categoria", categoria);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public void MostrarProductos(DataGridView dataGridView)
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM productos";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Asignamos el DataTable al DataGridView para mostrar los productos
                dataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los productos: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public bool ExisteProducto(string Codigo_barras)
        {
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM productos WHERE Codigo_Barras = @Codigo_Barras";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Codigo_Barras", Codigo_barras);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            finally
            {
                connection.Close();
            }
        }


        




    }
}
