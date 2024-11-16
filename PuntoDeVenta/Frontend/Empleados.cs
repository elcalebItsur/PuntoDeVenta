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
            string departamento = txtdepartamento.Text;
            string telefono = txttelefono.Text;


            if (string.IsNullOrWhiteSpace(Id) || string.IsNullOrWhiteSpace(clave) ||
                string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(departamento) || string.IsNullOrWhiteSpace(telefono)
                )
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }


            // Verificar si el empleado ya existe
            if (empleados.ExisteEmpleado(Id))
            {
                MessageBox.Show("Ya existe un Empleado con el mismo Id.");
                LimpiarCampos();
                return;
            }

            try
            {
                empleados.RegistrarEmpleado(Id, clave, nombre, apellido, departamento, telefono);
                MessageBox.Show("Empleado registrado correctamente.");
                LimpiarCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el empleado: " + ex.Message);
            }




        }

        private void LimpiarCampos()
        {
            txtid.Clear();
            txtclave.Clear();
            txtnombre.Clear();
            txtapellido.Clear();
            txtdepartamento.Clear();
            txttelefono.Clear();


        }

        private void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            EmpleadoDAO empleados = new EmpleadoDAO();
            string Id = txtid.Text;
            string clave = txtclave.Text;
            string nombre = txtnombre.Text;
            string apellido = txtapellido.Text;
            string departamento = txtdepartamento.Text;
            string telefono = txttelefono.Text;


            if (string.IsNullOrWhiteSpace(Id) || string.IsNullOrWhiteSpace(clave) ||
                string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(departamento) || string.IsNullOrWhiteSpace(telefono)
                )
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }


            // Verificar si el empleado ya existe
            if (empleados.ExisteEmpleado(Id))
            {
                MessageBox.Show("Ya existe un Empleado con el mismo Id.");
                LimpiarCampos();
                return;
            }

            try
            {
                empleados.RegistrarEmpleado(Id, clave, nombre, apellido, departamento, telefono);
                MessageBox.Show("Empleado registrado correctamente.");
                LimpiarCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el empleado: " + ex.Message);
            }
        }

        private void btnMostrarEmpleados_Click(object sender, EventArgs e)
        {
            EmpleadoDAO empleados = new EmpleadoDAO();
            empleados.MostarEmpleados(dataGridDatosE);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void brnLimpiar_Click(object sender, EventArgs e)
        {
            dataGridDatosE.DataSource = null;
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            
        }

        

        private void txtCodigoBarrasBorrar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminarE_Click(object sender, EventArgs e)
        {
            EmpleadoDAO empleados = new EmpleadoDAO();
            string Id = textid.Text;

            if (string.IsNullOrWhiteSpace(Id))
            {
                MessageBox.Show("Por favor, ingrese el Id del empleado que desea eliminar.");
                return;
            }

            // Verificar si el empleado existe
            if (!empleados.ExisteEmpleado(Id))
            {
                MessageBox.Show("No se encontró ningún empleado con el Id proporcionado.");
                return;
            }

            try
            {
                // Eliminar el empleado
                bool eliminado = empleados.EliminarEmpleado(Id);
                if (eliminado)
                {
                    MessageBox.Show("Empleado eliminado correctamente.");
                    LimpiarCampos2();

                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el empleado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el empleado: " + ex.Message);
            }

        }
        private void LimpiarCampos2()
        {
            textid.Clear();
        }

        private void btnModificarTelefono_Click(object sender, EventArgs e)
        {
            EmpleadoDAO empleados = new EmpleadoDAO();
            string Id = textId_emp.Text;
            string nuevoTelefono = txtNuevo_telefono.Text;

            if (string.IsNullOrWhiteSpace(Id) || string.IsNullOrWhiteSpace(nuevoTelefono))
            {
                MessageBox.Show("Por favor, ingrese el Id del empleado y el nuevo teléfono.");
                return;
            }

            // Verificar si el empleado existe
            if (!empleados.ExisteEmpleado(Id))
            {
                MessageBox.Show("No se encontró ningún empleado con el Id proporcionado.");
                return;
            }

            try
            {
                // Modificar el teléfono del empleado
                bool modificado = empleados.ModificarTelefonoEmpleado(Id, nuevoTelefono);
                if (modificado)
                {
                    MessageBox.Show("Teléfono del empleado modificado correctamente.");
                    LimpiarCampos();
                    // Actualizar la lista de empleados en el DataGridView
                    empleados.MostarEmpleados(dataGridDatosE);
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el teléfono del empleado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el teléfono del empleado: " + ex.Message);
            }
        }













        

    }
}