using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta.Front_end
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // extrae el texto de cada caja
            string nombreUsuario = User.Text;
            string contrasena = Pass.Text;

            // Verifica si el usuario existe 
            if (ValidarUsuario(nombreUsuario, contrasena))
            {
                
                Ventas formularioVentas = new Ventas();
                formularioVentas.Show();
                this.Close();
            }
            else
            {
                
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        private bool ValidarUsuario(string nombreUsuario, string contrasena)
        {
            bool usuarioExiste = false;

            //  conexión
            string connectionString = "Server=127.0.0.1;Database=PuntoDeVenta;User ID=root;Password=root;";


            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    // verifica al user en workbeanch
                    string query = "SELECT COUNT(1) FROM Usuarios WHERE NombreUsuario = @NombreUsuario AND Contraseña = @Contrasena";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        // Agrega parámetros para evitar inyecciones SQL
                        comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                        comando.Parameters.AddWithValue("@Contrasena", contrasena);

                        // onsulta y verifica que se retorna algo
                        int count = Convert.ToInt32(comando.ExecuteScalar());
                        usuarioExiste = count > 0;
                    }
                }
                catch (Exception ex)
                {
                    this.Close();
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
                    
                }
            }

            return usuarioExiste;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
