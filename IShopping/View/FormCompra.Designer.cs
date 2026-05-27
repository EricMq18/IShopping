namespace IShopping.View
{
    partial class FormCompra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Declaração de todos os controlos necessários
        private System.Windows.Forms.Label lblNomeCompra;
        private System.Windows.Forms.Label lblOrcamentoDisponivel;
        private System.Windows.Forms.DataGridView dgvItensCompra;

        // Grupo para registar dados de itens planeados
        private System.Windows.Forms.GroupBox grpRegistarItem;
        private System.Windows.Forms.Label lblQtdAdquirida;
        private System.Windows.Forms.NumericUpDown numQtdAdquirida;
        private System.Windows.Forms.Label lblPrecoUnitario;
        private System.Windows.Forms.TextBox txtPrecoUnitario;
        private System.Windows.Forms.Button btnRegistarItem;

        // Grupo para adicionar itens não previstos (impulsos)
        private System.Windows.Forms.GroupBox grpAdicionarExtra;
        private System.Windows.Forms.Label lblTipoArtigoExtra;
        private System.Windows.Forms.ComboBox cmbTipoArtigoExtra;
        private System.Windows.Forms.Label lblArtigoExtra;
        private System.Windows.Forms.ComboBox cmbArtigoExtra;
        private System.Windows.Forms.Label lblQtdExtra;
        private System.Windows.Forms.NumericUpDown numQtdExtra;
        private System.Windows.Forms.Label lblPrecoExtra;
        private System.Windows.Forms.TextBox txtPrecoExtra;
        private System.Windows.Forms.Label lblObservacoes;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.Button btnAdicionarExtra;

        private System.Windows.Forms.Button btnFecharCompra;

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
            this.lblNomeCompra = new System.Windows.Forms.Label();
            this.lblOrcamentoDisponivel = new System.Windows.Forms.Label();
            this.dgvItensCompra = new System.Windows.Forms.DataGridView();
            this.grpRegistarItem = new System.Windows.Forms.GroupBox();
            this.btnRegistarItem = new System.Windows.Forms.Button();
            this.txtPrecoUnitario = new System.Windows.Forms.TextBox();
            this.lblPrecoUnitario = new System.Windows.Forms.Label();
            this.numQtdAdquirida = new System.Windows.Forms.NumericUpDown();
            this.lblQtdAdquirida = new System.Windows.Forms.Label();
            this.grpAdicionarExtra = new System.Windows.Forms.GroupBox();
            this.btnAdicionarExtra = new System.Windows.Forms.Button();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.lblObservacoes = new System.Windows.Forms.Label();
            this.txtPrecoExtra = new System.Windows.Forms.TextBox();
            this.lblPrecoExtra = new System.Windows.Forms.Label();
            this.numQtdExtra = new System.Windows.Forms.NumericUpDown();
            this.lblQtdExtra = new System.Windows.Forms.Label();
            this.cmbArtigoExtra = new System.Windows.Forms.ComboBox();
            this.lblArtigoExtra = new System.Windows.Forms.Label();
            this.cmbTipoArtigoExtra = new System.Windows.Forms.ComboBox();
            this.lblTipoArtigoExtra = new System.Windows.Forms.Label();
            this.btnFecharCompra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensCompra)).BeginInit();
            this.grpRegistarItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdAdquirida)).BeginInit();
            this.grpAdicionarExtra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdExtra)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNomeCompra
            // 
            this.lblNomeCompra.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblNomeCompra.Location = new System.Drawing.Point(12, 15);
            this.lblNomeCompra.Name = "lblNomeCompra";
            this.lblNomeCompra.Size = new System.Drawing.Size(450, 25);
            this.lblNomeCompra.TabIndex = 5;
            this.lblNomeCompra.Text = "A carregar carrinho de compras...";
            // 
            // lblOrcamentoDisponivel
            // 
            this.lblOrcamentoDisponivel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblOrcamentoDisponivel.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblOrcamentoDisponivel.Location = new System.Drawing.Point(520, 15);
            this.lblOrcamentoDisponivel.Name = "lblOrcamentoDisponivel";
            this.lblOrcamentoDisponivel.Size = new System.Drawing.Size(300, 25);
            this.lblOrcamentoDisponivel.TabIndex = 4;
            this.lblOrcamentoDisponivel.Text = "Saldo Disponível: 0.00€";
            this.lblOrcamentoDisponivel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dgvItensCompra
            // 
            this.dgvItensCompra.AllowUserToAddRows = false;
            this.dgvItensCompra.AllowUserToDeleteRows = false;
            this.dgvItensCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItensCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItensCompra.Location = new System.Drawing.Point(15, 50);
            this.dgvItensCompra.MultiSelect = false;
            this.dgvItensCompra.Name = "dgvItensCompra";
            this.dgvItensCompra.ReadOnly = true;
            this.dgvItensCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItensCompra.Size = new System.Drawing.Size(805, 230);
            this.dgvItensCompra.TabIndex = 3;
            // 
            // grpRegistarItem
            // 
            this.grpRegistarItem.Controls.Add(this.btnRegistarItem);
            this.grpRegistarItem.Controls.Add(this.txtPrecoUnitario);
            this.grpRegistarItem.Controls.Add(this.lblPrecoUnitario);
            this.grpRegistarItem.Controls.Add(this.numQtdAdquirida);
            this.grpRegistarItem.Controls.Add(this.lblQtdAdquirida);
            this.grpRegistarItem.Location = new System.Drawing.Point(15, 295);
            this.grpRegistarItem.Name = "grpRegistarItem";
            this.grpRegistarItem.Size = new System.Drawing.Size(385, 205);
            this.grpRegistarItem.TabIndex = 2;
            this.grpRegistarItem.TabStop = false;
            this.grpRegistarItem.Text = "Registar Item Selecionado (Planeado)";
            // 
            // btnRegistarItem
            // 
            this.btnRegistarItem.Location = new System.Drawing.Point(18, 120);
            this.btnRegistarItem.Name = "btnRegistarItem";
            this.btnRegistarItem.Size = new System.Drawing.Size(232, 35);
            this.btnRegistarItem.TabIndex = 0;
            this.btnRegistarItem.Text = "Atualizar Item no Carrinho";
            this.btnRegistarItem.UseVisualStyleBackColor = true;
            // 
            // txtPrecoUnitario
            // 
            this.txtPrecoUnitario.Location = new System.Drawing.Point(130, 72);
            this.txtPrecoUnitario.Name = "txtPrecoUnitario";
            this.txtPrecoUnitario.Size = new System.Drawing.Size(120, 20);
            this.txtPrecoUnitario.TabIndex = 1;
            // 
            // lblPrecoUnitario
            // 
            this.lblPrecoUnitario.Location = new System.Drawing.Point(15, 75);
            this.lblPrecoUnitario.Name = "lblPrecoUnitario";
            this.lblPrecoUnitario.Size = new System.Drawing.Size(100, 20);
            this.lblPrecoUnitario.TabIndex = 2;
            this.lblPrecoUnitario.Text = "Preço Unitário (€):";
            // 
            // numQtdAdquirida
            // 
            this.numQtdAdquirida.Location = new System.Drawing.Point(130, 33);
            this.numQtdAdquirida.Name = "numQtdAdquirida";
            this.numQtdAdquirida.Size = new System.Drawing.Size(120, 20);
            this.numQtdAdquirida.TabIndex = 3;
            // 
            // lblQtdAdquirida
            // 
            this.lblQtdAdquirida.Location = new System.Drawing.Point(15, 35);
            this.lblQtdAdquirida.Name = "lblQtdAdquirida";
            this.lblQtdAdquirida.Size = new System.Drawing.Size(100, 20);
            this.lblQtdAdquirida.TabIndex = 4;
            this.lblQtdAdquirida.Text = "Qtd. Adquirida:";
            // 
            // grpAdicionarExtra
            // 
            this.grpAdicionarExtra.Controls.Add(this.btnAdicionarExtra);
            this.grpAdicionarExtra.Controls.Add(this.txtObservacoes);
            this.grpAdicionarExtra.Controls.Add(this.lblObservacoes);
            this.grpAdicionarExtra.Controls.Add(this.txtPrecoExtra);
            this.grpAdicionarExtra.Controls.Add(this.lblPrecoExtra);
            this.grpAdicionarExtra.Controls.Add(this.numQtdExtra);
            this.grpAdicionarExtra.Controls.Add(this.lblQtdExtra);
            this.grpAdicionarExtra.Controls.Add(this.cmbArtigoExtra);
            this.grpAdicionarExtra.Controls.Add(this.lblArtigoExtra);
            this.grpAdicionarExtra.Controls.Add(this.cmbTipoArtigoExtra);
            this.grpAdicionarExtra.Controls.Add(this.lblTipoArtigoExtra);
            this.grpAdicionarExtra.Location = new System.Drawing.Point(415, 295);
            this.grpAdicionarExtra.Name = "grpAdicionarExtra";
            this.grpAdicionarExtra.Size = new System.Drawing.Size(405, 205);
            this.grpAdicionarExtra.TabIndex = 1;
            this.grpAdicionarExtra.TabStop = false;
            this.grpAdicionarExtra.Text = "Adicionar Artigo Não Previsto (Impulso)";
            // 
            // btnAdicionarExtra
            // 
            this.btnAdicionarExtra.Location = new System.Drawing.Point(100, 155);
            this.btnAdicionarExtra.Name = "btnAdicionarExtra";
            this.btnAdicionarExtra.Size = new System.Drawing.Size(290, 35);
            this.btnAdicionarExtra.TabIndex = 0;
            this.btnAdicionarExtra.Text = "Inserir Artigo por Impulso";
            this.btnAdicionarExtra.UseVisualStyleBackColor = true;
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.Location = new System.Drawing.Point(100, 117);
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.Size = new System.Drawing.Size(290, 20);
            this.txtObservacoes.TabIndex = 1;
            // 
            // lblObservacoes
            // 
            this.lblObservacoes.Location = new System.Drawing.Point(15, 120);
            this.lblObservacoes.Name = "lblObservacoes";
            this.lblObservacoes.Size = new System.Drawing.Size(80, 20);
            this.lblObservacoes.TabIndex = 2;
            this.lblObservacoes.Text = "Observações:";
            // 
            // txtPrecoExtra
            // 
            this.txtPrecoExtra.Location = new System.Drawing.Point(270, 85);
            this.txtPrecoExtra.Name = "txtPrecoExtra";
            this.txtPrecoExtra.Size = new System.Drawing.Size(120, 20);
            this.txtPrecoExtra.TabIndex = 3;
            // 
            // lblPrecoExtra
            // 
            this.lblPrecoExtra.Location = new System.Drawing.Point(200, 88);
            this.lblPrecoExtra.Name = "lblPrecoExtra";
            this.lblPrecoExtra.Size = new System.Drawing.Size(70, 20);
            this.lblPrecoExtra.TabIndex = 4;
            this.lblPrecoExtra.Text = "Preço (€):";
            // 
            // numQtdExtra
            // 
            this.numQtdExtra.Location = new System.Drawing.Point(100, 86);
            this.numQtdExtra.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQtdExtra.Name = "numQtdExtra";
            this.numQtdExtra.Size = new System.Drawing.Size(80, 20);
            this.numQtdExtra.TabIndex = 5;
            this.numQtdExtra.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQtdExtra
            // 
            this.lblQtdExtra.Location = new System.Drawing.Point(15, 88);
            this.lblQtdExtra.Name = "lblQtdExtra";
            this.lblQtdExtra.Size = new System.Drawing.Size(80, 20);
            this.lblQtdExtra.TabIndex = 6;
            this.lblQtdExtra.Text = "Qtd. Extra:";
            // 
            // cmbArtigoExtra
            // 
            this.cmbArtigoExtra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArtigoExtra.Location = new System.Drawing.Point(100, 52);
            this.cmbArtigoExtra.Name = "cmbArtigoExtra";
            this.cmbArtigoExtra.Size = new System.Drawing.Size(290, 21);
            this.cmbArtigoExtra.TabIndex = 7;
            // 
            // lblArtigoExtra
            // 
            this.lblArtigoExtra.Location = new System.Drawing.Point(15, 55);
            this.lblArtigoExtra.Name = "lblArtigoExtra";
            this.lblArtigoExtra.Size = new System.Drawing.Size(80, 20);
            this.lblArtigoExtra.TabIndex = 8;
            this.lblArtigoExtra.Text = "Artigo:";
            // 
            // cmbTipoArtigoExtra
            // 
            this.cmbTipoArtigoExtra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoArtigoExtra.Location = new System.Drawing.Point(100, 22);
            this.cmbTipoArtigoExtra.Name = "cmbTipoArtigoExtra";
            this.cmbTipoArtigoExtra.Size = new System.Drawing.Size(290, 21);
            this.cmbTipoArtigoExtra.TabIndex = 9;
            // 
            // lblTipoArtigoExtra
            // 
            this.lblTipoArtigoExtra.Location = new System.Drawing.Point(15, 25);
            this.lblTipoArtigoExtra.Name = "lblTipoArtigoExtra";
            this.lblTipoArtigoExtra.Size = new System.Drawing.Size(80, 20);
            this.lblTipoArtigoExtra.TabIndex = 10;
            this.lblTipoArtigoExtra.Text = "Tipo Artigo:";
            // 
            // btnFecharCompra
            // 
            this.btnFecharCompra.BackColor = System.Drawing.Color.LightCoral;
            this.btnFecharCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharCompra.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnFecharCompra.Location = new System.Drawing.Point(620, 515);
            this.btnFecharCompra.Name = "btnFecharCompra";
            this.btnFecharCompra.Size = new System.Drawing.Size(200, 40);
            this.btnFecharCompra.TabIndex = 0;
            this.btnFecharCompra.Text = "Concluir / Fechar Compra";
            this.btnFecharCompra.UseVisualStyleBackColor = false;
            // 
            // FormCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 567);
            this.Controls.Add(this.btnFecharCompra);
            this.Controls.Add(this.grpAdicionarExtra);
            this.Controls.Add(this.grpRegistarItem);
            this.Controls.Add(this.dgvItensCompra);
            this.Controls.Add(this.lblOrcamentoDisponivel);
            this.Controls.Add(this.lblNomeCompra);
            this.Name = "FormCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iShopping - Modo Compra";
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensCompra)).EndInit();
            this.grpRegistarItem.ResumeLayout(false);
            this.grpRegistarItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdAdquirida)).EndInit();
            this.grpAdicionarExtra.ResumeLayout(false);
            this.grpAdicionarExtra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdExtra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}