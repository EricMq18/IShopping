using IShopping.Controller;
using IShopping.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IShopping.View
{
    public partial class GestaoOrcamento : Form
    {
        private OrcamentoController _controller;
        private int idOrcamentoSelecionado = 0;

        public GestaoOrcamento()
        {
            InitializeComponent();
            _controller = new OrcamentoController();
        }

        private void CarregarFiltroAnos()
        {
            var listaAnos = _controller.ObterAnosComOrcamentos();
            listaAnos.Insert(0, "Todos"); // Adiciona a opção "Todos" no topo da lista

            cmbAnoFiltro.DataSource = listaAnos;
        }

        private void GestaoOrcamento_Load(object sender, EventArgs e)
        {
            CarregarOrcamentos();
            CarregarFiltroAnos();
        }

        private void CarregarOrcamentos(string anoFiltro = "Todos")
        {
            lstOrcamentos.DataSource = null;
            lstOrcamentos.DataSource = _controller.ObterOrcamentosParaLista(anoFiltro);
            lstOrcamentos.DisplayMember = "DisplayText";
            lstOrcamentos.ValueMember = "id";

            lstOrcamentos.ClearSelected();
        }

        private void lstOrcamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOrcamentos.SelectedItem != null && lstOrcamentos.SelectedValue is int)
            {
                idOrcamentoSelecionado = (int)lstOrcamentos.SelectedValue;

                var orcamento = _controller.ObterOrcamentoPorId(idOrcamentoSelecionado);
                if (orcamento != null)
                {
                    dtpMes.Value = orcamento.mes;
                    txtValorMax.Text = orcamento.valor_max.ToString();

                    // Preenche a Label do Criador
                    if (orcamento.userCriador != null)
                        lblCriadoPor.Text = "Criado por: " + orcamento.userCriador.username;
                    else
                        lblCriadoPor.Text = "Criado por: Desconhecido";

                    // Preenche a Label de quem Editou
                    if (orcamento.userAlterador != null)
                        lblEditadoPor.Text = "Última edição: " + orcamento.userAlterador.username;
                    else
                        lblEditadoPor.Text = "Última edição: ---";
                }
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (cmbAnoFiltro.SelectedItem != null)
            {
                CarregarOrcamentos(cmbAnoFiltro.SelectedItem.ToString());
            }
        }

        private void btnAddOrcamento_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtValorMax.Text, out decimal valorMax))
            {
                int userId = Program.UtilizadorLogadoId; // Faltava ir buscar o utilizador aqui!

                _controller.AdicionarOrcamento(dtpMes.Value, valorMax, userId);

                LimparFormulario();
                CarregarOrcamentos(cmbAnoFiltro.SelectedItem?.ToString() ?? "Todos");
                CarregarFiltroAnos(); // Atualiza os anos caso tenhas adicionado um ano novo
            }
            else
            {
                MessageBox.Show("Por favor, insira um valor numérico válido para o orçamento.");
            }
        }

        private void btnEditOrcamento_Click(object sender, EventArgs e)
        {
            if (idOrcamentoSelecionado == 0) return;

            if (decimal.TryParse(txtValorMax.Text, out decimal valorMax))
            {
                int userId = Program.UtilizadorLogadoId;

                _controller.AtualizarOrcamento(idOrcamentoSelecionado, dtpMes.Value, valorMax, userId);

                LimparFormulario();
                CarregarOrcamentos(cmbAnoFiltro.SelectedItem?.ToString() ?? "Todos");
            }
            else
            {
                MessageBox.Show("Por favor, insira um valor numérico válido para o orçamento.");
            }
        }

        public void AtualizarOrcamento(int id, DateTime novoMes, decimal novoValorMax, int userId)
        {
            using (var db = new ShoppingContext())
            {
                var orcamento = db.orcamentos.FirstOrDefault(o => o.id == id);

                // Vai buscar o utilizador à base de dados usando o ID
                var userLogado = db.users.FirstOrDefault(u => u.id == userId);

                if (orcamento != null)
                {
                    orcamento.mes = novoMes;
                    orcamento.valor_max = novoValorMax;

                    // Regista que este utilizador foi quem alterou!
                    orcamento.userAlterador = userLogado;

                    db.SaveChanges();
                }
            }
        }

        private void btnDeleteOrcamento_Click(object sender, EventArgs e)
        {
            if (idOrcamentoSelecionado == 0) return;

            DialogResult resposta = MessageBox.Show("Tem a certeza que deseja eliminar este orçamento?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resposta == DialogResult.Yes)
            {
                _controller.EliminarOrcamento(idOrcamentoSelecionado);
                LimparFormulario();
                CarregarOrcamentos(cmbAnoFiltro.SelectedItem?.ToString() ?? "Todos");
                CarregarFiltroAnos();
            }
        }

        private void LimparFormulario()
        {
            idOrcamentoSelecionado = 0;
            txtValorMax.Clear();
            dtpMes.Value = DateTime.Now;
            lstOrcamentos.ClearSelected();

            // Repor as labels
            lblCriadoPor.Text = "Criado por: ---";
            lblEditadoPor.Text = "Última edição: ---";
        }
    }
}
