namespace PuntoDeVenta.Frontend
{
    partial class Venta
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantidadProducto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCodigoBarrasElimiarProducto = new System.Windows.Forms.TextBox();
            this.btnEliminarProductoSeleccionado = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRealizarVenta = new System.Windows.Forms.Button();
            this.btnAgregarProductos = new System.Windows.Forms.Button();
            this.lblNombreUsuarioCajero = new System.Windows.Forms.Label();
            this.txtCodigo_Barras = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlDescuento = new System.Windows.Forms.Panel();
            this.pnlFinal = new System.Windows.Forms.Panel();
            this.pnlPrecio = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotalSolo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlDescuento.SuspendLayout();
            this.pnlFinal.SuspendLayout();
            this.pnlPrecio.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(170)))), ((int)(((byte)(222)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCantidadProducto);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnCodigoBarrasElimiarProducto);
            this.panel1.Controls.Add(this.btnEliminarProductoSeleccionado);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnRealizarVenta);
            this.panel1.Controls.Add(this.btnAgregarProductos);
            this.panel1.Controls.Add(this.lblNombreUsuarioCajero);
            this.panel1.Controls.Add(this.txtCodigo_Barras);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 640);
            this.panel1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 19);
            this.label3.TabIndex = 20;
            this.label3.Text = "Código de barras:";
            // 
            // txtCantidadProducto
            // 
            this.txtCantidadProducto.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadProducto.Location = new System.Drawing.Point(30, 266);
            this.txtCantidadProducto.Name = "txtCantidadProducto";
            this.txtCantidadProducto.Size = new System.Drawing.Size(188, 32);
            this.txtCantidadProducto.TabIndex = 19;
            this.txtCantidadProducto.TextChanged += new System.EventHandler(this.txtCantidadProducto_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "Cantidad del producto:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(30, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(307, 79);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // btnCodigoBarrasElimiarProducto
            // 
            this.btnCodigoBarrasElimiarProducto.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCodigoBarrasElimiarProducto.Location = new System.Drawing.Point(30, 412);
            this.btnCodigoBarrasElimiarProducto.Name = "btnCodigoBarrasElimiarProducto";
            this.btnCodigoBarrasElimiarProducto.Size = new System.Drawing.Size(188, 32);
            this.btnCodigoBarrasElimiarProducto.TabIndex = 16;
            this.btnCodigoBarrasElimiarProducto.TextChanged += new System.EventHandler(this.btnCodigoBarrasElimiarProducto_TextChanged);
            // 
            // btnEliminarProductoSeleccionado
            // 
            this.btnEliminarProductoSeleccionado.BackColor = System.Drawing.Color.Red;
            this.btnEliminarProductoSeleccionado.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarProductoSeleccionado.Location = new System.Drawing.Point(242, 411);
            this.btnEliminarProductoSeleccionado.Name = "btnEliminarProductoSeleccionado";
            this.btnEliminarProductoSeleccionado.Size = new System.Drawing.Size(95, 32);
            this.btnEliminarProductoSeleccionado.TabIndex = 15;
            this.btnEliminarProductoSeleccionado.Text = "Eliminar";
            this.btnEliminarProductoSeleccionado.UseVisualStyleBackColor = false;
            this.btnEliminarProductoSeleccionado.Click += new System.EventHandler(this.btnEliminarProductoSeleccionado_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 377);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Elija el producto que desee eliminar ";
            // 
            // btnRealizarVenta
            // 
            this.btnRealizarVenta.BackColor = System.Drawing.Color.Lime;
            this.btnRealizarVenta.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRealizarVenta.Location = new System.Drawing.Point(30, 553);
            this.btnRealizarVenta.Name = "btnRealizarVenta";
            this.btnRealizarVenta.Size = new System.Drawing.Size(132, 65);
            this.btnRealizarVenta.TabIndex = 13;
            this.btnRealizarVenta.Text = "Completar Venta";
            this.btnRealizarVenta.UseVisualStyleBackColor = false;
            this.btnRealizarVenta.Click += new System.EventHandler(this.btnRealizarVenta_Click_1);
            // 
            // btnAgregarProductos
            // 
            this.btnAgregarProductos.BackColor = System.Drawing.Color.Lime;
            this.btnAgregarProductos.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProductos.Location = new System.Drawing.Point(242, 266);
            this.btnAgregarProductos.Name = "btnAgregarProductos";
            this.btnAgregarProductos.Size = new System.Drawing.Size(95, 32);
            this.btnAgregarProductos.TabIndex = 12;
            this.btnAgregarProductos.Text = "Agregar";
            this.btnAgregarProductos.UseVisualStyleBackColor = false;
            this.btnAgregarProductos.Click += new System.EventHandler(this.btnAgregarProductos_Click);
            // 
            // lblNombreUsuarioCajero
            // 
            this.lblNombreUsuarioCajero.AutoSize = true;
            this.lblNombreUsuarioCajero.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuarioCajero.Location = new System.Drawing.Point(26, 496);
            this.lblNombreUsuarioCajero.Name = "lblNombreUsuarioCajero";
            this.lblNombreUsuarioCajero.Size = new System.Drawing.Size(74, 21);
            this.lblNombreUsuarioCajero.TabIndex = 4;
            this.lblNombreUsuarioCajero.Text = "Cajero:";
            this.lblNombreUsuarioCajero.Click += new System.EventHandler(this.lblNombreUsuarioCajero_Click);
            // 
            // txtCodigo_Barras
            // 
            this.txtCodigo_Barras.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo_Barras.Location = new System.Drawing.Point(30, 196);
            this.txtCodigo_Barras.Name = "txtCodigo_Barras";
            this.txtCodigo_Barras.Size = new System.Drawing.Size(188, 32);
            this.txtCodigo_Barras.TabIndex = 8;
            this.txtCodigo_Barras.TextChanged += new System.EventHandler(this.txtCodigo_Barras_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(141, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ventas";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(368, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(817, 640);
            this.dataGridView1.TabIndex = 12;
            // 
            // pnlDescuento
            // 
            this.pnlDescuento.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlDescuento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDescuento.Controls.Add(this.txtDescuento);
            this.pnlDescuento.Controls.Add(this.label4);
            this.pnlDescuento.Location = new System.Drawing.Point(59, 47);
            this.pnlDescuento.Name = "pnlDescuento";
            this.pnlDescuento.Size = new System.Drawing.Size(259, 51);
            this.pnlDescuento.TabIndex = 13;
            // 
            // pnlFinal
            // 
            this.pnlFinal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFinal.Controls.Add(this.lblTotalSolo);
            this.pnlFinal.Location = new System.Drawing.Point(634, 8);
            this.pnlFinal.Name = "pnlFinal";
            this.pnlFinal.Size = new System.Drawing.Size(142, 90);
            this.pnlFinal.TabIndex = 14;
            this.pnlFinal.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFinal_Paint);
            // 
            // pnlPrecio
            // 
            this.pnlPrecio.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrecio.Controls.Add(this.txtTotal);
            this.pnlPrecio.Controls.Add(this.txtIVA);
            this.pnlPrecio.Controls.Add(this.txtSubtotal);
            this.pnlPrecio.Controls.Add(this.label7);
            this.pnlPrecio.Controls.Add(this.label6);
            this.pnlPrecio.Controls.Add(this.label5);
            this.pnlPrecio.Location = new System.Drawing.Point(369, 0);
            this.pnlPrecio.Name = "pnlPrecio";
            this.pnlPrecio.Size = new System.Drawing.Size(237, 98);
            this.pnlPrecio.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(205, 553);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 65);
            this.button1.TabIndex = 21;
            this.button1.Text = "Cancelar Venta";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Descuento:";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.Location = new System.Drawing.Point(119, 6);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(119, 28);
            this.txtDescuento.TabIndex = 9;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Subtotal:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(36, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "IVA:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 21);
            this.label7.TabIndex = 7;
            this.label7.Text = "Total:";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubtotal.Location = new System.Drawing.Point(101, 4);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(105, 23);
            this.txtSubtotal.TabIndex = 22;
            this.txtSubtotal.TextChanged += new System.EventHandler(this.txtSubtotal_TextChanged);
            // 
            // txtIVA
            // 
            this.txtIVA.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIVA.Location = new System.Drawing.Point(101, 31);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.ReadOnly = true;
            this.txtIVA.Size = new System.Drawing.Size(105, 23);
            this.txtIVA.TabIndex = 23;
            this.txtIVA.TextChanged += new System.EventHandler(this.txtIVA_TextChanged);
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(101, 63);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(105, 23);
            this.txtTotal.TabIndex = 24;
            this.txtTotal.TextChanged += new System.EventHandler(this.txtTotal_TextChanged);
            // 
            // lblTotalSolo
            // 
            this.lblTotalSolo.AutoSize = true;
            this.lblTotalSolo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTotalSolo.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSolo.Location = new System.Drawing.Point(3, 37);
            this.lblTotalSolo.Name = "lblTotalSolo";
            this.lblTotalSolo.Size = new System.Drawing.Size(20, 22);
            this.lblTotalSolo.TabIndex = 25;
            this.lblTotalSolo.Text = "$";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlPrecio);
            this.panel2.Controls.Add(this.pnlFinal);
            this.panel2.Controls.Add(this.pnlDescuento);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(368, 535);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(817, 105);
            this.panel2.TabIndex = 16;
            // 
            // Venta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 640);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Venta";
            this.Text = "Venta";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlDescuento.ResumeLayout(false);
            this.pnlDescuento.PerformLayout();
            this.pnlFinal.ResumeLayout(false);
            this.pnlFinal.PerformLayout();
            this.pnlPrecio.ResumeLayout(false);
            this.pnlPrecio.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCodigo_Barras;
        private System.Windows.Forms.Label lblNombreUsuarioCajero;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAgregarProductos;
        private System.Windows.Forms.Button btnRealizarVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox btnCodigoBarrasElimiarProducto;
        private System.Windows.Forms.Button btnEliminarProductoSeleccionado;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCantidadProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel pnlDescuento;
        private System.Windows.Forms.Panel pnlFinal;
        private System.Windows.Forms.Panel pnlPrecio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label lblTotalSolo;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.Panel panel2;
    }
}