namespace IShopping.View
{
    partial class GestaoOrcamento
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
            this.lstOrcamentos = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValorMax = new System.Windows.Forms.TextBox();
            this.btnAddOrcamento = new System.Windows.Forms.Button();
            this.btnDeleteOrcamento = new System.Windows.Forms.Button();
            this.btnEditOrcamento = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.cmbAnoFiltro = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpMes = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCriadoPor = new System.Windows.Forms.Label();
            this.lblEditadoPor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstOrcamentos
            // 
            this.lstOrcamentos.FormattingEnabled = true;
            this.lstOrcamentos.ItemHeight = 16;
            this.lstOrcamentos.Location = new System.Drawing.Point(16, 97);
            this.lstOrcamentos.Name = "lstOrcamentos";
            this.lstOrcamentos.Size = new System.Drawing.Size(312, 356);
            this.lstOrcamentos.TabIndex = 36;
            this.lstOrcamentos.SelectedIndexChanged += new System.EventHandler(this.lstOrcamentos_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "Valor máximo :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "Lista de Orçamentos";
            // 
            // txtValorMax
            // 
            this.txtValorMax.Location = new System.Drawing.Point(349, 116);
            this.txtValorMax.Name = "txtValorMax";
            this.txtValorMax.Size = new System.Drawing.Size(159, 22);
            this.txtValorMax.TabIndex = 32;
            // 
            // btnAddOrcamento
            // 
            this.btnAddOrcamento.Location = new System.Drawing.Point(417, 165);
            this.btnAddOrcamento.Name = "btnAddOrcamento";
            this.btnAddOrcamento.Size = new System.Drawing.Size(165, 23);
            this.btnAddOrcamento.TabIndex = 31;
            this.btnAddOrcamento.Text = "Adicionar";
            this.btnAddOrcamento.UseVisualStyleBackColor = true;
            this.btnAddOrcamento.Click += new System.EventHandler(this.btnAddOrcamento_Click);
            // 
            // btnDeleteOrcamento
            // 
            this.btnDeleteOrcamento.Location = new System.Drawing.Point(417, 223);
            this.btnDeleteOrcamento.Name = "btnDeleteOrcamento";
            this.btnDeleteOrcamento.Size = new System.Drawing.Size(165, 23);
            this.btnDeleteOrcamento.TabIndex = 30;
            this.btnDeleteOrcamento.Text = "Eliminar";
            this.btnDeleteOrcamento.UseVisualStyleBackColor = true;
            this.btnDeleteOrcamento.Click += new System.EventHandler(this.btnDeleteOrcamento_Click);
            // 
            // btnEditOrcamento
            // 
            this.btnEditOrcamento.Location = new System.Drawing.Point(420, 194);
            this.btnEditOrcamento.Name = "btnEditOrcamento";
            this.btnEditOrcamento.Size = new System.Drawing.Size(162, 23);
            this.btnEditOrcamento.TabIndex = 29;
            this.btnEditOrcamento.Text = "Guardar Alterações";
            this.btnEditOrcamento.UseVisualStyleBackColor = true;
            this.btnEditOrcamento.Click += new System.EventHandler(this.btnEditOrcamento_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(149, 42);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(73, 23);
            this.btnPesquisar.TabIndex = 28;
            this.btnPesquisar.Text = "Procurar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // cmbAnoFiltro
            // 
            this.cmbAnoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnoFiltro.FormattingEnabled = true;
            this.cmbAnoFiltro.Location = new System.Drawing.Point(12, 41);
            this.cmbAnoFiltro.Name = "cmbAnoFiltro";
            this.cmbAnoFiltro.Size = new System.Drawing.Size(131, 24);
            this.cmbAnoFiltro.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Gestão Orçamentos";
            // 
            // dtpMes
            // 
            this.dtpMes.CustomFormat = "MM/yyyy";
            this.dtpMes.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMes.Location = new System.Drawing.Point(530, 116);
            this.dtpMes.Name = "dtpMes";
            this.dtpMes.Size = new System.Drawing.Size(100, 22);
            this.dtpMes.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(527, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 38;
            this.label4.Text = "Mês :";
            // 
            // lblCriadoPor
            // 
            this.lblCriadoPor.AutoSize = true;
            this.lblCriadoPor.Location = new System.Drawing.Point(349, 29);
            this.lblCriadoPor.Name = "lblCriadoPor";
            this.lblCriadoPor.Size = new System.Drawing.Size(79, 16);
            this.lblCriadoPor.TabIndex = 39;
            this.lblCriadoPor.Text = "Criado por : ";
            // 
            // lblEditadoPor
            // 
            this.lblEditadoPor.AutoSize = true;
            this.lblEditadoPor.Location = new System.Drawing.Point(349, 59);
            this.lblEditadoPor.Name = "lblEditadoPor";
            this.lblEditadoPor.Size = new System.Drawing.Size(83, 16);
            this.lblEditadoPor.TabIndex = 40;
            this.lblEditadoPor.Text = "Editado por :";
            // 
            // GestaoOrcamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 476);
            this.Controls.Add(this.lblEditadoPor);
            this.Controls.Add(this.lblCriadoPor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpMes);
            this.Controls.Add(this.lstOrcamentos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtValorMax);
            this.Controls.Add(this.btnAddOrcamento);
            this.Controls.Add(this.btnDeleteOrcamento);
            this.Controls.Add(this.btnEditOrcamento);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.cmbAnoFiltro);
            this.Controls.Add(this.label1);
            this.Name = "GestaoOrcamento";
            this.Text = "GestaoOrcamento";
            this.Load += new System.EventHandler(this.GestaoOrcamento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstOrcamentos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValorMax;
        private System.Windows.Forms.Button btnAddOrcamento;
        private System.Windows.Forms.Button btnDeleteOrcamento;
        private System.Windows.Forms.Button btnEditOrcamento;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.ComboBox cmbAnoFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpMes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCriadoPor;
        private System.Windows.Forms.Label lblEditadoPor;
    }
}