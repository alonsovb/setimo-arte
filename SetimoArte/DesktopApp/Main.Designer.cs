namespace DesktopApp
{
    partial class Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BRegistrarVenta = new System.Windows.Forms.Button();
            this.BRegistrarAlquiler = new System.Windows.Forms.Button();
            this.GVPelículas = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Consultar = new System.Windows.Forms.Button();
            this.TBCódigo = new System.Windows.Forms.TextBox();
            this.TBNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Género = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DVD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlueRay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HDDVD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVPelículas)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.BRegistrarVenta);
            this.panel1.Controls.Add(this.BRegistrarAlquiler);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 429);
            this.panel1.TabIndex = 0;
            // 
            // BRegistrarVenta
            // 
            this.BRegistrarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(183)))), ((int)(((byte)(186)))));
            this.BRegistrarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BRegistrarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BRegistrarVenta.ForeColor = System.Drawing.Color.White;
            this.BRegistrarVenta.Location = new System.Drawing.Point(12, 41);
            this.BRegistrarVenta.Name = "BRegistrarVenta";
            this.BRegistrarVenta.Size = new System.Drawing.Size(188, 23);
            this.BRegistrarVenta.TabIndex = 2;
            this.BRegistrarVenta.Text = "Registrar Venta";
            this.BRegistrarVenta.UseVisualStyleBackColor = false;
            this.BRegistrarVenta.Click += new System.EventHandler(this.BRegistrarVenta_Click);
            // 
            // BRegistrarAlquiler
            // 
            this.BRegistrarAlquiler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(183)))), ((int)(((byte)(186)))));
            this.BRegistrarAlquiler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BRegistrarAlquiler.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BRegistrarAlquiler.ForeColor = System.Drawing.Color.White;
            this.BRegistrarAlquiler.Location = new System.Drawing.Point(12, 12);
            this.BRegistrarAlquiler.Name = "BRegistrarAlquiler";
            this.BRegistrarAlquiler.Size = new System.Drawing.Size(188, 23);
            this.BRegistrarAlquiler.TabIndex = 0;
            this.BRegistrarAlquiler.Text = "Registrar Alquiler";
            this.BRegistrarAlquiler.UseVisualStyleBackColor = false;
            this.BRegistrarAlquiler.Click += new System.EventHandler(this.BRegistrarAlquiler_Click);
            // 
            // GVPelículas
            // 
            this.GVPelículas.AllowUserToAddRows = false;
            this.GVPelículas.AllowUserToDeleteRows = false;
            this.GVPelículas.AllowUserToOrderColumns = true;
            this.GVPelículas.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GVPelículas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GVPelículas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVPelículas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nombre,
            this.Género,
            this.DVD,
            this.BlueRay,
            this.HDDVD});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GVPelículas.DefaultCellStyle = dataGridViewCellStyle2;
            this.GVPelículas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GVPelículas.Location = new System.Drawing.Point(0, 100);
            this.GVPelículas.Name = "GVPelículas";
            this.GVPelículas.ReadOnly = true;
            this.GVPelículas.Size = new System.Drawing.Size(518, 329);
            this.GVPelículas.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.GVPelículas);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(206, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(518, 429);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Consultar);
            this.panel3.Controls.Add(this.TBCódigo);
            this.panel3.Controls.Add(this.TBNombre);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(518, 100);
            this.panel3.TabIndex = 2;
            // 
            // Consultar
            // 
            this.Consultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(183)))), ((int)(((byte)(186)))));
            this.Consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Consultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Consultar.ForeColor = System.Drawing.Color.White;
            this.Consultar.Location = new System.Drawing.Point(389, 17);
            this.Consultar.Name = "Consultar";
            this.Consultar.Size = new System.Drawing.Size(98, 23);
            this.Consultar.TabIndex = 11;
            this.Consultar.Text = "Consultar";
            this.Consultar.UseVisualStyleBackColor = false;
            this.Consultar.Click += new System.EventHandler(this.Consultar_Click);
            // 
            // TBCódigo
            // 
            this.TBCódigo.Location = new System.Drawing.Point(135, 19);
            this.TBCódigo.Name = "TBCódigo";
            this.TBCódigo.Size = new System.Drawing.Size(100, 20);
            this.TBCódigo.TabIndex = 7;
            // 
            // TBNombre
            // 
            this.TBNombre.Location = new System.Drawing.Point(135, 45);
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(100, 20);
            this.TBNombre.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombre de la Película";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Código de la Película";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "id_peliculas";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Género
            // 
            this.Género.DataPropertyName = "nombre1";
            this.Género.HeaderText = "Género";
            this.Género.Name = "Género";
            this.Género.ReadOnly = true;
            // 
            // DVD
            // 
            this.DVD.DataPropertyName = "inventario_dvd";
            this.DVD.HeaderText = "DVD";
            this.DVD.Name = "DVD";
            this.DVD.ReadOnly = true;
            // 
            // BlueRay
            // 
            this.BlueRay.DataPropertyName = "inventario_blueray";
            this.BlueRay.HeaderText = "Blue Ray";
            this.BlueRay.Name = "BlueRay";
            this.BlueRay.ReadOnly = true;
            // 
            // HDDVD
            // 
            this.HDDVD.DataPropertyName = "inventario_hddvd";
            this.HDDVD.HeaderText = "HD DVD";
            this.HDDVD.Name = "HDDVD";
            this.HDDVD.ReadOnly = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(724, 429);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GVPelículas)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView GVPelículas;
        private System.Windows.Forms.Button BRegistrarAlquiler;
        private System.Windows.Forms.Button BRegistrarVenta;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button Consultar;
        private System.Windows.Forms.TextBox TBCódigo;
        private System.Windows.Forms.TextBox TBNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Género;
        private System.Windows.Forms.DataGridViewTextBoxColumn DVD;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlueRay;
        private System.Windows.Forms.DataGridViewTextBoxColumn HDDVD;
    }
}

