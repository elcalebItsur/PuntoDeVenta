namespace PuntoDeVenta.Frontend
{
    partial class Empleados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dataGridDatosE = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.btnagregarE = new System.Windows.Forms.Button();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtapellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtclave = new System.Windows.Forms.TextBox();
            this.txtdepartamento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txttelefono = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtventas = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDatosE)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridDatosE
            // 
            this.dataGridDatosE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDatosE.Location = new System.Drawing.Point(337, 65);
            this.dataGridDatosE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridDatosE.Name = "dataGridDatosE";
            this.dataGridDatosE.RowHeadersWidth = 51;
            this.dataGridDatosE.RowTemplate.Height = 24;
            this.dataGridDatosE.Size = new System.Drawing.Size(791, 704);
            this.dataGridDatosE.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1128, 58);
            this.panel1.TabIndex = 16;
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnEmpleados.Location = new System.Drawing.Point(54, 700);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(207, 43);
            this.btnEmpleados.TabIndex = 17;
            this.btnEmpleados.Text = "Mostrar_Empleados";
            this.btnEmpleados.UseVisualStyleBackColor = false;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // btnagregarE
            // 
            this.btnagregarE.Location = new System.Drawing.Point(54, 634);
            this.btnagregarE.Name = "btnagregarE";
            this.btnagregarE.Size = new System.Drawing.Size(207, 41);
            this.btnagregarE.TabIndex = 18;
            this.btnagregarE.Text = "Agregar_Empleado";
            this.btnagregarE.UseVisualStyleBackColor = true;
            this.btnagregarE.Click += new System.EventHandler(this.btnagregarE_Click);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(8, 123);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(127, 26);
            this.txtid.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Nombre";
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(12, 224);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(123, 26);
            this.txtnombre.TabIndex = 22;
            // 
            // txtapellido
            // 
            this.txtapellido.Location = new System.Drawing.Point(171, 224);
            this.txtapellido.Name = "txtapellido";
            this.txtapellido.Size = new System.Drawing.Size(127, 26);
            this.txtapellido.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Apellido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Clave";
            // 
            // txtclave
            // 
            this.txtclave.Location = new System.Drawing.Point(171, 123);
            this.txtclave.Name = "txtclave";
            this.txtclave.Size = new System.Drawing.Size(127, 26);
            this.txtclave.TabIndex = 26;
            // 
            // txtdepartamento
            // 
            this.txtdepartamento.Location = new System.Drawing.Point(12, 348);
            this.txtdepartamento.Name = "txtdepartamento";
            this.txtdepartamento.Size = new System.Drawing.Size(123, 26);
            this.txtdepartamento.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "Departamento";
            // 
            // txttelefono
            // 
            this.txttelefono.Location = new System.Drawing.Point(171, 348);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(127, 26);
            this.txttelefono.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(167, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "Telefono";
            // 
            // txtventas
            // 
            this.txtventas.Location = new System.Drawing.Point(92, 468);
            this.txtventas.Name = "txtventas";
            this.txtventas.Size = new System.Drawing.Size(123, 26);
            this.txtventas.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(103, 433);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 20);
            this.label7.TabIndex = 32;
            this.label7.Text = "Num_ventas";
            // 
            // Empleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 868);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtventas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txttelefono);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtdepartamento);
            this.Controls.Add(this.txtclave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtapellido);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.btnagregarE);
            this.Controls.Add(this.btnEmpleados);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridDatosE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Empleados";
            this.Text = "Empleados";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDatosE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dataGridDatosE;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.Button btnagregarE;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.TextBox txtapellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtclave;
        private System.Windows.Forms.TextBox txtdepartamento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txttelefono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtventas;
        private System.Windows.Forms.Label label7;
    }
}