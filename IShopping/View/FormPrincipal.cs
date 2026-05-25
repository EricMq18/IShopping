using IShopping.Controller;
using System;
using System.Windows.Forms;

namespace IShopping.View
{
    public partial class FormPrincipal : Form
    {
        private int _utilizadorId;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        public FormPrincipal(int utilizadorId, string nomeUsuario)
        {
            InitializeComponent();
            _utilizadorId = utilizadorId;
            lblUsuarioLogado.Text = $"Utilizador: {nomeUsuario}";

            this.Load += FormPrincipal_Load;

            // Subscrição de Eventos
            itemUtilizadores.Click += (s, e) => AbrirFormulario("Utilizadores");
            itemTiposArtigo.Click += (s, e) => AbrirFormulario("TiposArtigo");
            itemArtigos.Click += (s, e) => AbrirFormulario("Artigos");
            itemOrcamentos.Click += (s, e) => AbrirFormulario("Orcamentos");
            itemPlaneamento.Click += (s, e) => AbrirFormulario("Planeamento");
            itemEstatisticas.Click += (s, e) => AbrirFormulario("Estatisticas");
            btnAbrirModoCompra.Click += btnAbrirModoCompra_Click;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            AtualizarListaComprasAbertas();
        }

        private void AtualizarListaComprasAbertas()
        {
            // Lógica para carregar via Entity Framework as compras onde 'fechada == false'
            // dgvComprasAbertas.DataSource = context.Compras.Where(c => !c.Fechada).ToList();
        }

        private void btnAbrirModoCompra_Click(object sender, EventArgs e)
        {
            if (dgvComprasAbertas.CurrentRow != null)
            {
                // Abrir o Formulário do modo Compra (item h do enunciado) 
                AbrirFormulario("ModoCompra");
            }
            else
            {
                MessageBox.Show("Selecione uma compra na lista para iniciar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AbrirFormulario(string tipo)
        {
            Form formDestino = null;

            switch (tipo)
            {
                case "Utilizadores":
                    // Ainda não tens o formulário de Gestão de Utilizadores criado. 
                    // formDestino = new GestaoUtilizadores(); 
                    break;

                case "TiposArtigo":
                    // Ainda não tens o formulário de Tipos de Artigo criado.
                    // formDestino = new GestaoTiposArtigo(); 
                    break;

                case "Artigos":
                    formDestino = new GestaoArtigos();
                    break;

                case "Orcamentos":
                    // Ainda não tens o formulário de Orçamentos criado.
                    // formDestino = new GestaoOrcamentos(); 
                    break;

                case "Planeamento":
                    // Ainda não tens o formulário de Planeamento criado.
                    // formDestino = new FormPlaneamento(); 
                    break;

                case "ModoCompra":
                    formDestino = new FormCompra();
                    break;

                case "Estatisticas":
                    // Ainda não tens o formulário de Estatísticas criado.
                    // formDestino = new FormEstatisticas();
                    break;
            }

            if (formDestino != null)
            {
                formDestino.ShowDialog();
                AtualizarListaComprasAbertas(); // Atualiza a lista caso algo tenha mudado
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
    }
}