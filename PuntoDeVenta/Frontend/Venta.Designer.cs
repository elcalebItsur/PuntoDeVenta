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
            this.btnRealizarVenta = new System.Windows.Forms.Button();
            this.txtEmpleadoId = new System.Windows.Forms.TextBox();
            this.txtProductoId = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRealizarVenta
            // 
            this.btnRealizarVenta.Location = new System.Drawing.Point(332, 417);
            this.btnRealizarVenta.Name = "btnRealizarVenta";
            this.btnRealizarVenta.Size = new System.Drawing.Size(179, 55);
            this.btnRealizarVenta.TabIndex = 0;
            this.btnRealizarVenta.Text = "RealizarVenta";
            this.btnRealizarVenta.UseVisualStyleBackColor = true;
            this.btnRealizarVenta.Click += new System.EventHandler(this.btnRealizarVenta_Click);
            // 
            // txtEmpleadoId
            // 
            this.txtEmpleadoId.Location = new System.Drawing.Point(180, 349);
            this.txtEmpleadoId.Name = "txtEmpleadoId";
            this.txtEmpleadoId.Size = new System.Drawing.Size(135, 26);
            this.txtEmpleadoId.TabIndex = 1;
            // 
            // txtProductoId
            // 
            this.txtProductoId.Location = new System.Drawing.Point(364, 349);
            this.txtProductoId.Name = "txtProductoId";
            this.txtProductoId.Size = new System.Drawing.Size(133, 26);
            this.txtProductoId.TabIndex = 2;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(545, 348);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(136, 26);
            this.txtCantidad.TabIndex = 3;
            // 
            // Venta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 504);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtProductoId);
            this.Controls.Add(this.txtEmpleadoId);
            this.Controls.Add(this.btnRealizarVenta);
            this.Name = "Venta";
            this.Text = "Venta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRealizarVenta;
        private System.Windows.Forms.TextBox txtEmpleadoId;
        private System.Windows.Forms.TextBox txtProductoId;
        private System.Windows.Forms.TextBox txtCantidad;
    }
}