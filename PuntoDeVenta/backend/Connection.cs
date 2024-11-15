using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PuntoDeVenta.Backend
{
    public class Connection
    {
        private MySqlConnection connection;
        private readonly string connectionString;

        public Connection()
        {
            // Cambia esto por la cadena de conexión a tu base de datos
            connectionString = "Server=proyectobh.mysql.database.azure.com;Database=PuntoDeVenta;Uid=ProyectoU4;Pwd=SQL55H7#;";
            connection = new MySqlConnection(connectionString);
        }

        // Método para abrir la conexión
        public void OpenConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                    MessageBox.Show("Conexión exitosa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Método para cerrar la conexión
        public void CloseConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Conexión cerrada exitosamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
            }
        }

        // Propiedad para obtener la conexión, en caso de que necesites usarla
        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}