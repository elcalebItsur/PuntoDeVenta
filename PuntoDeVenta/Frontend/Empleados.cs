using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuntoDeVenta.backend;
using PuntoDeVenta.backend.DAOs;
using System.Text.RegularExpressions;

namespace PuntoDeVenta.Frontend
{
    public partial class Empleados : Form
    {
        public Empleados()
        {
            InitializeComponent();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            EmpleadoDAO empleados = new EmpleadoDAO();
            empleados.MostarEmpleados(dataGridDatosE);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnagregarE_Click(object sender, EventArgs e)
        {
            EmpleadoDAO empleados = new EmpleadoDAO();
            string Id = txtid.Text;
            string clave = txtclave.Text;
            string nombre = txtnombre.Text;
            string apellido = txtapellido.Text;
            string departamento= txtdepartamento.Text;
            string telefono = txttelefono.Text;
            

            if (string.IsNullOrWhiteSpace(Id) || string.IsNullOrWhiteSpace(clave) ||
                string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(departamento) || string.IsNullOrWhiteSpace(telefono)
                )
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            

            try
            {
               empleados.RegistrarEmpleado(Id, clave, nombre, apellido, departamento, telefono);
                MessageBox.Show("Empleado registrado correctamente.");
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el empleado: " + ex.Message);
            }




        }
    }
}
