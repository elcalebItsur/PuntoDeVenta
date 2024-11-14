using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool RegistrarProducto(string nombre, int cantidad, double precio, string Codigo_barras, string categoria)
        {
            try
            {
                connection.Open();

                string query = "INSERT INTO productos (Nombre, cantidad, precio, Codigo_Barras, categoria)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@Precio", precio);
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

        public bool VerificarProducto(string nombre, string Codigo_barras, string categoria, out int productoid)
        {
            productoid = -1;
            try
            {
                connection.Open();
                string query = "SELECT idProducto FROM productos WHERE Nombre = @nombre AND Codigo_Barras = @codigo_barras AND idCategoria = @categoria";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@codigo_barras", Codigo_barras);
                cmd.Parameters.AddWithValue("@categoria", categoria);

                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    productoid = Convert.ToInt32(result);
                    return true;
                }

                return false;
            }
            finally
            {
                connection.Close();
            }
        }




    }
}
