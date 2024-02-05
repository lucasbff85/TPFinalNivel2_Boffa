namespace WindowsFormsApp1
{
    partial class frmArticulosDesactivados
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
            this.dgvSuspendidos = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtPrecioNuevo = new System.Windows.Forms.TextBox();
            this.lblNuevoPrecio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbxSuspendidos = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuspendidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSuspendidos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSuspendidos
            // 
            this.dgvSuspendidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuspendidos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSuspendidos.Location = new System.Drawing.Point(34, 106);
            this.dgvSuspendidos.Name = "dgvSuspendidos";
            this.dgvSuspendidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSuspendidos.Size = new System.Drawing.Size(646, 314);
            this.dgvSuspendidos.TabIndex = 0;
            this.dgvSuspendidos.SelectionChanged += new System.EventHandler(this.dgvSuspendidos_SelectionChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(213, 582);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(110, 40);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(408, 582);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 40);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtPrecioNuevo
            // 
            this.txtPrecioNuevo.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioNuevo.Location = new System.Drawing.Point(368, 512);
            this.txtPrecioNuevo.Name = "txtPrecioNuevo";
            this.txtPrecioNuevo.Size = new System.Drawing.Size(150, 22);
            this.txtPrecioNuevo.TabIndex = 3;
            // 
            // lblNuevoPrecio
            // 
            this.lblNuevoPrecio.AutoSize = true;
            this.lblNuevoPrecio.Font = new System.Drawing.Font("Javanese Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevoPrecio.Location = new System.Drawing.Point(180, 508);
            this.lblNuevoPrecio.Name = "lblNuevoPrecio";
            this.lblNuevoPrecio.Size = new System.Drawing.Size(182, 36);
            this.lblNuevoPrecio.TabIndex = 4;
            this.lblNuevoPrecio.Text = "Ingrese el precio nuevo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Javanese Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(678, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "Lista de artículos fuera de ventas. Seleccione el que desea reactivar y coloque u" +
    "n nuevo precio.";
            // 
            // pbxSuspendidos
            // 
            this.pbxSuspendidos.Location = new System.Drawing.Point(710, 97);
            this.pbxSuspendidos.Name = "pbxSuspendidos";
            this.pbxSuspendidos.Size = new System.Drawing.Size(482, 504);
            this.pbxSuspendidos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxSuspendidos.TabIndex = 6;
            this.pbxSuspendidos.TabStop = false;
            // 
            // frmArticulosDesactivados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1429, 898);
            this.Controls.Add(this.pbxSuspendidos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNuevoPrecio);
            this.Controls.Add(this.txtPrecioNuevo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvSuspendidos);
            this.Name = "frmArticulosDesactivados";
            this.Text = "frmArticulosDesactivados";
            this.Load += new System.EventHandler(this.frmArticulosDesactivados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuspendidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSuspendidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSuspendidos;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtPrecioNuevo;
        private System.Windows.Forms.Label lblNuevoPrecio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbxSuspendidos;
    }
}