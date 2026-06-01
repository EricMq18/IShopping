using System.Drawing;
using System.Windows.Forms;

namespace IShopping.View
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem menuGestao;
        private System.Windows.Forms.ToolStripMenuItem itemUtilizadores;
        private System.Windows.Forms.ToolStripMenuItem itemArtigos;
        private System.Windows.Forms.ToolStripMenuItem itemOrcamentos;
        private System.Windows.Forms.ToolStripMenuItem menuCompras;
        private System.Windows.Forms.ToolStripMenuItem itemPlaneamento;
        private System.Windows.Forms.ToolStripMenuItem itemEstatisticas;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView dgvComprasAbertas;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAbrirModoCompra;

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
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.menuGestao = new System.Windows.Forms.ToolStripMenuItem();
            this.itemUtilizadores = new System.Windows.Forms.ToolStripMenuItem();
            this.exportaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemTiposArtigo = new System.Windows.Forms.ToolStripMenuItem();
            this.itemArtigos = new System.Windows.Forms.ToolStripMenuItem();
            this.itemOrcamentos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.itemPlaneamento = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEstatisticas = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUsuarioLogado = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvComprasAbertas = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAbrirModoCompra = new System.Windows.Forms.Button();
            this.gestãoUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipal.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprasAbertas)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGestao,
            this.menuCompras,
            this.itemEstatisticas});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(800, 24);
            this.menuPrincipal.TabIndex = 4;
            // 
            // menuGestao
            // 
            this.menuGestao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemUtilizadores,
            this.itemTiposArtigo,
            this.itemArtigos,
            this.itemOrcamentos});
            this.menuGestao.Name = "menuGestao";
            this.menuGestao.Size = new System.Drawing.Size(55, 20);
            this.menuGestao.Text = "Gestão";
            // 
            // itemUtilizadores
            // 
            this.itemUtilizadores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportaToolStripMenuItem,
            this.gestãoUserToolStripMenuItem});
            this.itemUtilizadores.Name = "itemUtilizadores";
            this.itemUtilizadores.Size = new System.Drawing.Size(180, 22);
            this.itemUtilizadores.Text = "Utilizadores";
            // 
            // exportaToolStripMenuItem
            // 
            this.exportaToolStripMenuItem.Name = "exportaToolStripMenuItem";
            this.exportaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportaToolStripMenuItem.Text = "Exportar Compras";
            this.exportaToolStripMenuItem.Click += new System.EventHandler(this.exportaToolStripMenuItem_Click);
            // 
            // itemTiposArtigo
            // 
            this.itemTiposArtigo.Name = "itemTiposArtigo";
            this.itemTiposArtigo.Size = new System.Drawing.Size(180, 22);
            this.itemTiposArtigo.Text = "Tipos de Artigo";
            // 
            // itemArtigos
            // 
            this.itemArtigos.Name = "itemArtigos";
            this.itemArtigos.Size = new System.Drawing.Size(180, 22);
            this.itemArtigos.Text = "Artigos";
            // 
            // itemOrcamentos
            // 
            this.itemOrcamentos.Name = "itemOrcamentos";
            this.itemOrcamentos.Size = new System.Drawing.Size(180, 22);
            this.itemOrcamentos.Text = "Orçamentos";
            // 
            // menuCompras
            // 
            this.menuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemPlaneamento});
            this.menuCompras.Name = "menuCompras";
            this.menuCompras.Size = new System.Drawing.Size(67, 20);
            this.menuCompras.Text = "Compras";
            // 
            // itemPlaneamento
            // 
            this.itemPlaneamento.Name = "itemPlaneamento";
            this.itemPlaneamento.Size = new System.Drawing.Size(211, 22);
            this.itemPlaneamento.Text = "Planeamento de Compras";
            // 
            // itemEstatisticas
            // 
            this.itemEstatisticas.Name = "itemEstatisticas";
            this.itemEstatisticas.Size = new System.Drawing.Size(76, 20);
            this.itemEstatisticas.Text = "Estatísticas";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuarioLogado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 438);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 3;
            // 
            // lblUsuarioLogado
            // 
            this.lblUsuarioLogado.Name = "lblUsuarioLogado";
            this.lblUsuarioLogado.Size = new System.Drawing.Size(78, 17);
            this.lblUsuarioLogado.Text = "Utilizador: ---";
            // 
            // dgvComprasAbertas
            // 
            this.dgvComprasAbertas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComprasAbertas.ColumnHeadersHeight = 29;
            this.dgvComprasAbertas.Location = new System.Drawing.Point(12, 80);
            this.dgvComprasAbertas.Name = "dgvComprasAbertas";
            this.dgvComprasAbertas.ReadOnly = true;
            this.dgvComprasAbertas.RowHeadersWidth = 51;
            this.dgvComprasAbertas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComprasAbertas.Size = new System.Drawing.Size(776, 300);
            this.dgvComprasAbertas.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 45);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 30);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Compras em Aberto";
            // 
            // btnAbrirModoCompra
            // 
            this.btnAbrirModoCompra.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAbrirModoCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirModoCompra.Location = new System.Drawing.Point(610, 390);
            this.btnAbrirModoCompra.Name = "btnAbrirModoCompra";
            this.btnAbrirModoCompra.Size = new System.Drawing.Size(180, 40);
            this.btnAbrirModoCompra.TabIndex = 0;
            this.btnAbrirModoCompra.Text = "Entrar no Modo Compra";
            this.btnAbrirModoCompra.UseVisualStyleBackColor = false;
            this.btnAbrirModoCompra.Click += new System.EventHandler(this.btnAbrirModoCompra_Click);
            // 
            // gestãoUserToolStripMenuItem
            // 
            this.gestãoUserToolStripMenuItem.Name = "gestãoUserToolStripMenuItem";
            this.gestãoUserToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gestãoUserToolStripMenuItem.Text = "Gestão User";
            this.gestãoUserToolStripMenuItem.Click += new System.EventHandler(this.gestãoUserToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.ClientSize = new System.Drawing.Size(800, 460);
            this.Controls.Add(this.btnAbrirModoCompra);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvComprasAbertas);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuPrincipal);
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "FormPrincipal";
            this.Text = "iShopping - Form Principal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPrincipal_FormClosed);
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprasAbertas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ToolStripMenuItem exportaToolStripMenuItem;
        private ToolStripStatusLabel lblUsuarioLogado;
        private ToolStripMenuItem itemTiposArtigo;
        private ToolStripMenuItem gestãoUserToolStripMenuItem;
    }
}