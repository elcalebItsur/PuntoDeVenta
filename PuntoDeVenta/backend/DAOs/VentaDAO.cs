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

        public bool RealizarVenta(string empleadoId, DataTable carrito, decimal descuento, decimal total1, decimal iva)
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

                    // Verificar stock
                    string verificarStockQuery = "SELECT Stock_Productos FROM productos WHERE CodigoBarras = @codigoBarras";
                    MySqlCommand verificarStockCmd = new MySqlCommand(verificarStockQuery, connection, transaction);
                    verificarStockCmd.Parameters.AddWithValue("@codigoBarras", codigoBarras);
                    int stockActual = Convert.ToInt32(verificarStockCmd.ExecuteScalar());

                    if (stockActual < cantidad)
                    {
                        throw new Exception($"Stock insuficiente para el producto {codigoBarras}");
                    }

                    // Actualizar stock
                    string actualizarStockQuery = "UPDATE productos SET Stock_Productos = Stock_Productos - @cantidad WHERE CodigoBarras = @codigoBarras";
                    MySqlCommand actualizarStockCmd = new MySqlCommand(actualizarStockQuery, connection, transaction);
                    actualizarStockCmd.Parameters.AddWithValue("@cantidad", cantidad);
                    actualizarStockCmd.Parameters.AddWithValue("@codigoBarras", codigoBarras);
                    actualizarStockCmd.ExecuteNonQuery();

                    total += precioTotal;
                }

                // Insertar venta
                total -= descuento;
                string insertarVentaQuery = "INSERT INTO Venta (idEmpleado, Total, Iva, Descuento) VALUES (@empleadoId, @total1, @iva, @descuento)";
                MySqlCommand insertarVentaCmd = new MySqlCommand(insertarVentaQuery, connection, transaction);
                insertarVentaCmd.Parameters.AddWithValue("@empleadoId", empleadoId);
                
                insertarVentaCmd.Parameters.AddWithValue("@total1", total1);
                insertarVentaCmd.Parameters.AddWithValue("@iva", iva);
                insertarVentaCmd.Parameters.AddWithValue("@descuento", descuento);
                insertarVentaCmd.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                Console.WriteLine($"Error: {ex.Message}");
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
