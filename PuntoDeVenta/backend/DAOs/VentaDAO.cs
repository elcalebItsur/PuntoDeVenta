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

        public bool RealizarVenta(string empleadoId, string productoId, int cantidadVendida)
        {
            try
            {
                connection.Open();

                // 1. Verificar si hay suficiente stock del producto
                string verificarStockQuery = "SELECT Cantidad, Precio FROM productos WHERE IdProducto = @productoId";
                MySqlCommand verificarStockCmd = new MySqlCommand(verificarStockQuery, connection);
                verificarStockCmd.Parameters.AddWithValue("@productoId", productoId);

                MySqlDataReader reader = verificarStockCmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Producto no encontrado.");
                    return false;
                }

                int stockActual = Convert.ToInt32(reader["Cantidad"]);
                decimal precioProducto = Convert.ToDecimal(reader["Precio"]);
                reader.Close();

                if (stockActual < cantidadVendida)
                {
                    MessageBox.Show("No hay suficiente stock para realizar la venta.");
                    return false;
                }

                // 2. Calcular el precio total de la venta
                decimal precioTotal = cantidadVendida * precioProducto;

                // 3. Insertar el ticket de venta en la tabla ticket_venta
                string insertarTicketQuery = "INSERT INTO ticket_venta (EmpleadoId, ProductoId, Cantidad, PrecioTotal, Fecha) " +
                                             "VALUES (@empleadoId, @productoId, @cantidadVendida, @precioTotal, @fecha)";
                MySqlCommand insertarTicketCmd = new MySqlCommand(insertarTicketQuery, connection);
                insertarTicketCmd.Parameters.AddWithValue("@empleadoId", empleadoId);
                insertarTicketCmd.Parameters.AddWithValue("@productoId", productoId);
                insertarTicketCmd.Parameters.AddWithValue("@cantidadVendida", cantidadVendida);
                insertarTicketCmd.Parameters.AddWithValue("@precioTotal", precioTotal);
                insertarTicketCmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                insertarTicketCmd.ExecuteNonQuery();

                // 4. Disminuir el stock del producto
                string actualizarStockQuery = "UPDATE productos SET Cantidad =" +" Cantidad"+" - @cantidadVendida"+" WHERE IdProducto ="+" @productoId";
                MySqlCommand actualizarStockCmd = new MySqlCommand(actualizarStockQuery, connection);
                actualizarStockCmd.Parameters.AddWithValue("@cantidadVendida", cantidadVendida);
                actualizarStockCmd.Parameters.AddWithValue("@productoId", productoId);
                actualizarStockCmd.ExecuteNonQuery();

                // 5. Actualizar las ventas totales del empleado
                string actualizarVentasEmpleadoQuery = "UPDATE empleados SET VentasTotales = VentasTotales"+"+ @precioTotal"+" WHERE IdEmpleado ="+" @empleadoId";
                MySqlCommand actualizarVentasEmpleadoCmd = new MySqlCommand(actualizarVentasEmpleadoQuery, connection);
                actualizarVentasEmpleadoCmd.Parameters.AddWithValue("@precioTotal", precioTotal);
                actualizarVentasEmpleadoCmd.Parameters.AddWithValue("@empleadoId", empleadoId);
                actualizarVentasEmpleadoCmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la venta: " + ex.Message);
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
    }
}
