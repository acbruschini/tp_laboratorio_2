namespace Formular
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_Cuadros = new System.Windows.Forms.ListBox();
            this.btnActualizarDbCuadros = new System.Windows.Forms.Button();
            this.btnAgregarCuadro = new System.Windows.Forms.Button();
            this.btn_QuitarCuadro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cuadros";
            // 
            // listBox_Cuadros
            // 
            this.listBox_Cuadros.FormattingEnabled = true;
            this.listBox_Cuadros.Location = new System.Drawing.Point(218, 55);
            this.listBox_Cuadros.Name = "listBox_Cuadros";
            this.listBox_Cuadros.Size = new System.Drawing.Size(507, 303);
            this.listBox_Cuadros.TabIndex = 1;
            // 
            // btnActualizarDbCuadros
            // 
            this.btnActualizarDbCuadros.Location = new System.Drawing.Point(218, 364);
            this.btnActualizarDbCuadros.Name = "btnActualizarDbCuadros";
            this.btnActualizarDbCuadros.Size = new System.Drawing.Size(507, 23);
            this.btnActualizarDbCuadros.TabIndex = 2;
            this.btnActualizarDbCuadros.Text = "Actualizar DB";
            this.btnActualizarDbCuadros.UseVisualStyleBackColor = true;
            this.btnActualizarDbCuadros.Click += new System.EventHandler(this.btnActualizarDbCuadros_Click);
            // 
            // btnAgregarCuadro
            // 
            this.btnAgregarCuadro.Location = new System.Drawing.Point(33, 84);
            this.btnAgregarCuadro.Name = "btnAgregarCuadro";
            this.btnAgregarCuadro.Size = new System.Drawing.Size(179, 23);
            this.btnAgregarCuadro.TabIndex = 3;
            this.btnAgregarCuadro.Text = "Agregar Cuadro";
            this.btnAgregarCuadro.UseVisualStyleBackColor = true;
            this.btnAgregarCuadro.Click += new System.EventHandler(this.btnAgregarCuadro_Click);
            // 
            // btn_QuitarCuadro
            // 
            this.btn_QuitarCuadro.Location = new System.Drawing.Point(33, 55);
            this.btn_QuitarCuadro.Name = "btn_QuitarCuadro";
            this.btn_QuitarCuadro.Size = new System.Drawing.Size(179, 23);
            this.btn_QuitarCuadro.TabIndex = 4;
            this.btn_QuitarCuadro.Text = "Quitar Cuadro Seleccionado";
            this.btn_QuitarCuadro.UseVisualStyleBackColor = true;
            this.btn_QuitarCuadro.Click += new System.EventHandler(this.btn_QuitarCuadro_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 412);
            this.Controls.Add(this.btn_QuitarCuadro);
            this.Controls.Add(this.btnAgregarCuadro);
            this.Controls.Add(this.btnActualizarDbCuadros);
            this.Controls.Add(this.listBox_Cuadros);
            this.Controls.Add(this.label1);
            this.Name = "FormPrincipal";
            this.Text = "DB Manager";
            this.Load += new System.EventHandler(this.formPrincipalOnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_Cuadros;
        private System.Windows.Forms.Button btnActualizarDbCuadros;
        private System.Windows.Forms.Button btnAgregarCuadro;
        private System.Windows.Forms.Button btn_QuitarCuadro;
    }
}

