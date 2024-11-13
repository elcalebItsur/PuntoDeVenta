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

        public bool RegistrarUsuario(string nombre, string apellido, string correo, string usuario, string contrasena)
        {
            try
            {
                connection.Open();

                string query = "INSERT INTO usuarios (nombre, apellido, correo_electronico, usuario, contrasena) " +
                               "VALUES (@nombre, @apellido, @correo, @usuario, SHA2(@contrasena, 256))";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool IniciarSesion(string usuario, string contrasena, out int usuarioId)
        {
            usuarioId = -1;
            try
            {
                connection.Open();
                string query = "SELECT id FROM usuarios WHERE usuario = @usuario AND contrasena = SHA2(@contrasena, 256)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);

                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    usuarioId = Convert.ToInt32(result);
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
