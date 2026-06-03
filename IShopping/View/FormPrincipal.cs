using IShopping.Controller;
using System;
using System.Linq;
using System.Windows.Forms;

namespace IShopping.View
{
    public partial class FormPrincipal : Form
    {
        private int _utilizadorId;
        private string _nomeUserAtual;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        public FormPrincipal(int utilizadorId, string nomeUsuario)
        {
            InitializeComponent();
            _utilizadorId = utilizadorId;
            _nomeUserAtual = nomeUsuario;
            lblUsuarioLogado.Text = $"Utilizador: {nomeUsuario}";

            this.VisibleChanged += FormPrincipal_VisibleChanged;
            this.Load += FormPrincipal_Load;            
            // Eventos
            itemArtigos.Click += (s, e) => Program.forms(this, new GestaoArtigos());
            itemTiposArtigo.Click += (s, e) => Program.forms(this, new GestaoCategorias());
            itemOrcamentos.Click += (s, e) => Program.forms(this, new GestaoOrcamento());
            itemPlaneamento.Click += (s, e) => Program.forms(this,new FormPlaneamentoCompras(_utilizadorId));
            itemEstatisticas.Click += (s, e) => Program.forms(this, new FormEstatisticas());
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            AtualizarListaComprasAbertas();
        }

        private void FormPrincipal_VisibleChanged(object sender, EventArgs e)
        {            
            if (this.Visible)
            {
                AtualizarListaComprasAbertas();
            }
        }

        public void AtualizarListaComprasAbertas()
        {
            try
            {
                var controller = new IShopping.Controller.CompraController();
                dgvComprasAbertas.DataSource = controller.ObterComprasAbertas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar as compras em aberto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAbrirModoCompra_Click(object sender, EventArgs e)
        {
            if (dgvComprasAbertas.CurrentRow != null)
            {
                int compraId = Convert.ToInt32(dgvComprasAbertas.CurrentRow.Cells["id"].Value);
                Program.forms(this, new FormCompra(_utilizadorId, compraId));
            }
            else
            {
                MessageBox.Show("Selecione uma compra na lista para iniciar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void exportaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Selecione a pasta onde deseja guardar a exportação CSV:";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {                        
                        string caminhoFicheiro = new ExportarCsvController().CriarFicheiro(folderDialog.SelectedPath.ToString(), _utilizadorId);

                        MessageBox.Show($"Exportação realizada com sucesso!\n\nFicheiro gerado em:\n{caminhoFicheiro}","Sucesso na Exportação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocorreu um erro ao exportar os dados:\n{ex.Message}","Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void gestãoUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.forms(this, new UserForm(_utilizadorId, _nomeUserAtual));
        }
    }
}