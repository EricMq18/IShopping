namespace IShopping.View
{
    partial class FormEstatisticas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControlEstatisticas;
        private System.Windows.Forms.TabPage tabListagens;
        private System.Windows.Forms.TabPage tabSugestoes;
        private System.Windows.Forms.DataGridView dgvOrcamentosMensais;
        private System.Windows.Forms.DataGridView dgvPercentagensCompras;
        private System.Windows.Forms.DataGridView dgvSugestaoCompras;
        private System.Windows.Forms.Label lblOrcamentoSugerido;
        private System.Windows.Forms.Button btnGerarSugestao;
        private System.Windows.Forms.Label lblTitulo1;
        private System.Windows.Forms.Label lblTitulo2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControlEstatisticas = new System.Windows.Forms.TabControl();
            this.tabListagens = new System.Windows.Forms.TabPage();
            this.lblTitulo2 = new System.Windows.Forms.Label();
            this.dgvPercentagensCompras = new System.Windows.Forms.DataGridView();
            this.lblTitulo1 = new System.Windows.Forms.Label();
            this.dgvOrcamentosMensais = new System.Windows.Forms.DataGridView();
            this.tabSugestoes = new System.Windows.Forms.TabPage();
            this.dgvSugestaoCompras = new System.Windows.Forms.DataGridView();
            this.btnGerarSugestao = new System.Windows.Forms.Button();
            this.lblOrcamentoSugerido = new System.Windows.Forms.Label();

            this.tabControlEstatisticas.SuspendLayout();
            this.tabListagens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPercentagensCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrcamentosMensais)).BeginInit();
            this.tabSugestoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSugestaoCompras)).BeginInit();
            this.SuspendLayout();

            // tabControlEstatisticas
            this.tabControlEstatisticas.Controls.Add(this.tabListagens);
            this.tabControlEstatisticas.Controls.Add(this.tabSugestoes);
            this.tabControlEstatisticas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEstatisticas.Location = new System.Drawing.Point(0, 0);
            this.tabControlEstatisticas.Name = "tabControlEstatisticas";
            this.tabControlEstatisticas.SelectedIndex = 0;
            this.tabControlEstatisticas.Size = new System.Drawing.Size(800, 450);

            // tabListagens
            this.tabListagens.Controls.Add(this.lblTitulo2);
            this.tabListagens.Controls.Add(this.dgvPercentagensCompras);
            this.tabListagens.Controls.Add(this.lblTitulo1);
            this.tabListagens.Controls.Add(this.dgvOrcamentosMensais);
            this.tabListagens.Location = new System.Drawing.Point(4, 25);
            this.tabListagens.Name = "tabListagens";
            this.tabListagens.Padding = new System.Windows.Forms.Padding(3);
            this.tabListagens.Size = new System.Drawing.Size(792, 421);
            this.tabListagens.Text = "Listagens Gerais";
            this.tabListagens.UseVisualStyleBackColor = true;

            // lblTitulo2
            this.lblTitulo2.AutoSize = true;
            this.lblTitulo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitulo2.Location = new System.Drawing.Point(8, 220);
            this.lblTitulo2.Name = "lblTitulo2";
            this.lblTitulo2.Size = new System.Drawing.Size(262, 18);
            this.lblTitulo2.Text = "Percentagem Previstos vs Não Previstos";

            // dgvPercentagensCompras
            this.dgvPercentagensCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPercentagensCompras.Location = new System.Drawing.Point(8, 241);
            this.dgvPercentagensCompras.Name = "dgvPercentagensCompras";
            this.dgvPercentagensCompras.Size = new System.Drawing.Size(776, 172);

            // lblTitulo1
            this.lblTitulo1.AutoSize = true;
            this.lblTitulo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitulo1.Location = new System.Drawing.Point(8, 15);
            this.lblTitulo1.Name = "lblTitulo1";
            this.lblTitulo1.Size = new System.Drawing.Size(268, 18);
            this.lblTitulo1.Text = "Orçamentos vs Gastos por Mês";

            // dgvOrcamentosMensais
            this.dgvOrcamentosMensais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrcamentosMensais.Location = new System.Drawing.Point(8, 36);
            this.dgvOrcamentosMensais.Name = "dgvOrcamentosMensais";
            this.dgvOrcamentosMensais.Size = new System.Drawing.Size(776, 172);

            // tabSugestoes
            this.tabSugestoes.Controls.Add(this.dgvSugestaoCompras);
            this.tabSugestoes.Controls.Add(this.btnGerarSugestao);
            this.tabSugestoes.Controls.Add(this.lblOrcamentoSugerido);
            this.tabSugestoes.Location = new System.Drawing.Point(4, 25);
            this.tabSugestoes.Name = "tabSugestoes";
            this.tabSugestoes.Padding = new System.Windows.Forms.Padding(3);
            this.tabSugestoes.Size = new System.Drawing.Size(792, 421);
            this.tabSugestoes.Text = "Sugestões Inteligentes";
            this.tabSugestoes.UseVisualStyleBackColor = true;

            // dgvSugestaoCompras
            this.dgvSugestaoCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSugestaoCompras.Location = new System.Drawing.Point(22, 118);
            this.dgvSugestaoCompras.Name = "dgvSugestaoCompras";
            this.dgvSugestaoCompras.Size = new System.Drawing.Size(749, 281);

            // btnGerarSugestao
            this.btnGerarSugestao.Location = new System.Drawing.Point(22, 70);
            this.btnGerarSugestao.Name = "btnGerarSugestao";
            this.btnGerarSugestao.Size = new System.Drawing.Size(220, 31);
            this.btnGerarSugestao.Text = "Gerar Sugestão Semanal";
            this.btnGerarSugestao.UseVisualStyleBackColor = true;
            this.btnGerarSugestao.Click += new System.EventHandler(this.btnGerarSugestao_Click);

            // lblOrcamentoSugerido
            this.lblOrcamentoSugerido.AutoSize = true;
            this.lblOrcamentoSugerido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblOrcamentoSugerido.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblOrcamentoSugerido.Location = new System.Drawing.Point(17, 26);
            this.lblOrcamentoSugerido.Name = "lblOrcamentoSugerido";
            this.lblOrcamentoSugerido.Size = new System.Drawing.Size(394, 25);
            this.lblOrcamentoSugerido.Text = "Orçamento Sugerido para o Próximo Mês: ---";

            // FormEstatisticas
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlEstatisticas);
            this.Name = "FormEstatisticas";
            this.Text = "Estatísticas e Planeamento Inteligente";
            this.Load += new System.EventHandler(this.FormEstatisticas_Load);

            this.tabControlEstatisticas.ResumeLayout(false);
            this.tabListagens.ResumeLayout(false);
            this.tabListagens.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPercentagensCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrcamentosMensais)).EndInit();
            this.tabSugestoes.ResumeLayout(false);
            this.tabSugestoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSugestaoCompras)).EndInit();
            this.ResumeLayout(false);
        }
    }
}