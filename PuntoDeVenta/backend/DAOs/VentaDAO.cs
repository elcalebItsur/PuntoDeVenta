using MySql.Data.MySqlClient;
using PuntoDeVenta.Backend;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PuntoDeVenta.backend.DAOs
{
    internal class VentaDAO
    {
        private MySqlConnection connection;

        public VentaDAO()
        {
            string connectionString = "Server=proyectobh.mysql.database.azure.com;Database=PuntoDeVenta;Uid=ProyectoU4;Pwd=SQL55H7#;";
            connection = new MySqlConnection(connectionString);
        }

        public bool RealizarVenta(string empleadoId, DataTable carrito, decimal descuento)
        {
            MySqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                decimal total = 0;

                foreach (DataRow row in carrito.Rows)
                {
                    string codigoBarras = row["Código de Barras"].ToString();
                    int cantidad = Convert.ToInt32(row["Cantidad"]);
                    decimal precioTotal = Convert.ToDecimal(row["Precio Total"]);

                    // Actualizar stock
                    string actualizarStockQuery = "UPDATE productos SET Cantidad = Cantidad - @cantidad WHERE CodigoBarras = @codigoBarras";
                    MySqlCommand actualizarStockCmd = new MySqlCommand(actualizarStockQuery, connection, transaction);
                    actualizarStockCmd.Parameters.AddWithValue("@cantidad", cantidad);
                    actualizarStockCmd.Parameters.AddWithValue("@codigoBarras", codigoBarras);
                    actualizarStockCmd.ExecuteNonQuery();

                    total += precioTotal;
                }

                // Insertar ticket
                total -= descuento;
                string insertarTicketQuery = "INSERT INTO ticket_venta (EmpleadoId, Total, Fecha) VALUES (@empleadoId, @total, @fecha)";
                MySqlCommand insertarTicketCmd = new MySqlCommand(insertarTicketQuery, connection, transaction);
                insertarTicketCmd.Parameters.AddWithValue("@empleadoId", empleadoId);
                insertarTicketCmd.Parameters.AddWithValue("@total", total);
                insertarTicketCmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                insertarTicketCmd.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction?.Rollback();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }




        public void MostarVentas(DataGridView dataGridView)
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM ticket_venta";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Asignamos el DataTable al DataGridView para mostrar los empleados
                dataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los empleados: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }


        }
        public (string Nombre, decimal Precio, int StockProductos)? ObtenerProductoPorCodigo(string codigoBarras)
        {
            try
            {
                connection.Open();
                string query = "SELECT Nombre, Precio, Stock_productos FROM productos WHERE Codigo_Barras = @codigoBarras";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@codigoBarras", codigoBarras);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var producto = (
                        reader["Nombre"].ToString(),
                        Convert.ToDecimal(reader["Precio"]),
                        Convert.ToInt32(reader["Stock_productos"])
                    );
                    return producto;
                }
                return null; // Producto no encontrado
            }
            finally
            {
                connection.Close();
            }
        }




    }
}
