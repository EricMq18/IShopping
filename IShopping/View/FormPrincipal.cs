using IShopping.Controller;
using System;
using System.Linq;
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
            itemArtigos.Click += (s, e) => AbrirFormulario("Artigos");
            itemTiposArtigo.Click += (s, e) => AbrirFormulario("TiposArtigo");
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
            try
            {
                using (var context = new IShopping.Model.ShoppingContext())
                {
                    // Vai à base de dados buscar apenas as compras que estão em aberto
                    var comprasAbertas = context.compras
                        .Where(c => c.estado == IShopping.Model.Estado.aberto)
                        .Select(c => new
                        {
                            id = c.id, // O id minúsculo é fundamental para o botão ModoCompra conseguir ler
                            Nome = c.nome,
                            DataCriacao = c.dataCriacao,
                            Criador = c.userCriador != null ? c.userCriador.username : "Desconhecido"
                        }).ToList();

                    dgvComprasAbertas.DataSource = comprasAbertas;
                }
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
                case "Artigos":
                    formDestino = new GestaoArtigos();
                    break;

                case "TiposArtigo":
                    formDestino = new GestaoCategorias(); 
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
                    if (dgvComprasAbertas.CurrentRow != null)
                    {
                        int compraId = Convert.ToInt32(dgvComprasAbertas.CurrentRow.Cells["id"].Value);

                        formDestino = new FormCompra(_utilizadorId, compraId);
                    }
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