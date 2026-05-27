namespace IShopping.View
{
    partial class FormPlaneamentoCompras
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Declaração dos controlos
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.Button btnNovaCompra;
        private System.Windows.Forms.Button btnEditarCompra;

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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.btnNovaCompra = new System.Windows.Forms.Button();
            this.btnEditarCompra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(15, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(342, 22);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Planeamento de Listas de Compras";
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Arial", 10F);
            this.lblFiltro.Location = new System.Drawing.Point(520, 24);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(122, 16);
            this.lblFiltro.TabIndex = 1;
            this.lblFiltro.Text = "Filtrar por Estado:";
            // 
            // cmbFiltroEstado
            // 
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbFiltroEstado.FormattingEnabled = true;
            this.cmbFiltroEstado.Items.AddRange(new object[] {
            "Todas",
            "Abertas",
            "Fechadas"});
            this.cmbFiltroEstado.Location = new System.Drawing.Point(645, 21);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(130, 24);
            this.cmbFiltroEstado.TabIndex = 2;
            this.cmbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroEstado_SelectedIndexChanged);
            // 
            // dgvCompras
            // 
            this.dgvCompras.AllowUserToAddRows = false;
            this.dgvCompras.AllowUserToDeleteRows = false;
            this.dgvCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompras.Location = new System.Drawing.Point(20, 65);
            this.dgvCompras.MultiSelect = false;
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.ReadOnly = true;
            this.dgvCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompras.Size = new System.Drawing.Size(755, 330);
            this.dgvCompras.TabIndex = 3;
            // 
            // btnNovaCompra
            // 
            this.btnNovaCompra.BackColor = System.Drawing.Color.LightGreen;
            this.btnNovaCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovaCompra.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnNovaCompra.Location = new System.Drawing.Point(20, 410);
            this.btnNovaCompra.Name = "btnNovaCompra";
            this.btnNovaCompra.Size = new System.Drawing.Size(180, 40);
            this.btnNovaCompra.TabIndex = 4;
            this.btnNovaCompra.Text = "+ Criar Nova Lista";
            this.btnNovaCompra.UseVisualStyleBackColor = false;
            this.btnNovaCompra.Click += new System.EventHandler(this.BtnNovaCompra_Click);
            // 
            // btnEditarCompra
            // 
            this.btnEditarCompra.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnEditarCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarCompra.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditarCompra.Location = new System.Drawing.Point(595, 410);
            this.btnEditarCompra.Name = "btnEditarCompra";
            this.btnEditarCompra.Size = new System.Drawing.Size(180, 40);
            this.btnEditarCompra.TabIndex = 5;
            this.btnEditarCompra.Text = "Ver / Editar Lista";
            this.btnEditarCompra.UseVisualStyleBackColor = false;
            this.btnEditarCompra.Click += new System.EventHandler(this.BtnEditarCompra_Click);
            // 
            // FormPlaneamentoCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 470);
            this.Controls.Add(this.btnEditarCompra);
            this.Controls.Add(this.btnNovaCompra);
            this.Controls.Add(this.dgvCompras);
            this.Controls.Add(this.cmbFiltroEstado);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormPlaneamentoCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iShopping - Planeamento de Compras";
            this.Load += new System.EventHandler(this.FormPlaneamentoCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}