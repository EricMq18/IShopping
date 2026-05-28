namespace IShopping.View
{
    partial class FormCriacaoCompra
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblNomeCompra;
        private System.Windows.Forms.TextBox txtNomeCompra;
        private System.Windows.Forms.GroupBox grpAdicionarArtigo;
        private System.Windows.Forms.Label lblTipoArtigo;
        private System.Windows.Forms.ComboBox cmbTipoArtigo;
        private System.Windows.Forms.Label lblArtigo;
        private System.Windows.Forms.ComboBox cmbArtigo;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.NumericUpDown numQuantidadePrevista;
        private System.Windows.Forms.Button btnAdicionarItem;
        private System.Windows.Forms.DataGridView dgvItensPlaneados;
        private System.Windows.Forms.Button btnGuardarCompra;
        private System.Windows.Forms.Button btnRemoverItem;
        private System.Windows.Forms.Button btnAtualizarItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblNomeCompra = new System.Windows.Forms.Label();
            this.txtNomeCompra = new System.Windows.Forms.TextBox();
            this.grpAdicionarArtigo = new System.Windows.Forms.GroupBox();
            this.btnAdicionarItem = new System.Windows.Forms.Button();
            this.numQuantidadePrevista = new System.Windows.Forms.NumericUpDown();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.cmbArtigo = new System.Windows.Forms.ComboBox();
            this.lblArtigo = new System.Windows.Forms.Label();
            this.cmbTipoArtigo = new System.Windows.Forms.ComboBox();
            this.lblTipoArtigo = new System.Windows.Forms.Label();
            this.dgvItensPlaneados = new System.Windows.Forms.DataGridView();
            this.btnGuardarCompra = new System.Windows.Forms.Button();
            this.btnRemoverItem = new System.Windows.Forms.Button();
            this.btnAtualizarItem = new System.Windows.Forms.Button();
            this.grpAdicionarArtigo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidadePrevista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensPlaneados)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNomeCompra
            // 
            this.lblNomeCompra.AutoSize = true;
            this.lblNomeCompra.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblNomeCompra.Location = new System.Drawing.Point(15, 20);
            this.lblNomeCompra.Name = "lblNomeCompra";
            this.lblNomeCompra.Size = new System.Drawing.Size(185, 18);
            this.lblNomeCompra.TabIndex = 0;
            this.lblNomeCompra.Text = "Nome da Lista de Compras:";
            // 
            // txtNomeCompra
            // 
            this.txtNomeCompra.Font = new System.Drawing.Font("Arial", 11F);
            this.txtNomeCompra.Location = new System.Drawing.Point(210, 17);
            this.txtNomeCompra.Name = "txtNomeCompra";
            this.txtNomeCompra.Size = new System.Drawing.Size(560, 24);
            this.txtNomeCompra.TabIndex = 1;
            // 
            // grpAdicionarArtigo
            // 
            this.grpAdicionarArtigo.Controls.Add(this.btnAdicionarItem);
            this.grpAdicionarArtigo.Controls.Add(this.numQuantidadePrevista);
            this.grpAdicionarArtigo.Controls.Add(this.lblQuantidade);
            this.grpAdicionarArtigo.Controls.Add(this.cmbArtigo);
            this.grpAdicionarArtigo.Controls.Add(this.lblArtigo);
            this.grpAdicionarArtigo.Controls.Add(this.cmbTipoArtigo);
            this.grpAdicionarArtigo.Controls.Add(this.lblTipoArtigo);
            this.grpAdicionarArtigo.Location = new System.Drawing.Point(15, 60);
            this.grpAdicionarArtigo.Name = "grpAdicionarArtigo";
            this.grpAdicionarArtigo.Size = new System.Drawing.Size(755, 100);
            this.grpAdicionarArtigo.TabIndex = 2;
            this.grpAdicionarArtigo.TabStop = false;
            this.grpAdicionarArtigo.Text = "Adicionar Artigo ao Planeamento";
            // 
            // btnAdicionarItem
            // 
            this.btnAdicionarItem.Location = new System.Drawing.Point(655, 30);
            this.btnAdicionarItem.Name = "btnAdicionarItem";
            this.btnAdicionarItem.Size = new System.Drawing.Size(85, 25);
            this.btnAdicionarItem.TabIndex = 6;
            this.btnAdicionarItem.Text = "Adicionar";
            this.btnAdicionarItem.UseVisualStyleBackColor = true;
            this.btnAdicionarItem.Click += new System.EventHandler(this.BtnAdicionarItem_Click);
            // 
            // numQuantidadePrevista
            // 
            this.numQuantidadePrevista.Location = new System.Drawing.Point(580, 33);
            this.numQuantidadePrevista.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantidadePrevista.Name = "numQuantidadePrevista";
            this.numQuantidadePrevista.Size = new System.Drawing.Size(60, 20);
            this.numQuantidadePrevista.TabIndex = 5;
            this.numQuantidadePrevista.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(540, 35);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(30, 13);
            this.lblQuantidade.TabIndex = 4;
            this.lblQuantidade.Text = "Qtd.:";
            // 
            // cmbArtigo
            // 
            this.cmbArtigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArtigo.FormattingEnabled = true;
            this.cmbArtigo.Location = new System.Drawing.Point(320, 32);
            this.cmbArtigo.Name = "cmbArtigo";
            this.cmbArtigo.Size = new System.Drawing.Size(200, 21);
            this.cmbArtigo.TabIndex = 3;
            // 
            // lblArtigo
            // 
            this.lblArtigo.AutoSize = true;
            this.lblArtigo.Location = new System.Drawing.Point(275, 35);
            this.lblArtigo.Name = "lblArtigo";
            this.lblArtigo.Size = new System.Drawing.Size(37, 13);
            this.lblArtigo.TabIndex = 2;
            this.lblArtigo.Text = "Artigo:";
            // 
            // cmbTipoArtigo
            // 
            this.cmbTipoArtigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoArtigo.FormattingEnabled = true;
            this.cmbTipoArtigo.Location = new System.Drawing.Point(75, 32);
            this.cmbTipoArtigo.Name = "cmbTipoArtigo";
            this.cmbTipoArtigo.Size = new System.Drawing.Size(180, 21);
            this.cmbTipoArtigo.TabIndex = 1;
            this.cmbTipoArtigo.SelectedIndexChanged += new System.EventHandler(this.CmbTipoArtigo_SelectedIndexChanged);
            // 
            // lblTipoArtigo
            // 
            this.lblTipoArtigo.AutoSize = true;
            this.lblTipoArtigo.Location = new System.Drawing.Point(15, 35);
            this.lblTipoArtigo.Name = "lblTipoArtigo";
            this.lblTipoArtigo.Size = new System.Drawing.Size(55, 13);
            this.lblTipoArtigo.TabIndex = 0;
            this.lblTipoArtigo.Text = "Categoria:";
            // 
            // dgvItensPlaneados
            // 
            this.dgvItensPlaneados.AllowUserToAddRows = false;
            this.dgvItensPlaneados.AllowUserToDeleteRows = false;
            this.dgvItensPlaneados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItensPlaneados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItensPlaneados.Location = new System.Drawing.Point(15, 180);
            this.dgvItensPlaneados.MultiSelect = false;
            this.dgvItensPlaneados.Name = "dgvItensPlaneados";
            this.dgvItensPlaneados.ReadOnly = true;
            this.dgvItensPlaneados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItensPlaneados.Size = new System.Drawing.Size(755, 230);
            this.dgvItensPlaneados.TabIndex = 3;
            this.dgvItensPlaneados.SelectionChanged += new System.EventHandler(this.DgvItensPlaneados_SelectionChanged);
            // 
            // btnGuardarCompra
            // 
            this.btnGuardarCompra.BackColor = System.Drawing.Color.LightGreen;
            this.btnGuardarCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCompra.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarCompra.Location = new System.Drawing.Point(620, 425);
            this.btnGuardarCompra.Name = "btnGuardarCompra";
            this.btnGuardarCompra.Size = new System.Drawing.Size(150, 40);
            this.btnGuardarCompra.TabIndex = 4;
            this.btnGuardarCompra.Text = "Guardar Lista";
            this.btnGuardarCompra.UseVisualStyleBackColor = false;
            this.btnGuardarCompra.Click += new System.EventHandler(this.BtnGuardarCompra_Click);
            // 
            // btnRemoverItem
            // 
            this.btnRemoverItem.BackColor = System.Drawing.Color.LightCoral;
            this.btnRemoverItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoverItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnRemoverItem.Location = new System.Drawing.Point(15, 425);
            this.btnRemoverItem.Name = "btnRemoverItem";
            this.btnRemoverItem.Size = new System.Drawing.Size(160, 40);
            this.btnRemoverItem.TabIndex = 5;
            this.btnRemoverItem.Text = "Remover Selecionado";
            this.btnRemoverItem.UseVisualStyleBackColor = false;
            this.btnRemoverItem.Click += new System.EventHandler(this.BtnRemoverItem_Click);
            // 
            // btnAtualizarItem
            // 
            this.btnAtualizarItem.BackColor = System.Drawing.Color.Khaki;
            this.btnAtualizarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizarItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnAtualizarItem.Location = new System.Drawing.Point(185, 425);
            this.btnAtualizarItem.Name = "btnAtualizarItem";
            this.btnAtualizarItem.Size = new System.Drawing.Size(160, 40);
            this.btnAtualizarItem.TabIndex = 7;
            this.btnAtualizarItem.Text = "Atualizar Selecionado";
            this.btnAtualizarItem.UseVisualStyleBackColor = false;
            this.btnAtualizarItem.Click += new System.EventHandler(this.BtnAtualizarItem_Click);
            // 
            // FormCriacaoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 480);
            this.Controls.Add(this.btnAtualizarItem);
            this.Controls.Add(this.btnRemoverItem);
            this.Controls.Add(this.btnGuardarCompra);
            this.Controls.Add(this.dgvItensPlaneados);
            this.Controls.Add(this.grpAdicionarArtigo);
            this.Controls.Add(this.txtNomeCompra);
            this.Controls.Add(this.lblNomeCompra);
            this.Name = "FormCriacaoCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iShopping - Criação/Alteração de Planeamento";
            this.Load += new System.EventHandler(this.FormCriacaoCompra_Load);
            this.grpAdicionarArtigo.ResumeLayout(false);
            this.grpAdicionarArtigo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidadePrevista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensPlaneados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}