using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PuntoDeVenta
{
    public class UsuarioDAO
    {
        private MySqlConnection connection;

        public UsuarioDAO()
        {
            string connectionString = "Server=proyectobh.mysql.database.azure.com;Database=PuntoDeVenta;Uid=ProyectoU4;Pwd=SQL55H7#;";
            connection = new MySqlConnection(connectionString);
        }

        public bool IniciarSesion(string usuario, string contrasena, out string idEmpleado)
        {
            idEmpleado = null; // Inicializa como null
            try
            {
                connection.Open();
                string query = "SELECT IdEmpleado FROM empleados WHERE IdEmpleado = @usuario AND Clave_empleado = SHA2(@contrasena, 256)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);

                var result = cmd.ExecuteScalar(); // Devuelve el valor de IdEmpleado si existe

                if (result != null)
                {
                    idEmpleado = result.ToString(); // Captura el IdEmpleado
                    return true;
                }

                return false; // Credenciales incorrectas
            }
            finally
            {
                connection.Close();
            }
        }



       

    }
}
