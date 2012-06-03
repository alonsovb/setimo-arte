namespace DesktopApp
{
    partial class Comprar
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
            this.BComprar = new System.Windows.Forms.Button();
            this.TBCódigoCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BCancelar = new System.Windows.Forms.Button();
            this.TBCódigoPelícula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BComprar
            // 
            this.BComprar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(183)))), ((int)(((byte)(186)))));
            this.BComprar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BComprar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BComprar.ForeColor = System.Drawing.Color.White;
            this.BComprar.Location = new System.Drawing.Point(177, 87);
            this.BComprar.Name = "BComprar";
            this.BComprar.Size = new System.Drawing.Size(97, 23);
            this.BComprar.TabIndex = 27;
            this.BComprar.Text = "Comprar";
            this.BComprar.UseVisualStyleBackColor = false;
            this.BComprar.Click += new System.EventHandler(this.BAlquilar_Click);
            // 
            // TBCódigoCliente
            // 
            this.TBCódigoCliente.Location = new System.Drawing.Point(123, 38);
            this.TBCódigoCliente.Name = "TBCódigoCliente";
            this.TBCódigoCliente.Size = new System.Drawing.Size(149, 20);
            this.TBCódigoCliente.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Código del cliente";
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(183)))), ((int)(((byte)(186)))));
            this.BCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancelar.ForeColor = System.Drawing.Color.White;
            this.BCancelar.Location = new System.Drawing.Point(74, 87);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(97, 23);
            this.BCancelar.TabIndex = 24;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = false;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // TBCódigoPelícula
            // 
            this.TBCódigoPelícula.Location = new System.Drawing.Point(123, 12);
            this.TBCódigoPelícula.Name = "TBCódigoPelícula";
            this.TBCódigoPelícula.Size = new System.Drawing.Size(149, 20);
            this.TBCódigoPelícula.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Código de la película";
            // 
            // Comprar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 124);
            this.Controls.Add(this.BComprar);
            this.Controls.Add(this.TBCódigoCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.TBCódigoPelícula);
            this.Controls.Add(this.label1);
            this.Name = "Comprar";
            this.Text = "Comprar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BComprar;
        private System.Windows.Forms.TextBox TBCódigoCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.TextBox TBCódigoPelícula;
        private System.Windows.Forms.Label label1;
    }
}