
namespace BM
{
    partial class frmMenu
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
            this.lblAlto = new System.Windows.Forms.Label();
            this.lblAncho = new System.Windows.Forms.Label();
            this.lblMinas = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.numAlto = new System.Windows.Forms.NumericUpDown();
            this.numAncho = new System.Windows.Forms.NumericUpDown();
            this.numMinas = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numAlto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAncho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAlto
            // 
            this.lblAlto.AutoSize = true;
            this.lblAlto.Location = new System.Drawing.Point(24, 15);
            this.lblAlto.Name = "lblAlto";
            this.lblAlto.Size = new System.Drawing.Size(25, 13);
            this.lblAlto.TabIndex = 0;
            this.lblAlto.Text = "Alto";
            // 
            // lblAncho
            // 
            this.lblAncho.AutoSize = true;
            this.lblAncho.Location = new System.Drawing.Point(11, 41);
            this.lblAncho.Name = "lblAncho";
            this.lblAncho.Size = new System.Drawing.Size(38, 13);
            this.lblAncho.TabIndex = 2;
            this.lblAncho.Text = "Ancho";
            // 
            // lblMinas
            // 
            this.lblMinas.AutoSize = true;
            this.lblMinas.Location = new System.Drawing.Point(14, 67);
            this.lblMinas.Name = "lblMinas";
            this.lblMinas.Size = new System.Drawing.Size(35, 13);
            this.lblMinas.TabIndex = 4;
            this.lblMinas.Text = "Minas";
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(14, 90);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.TabIndex = 6;
            this.btnCrear.Text = "Crear partida";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(95, 90);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // numAlto
            // 
            this.numAlto.Location = new System.Drawing.Point(55, 13);
            this.numAlto.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numAlto.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numAlto.Name = "numAlto";
            this.numAlto.Size = new System.Drawing.Size(100, 20);
            this.numAlto.TabIndex = 8;
            this.numAlto.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numAncho
            // 
            this.numAncho.Location = new System.Drawing.Point(55, 39);
            this.numAncho.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numAncho.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numAncho.Name = "numAncho";
            this.numAncho.Size = new System.Drawing.Size(100, 20);
            this.numAncho.TabIndex = 9;
            this.numAncho.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numMinas
            // 
            this.numMinas.Location = new System.Drawing.Point(55, 65);
            this.numMinas.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numMinas.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numMinas.Name = "numMinas";
            this.numMinas.Size = new System.Drawing.Size(100, 20);
            this.numMinas.TabIndex = 10;
            this.numMinas.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(171, 132);
            this.Controls.Add(this.numMinas);
            this.Controls.Add(this.numAncho);
            this.Controls.Add(this.numAlto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.lblMinas);
            this.Controls.Add(this.lblAncho);
            this.Controls.Add(this.lblAlto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMenu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAlto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAncho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAlto;
        private System.Windows.Forms.Label lblAncho;
        private System.Windows.Forms.Label lblMinas;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.NumericUpDown numAlto;
        private System.Windows.Forms.NumericUpDown numAncho;
        private System.Windows.Forms.NumericUpDown numMinas;
    }
}

