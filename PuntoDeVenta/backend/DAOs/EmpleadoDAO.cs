﻿using MySql.Data.MySqlClient;
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
    internal class EmpleadoDAO
    {
        private MySqlConnection connection;

        public EmpleadoDAO()
        {

            string connectionString = "Server=proyectobh.mysql.database.azure.com;Database=PuntoDeVenta;Uid=ProyectoU4;Pwd=SQL55H7#;";
            connection = new MySqlConnection(connectionString);
        }
        public bool RegistrarEmpleado(string Id, string Clave, string nombre, string apellido, string departamento, string Telefono)
        {
            try
            {
                connection.Open();

                string query = "INSERT INTO empleados (IdEmpleado, Clave_empleado, Nombre, Apellido, Departamento, telefono) " +
                               "VALUES (@Id, SHA2(@Clave, 256), @nombre, @apellido, @departamento, @Telefono)";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Clave", Clave); // Clave en texto plano, será encriptada con SHA2
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@departamento", departamento);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);

                int result = cmd.ExecuteNonQuery();
                return result > 0; // Retorna true si se insertó el registro
            }
            finally
            {
                connection.Close();
            }
        }

        public void MostarEmpleados(DataGridView dataGridView)
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM empleados";
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



        public bool ExisteEmpleado(string Id)
        {
            try
            {
                // Asegúrate de que 'connection' esté inicializada correctamente
                connection.Open();

                string query = "SELECT COUNT(*) FROM empleados WHERE Idempleado ="+"@Id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", Id);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                // Maneja la excepción según sea necesario, por ejemplo, logueándola
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }



        // Método para eliminar un empleado
        public bool EliminarEmpleado(string Id)
        {
            try
            {
                connection.Open();

                // Consulta para eliminar el empleado
                string query = "DELETE FROM empleados WHERE Idempleado =" + "@Id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", Id);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                // Manejar la excepción, por ejemplo, mostrar un mensaje de error
                MessageBox.Show("Error al eliminar el empleado: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }




        // Método para modificar el teléfono de un empleado
        public bool ModificarTelefonoEmpleado(string Id, string Telefono)
        {
            try
            {
                connection.Open();

                // Consulta para actualizar el teléfono del empleado
                string query = "UPDATE empleados SET telefono = @nuevoTelefono"+" WHERE IdEmpleado ="+" @Id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@nuevoTelefono", Telefono);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                // Manejar la excepción, por ejemplo, mostrando un mensaje de error
                MessageBox.Show("Error al modificar el teléfono del empleado: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }


        public List<KeyValuePair<string, string>> ObtenerEmpleados()
        {
            try
            {
                connection.Open();
                string query = "SELECT IdEmpleado, Nombre FROM empleados";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                var empleados = new List<KeyValuePair<string, string>>();
                while (reader.Read())
                {
                    empleados.Add(new KeyValuePair<string, string>(
                        reader.GetString("IdEmpleado"),
                        reader.GetString("Nombre")
                    ));
                }
                return empleados;
            }
            finally
            {
                connection.Close();
            }
        }



    }
}




