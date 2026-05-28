using IShopping.Controller;
using IShopping.Model;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace IShopping.View
{
    public partial class FormCompra : Form
    {
        private int _utilizadorId;
        private int _compraId;
        private CompraController _controller;

        public FormCompra(int utilizadorId, int compraId)
        {
            InitializeComponent();
            _utilizadorId = utilizadorId;
            _compraId = compraId;
            _controller = new CompraController();

            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            this.Load += FormCompra_Load;
            this.cmbTipoArtigoExtra.SelectedIndexChanged += CmbTipoArtigoExtra_SelectedIndexChanged;
            this.btnRegistarItem.Click += BtnRegistarItem_Click;
            this.btnAdicionarExtra.Click += BtnAdicionarExtra_Click;
            this.btnFecharCompra.Click += BtnFecharCompra_Click;
            this.dgvItensCompra.SelectionChanged += DgvItensCompra_SelectionChanged;
        }

        private void FormCompra_Load(object sender, EventArgs e)
        {
            CarregarCabecalhoCompra();
            CarregarTiposArtigoExtra();
            AtualizarGrelhaItens();
            CalcularOrcamentoDisponivel();
        }

        private void CarregarCabecalhoCompra()
        {
            try
            {
                string nome = _controller.ObterNomeCompra(_compraId);
                lblNomeCompra.Text = $"Carrinho Atual: {nome}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar cabeçalho da compra: {ex.Message}");
            }
        }

        private void CarregarTiposArtigoExtra()
        {
            try
            {
                cmbTipoArtigoExtra.DataSource = _controller.ObterCategorias();
                // ATENÇÃO ÀS MAIÚSCULAS: Correspondem às propriedades do modelo TipoArtigo.cs
                cmbTipoArtigoExtra.DisplayMember = "Categoria";
                cmbTipoArtigoExtra.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar categorias: {ex.Message}");
            }
        }

        private void CmbTipoArtigoExtra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoArtigoExtra.SelectedValue != null && int.TryParse(cmbTipoArtigoExtra.SelectedValue.ToString(), out int tipoId))
            {
                try
                {
                    cmbArtigoExtra.DataSource = _controller.ObterArtigosPorCategoria(tipoId);
                    // ATENÇÃO ÀS MAIÚSCULAS: Correspondem às propriedades do modelo Artigo.cs
                    cmbArtigoExtra.DisplayMember = "Nome";
                    cmbArtigoExtra.ValueMember = "Id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar os artigos: {ex.Message}");
                }
            }
        }

        private void AtualizarGrelhaItens()
        {
            try
            {
                var itensOriginais = _controller.ObterItensDaCompra(_compraId);
                
                var itensFormatados = itensOriginais.Select(i => new
                {
                    ID = i.id,
                    Tipo = i is ArtigoPrevisto ? "Previsto" : "Não Previsto",
                    Artigo = i.artigo != null ? i.artigo.Nome : "Artigo Desconhecido",
                    Qtd_Prevista = i is ArtigoPrevisto ap ? ap.qntPrevista : 0,
                    Qtd_Adquirida = i.quantidadeAdquirida,
                    Preco_Unitario = i.precoUnitario,
                    Subtotal = i.quantidadeAdquirida * i.precoUnitario,
                    Observacoes = i is ArtigoNaoPrevisto anp ? anp.descricao : ""
                }).ToList();

                dgvItensCompra.DataSource = itensFormatados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar tabela de itens: {ex.Message}");
            }
        }

        private void DgvItensCompra_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvItensCompra.CurrentRow != null)
            {
                string tipo = dgvItensCompra.CurrentRow.Cells["Tipo"].Value.ToString();

                if (tipo == "Previsto")
                {
                    grpRegistarItem.Enabled = true;
                    numQtdAdquirida.Value = Convert.ToInt32(dgvItensCompra.CurrentRow.Cells["Qtd_Adquirida"].Value);
                    txtPrecoUnitario.Text = Convert.ToDecimal(dgvItensCompra.CurrentRow.Cells["Preco_Unitario"].Value).ToString("F2");
                }
                else
                {
                    grpRegistarItem.Enabled = false;
                    numQtdAdquirida.Value = 0;
                    txtPrecoUnitario.Text = "0.00";
                }
            }
        }

        private void BtnRegistarItem_Click(object sender, EventArgs e)
        {
            if (dgvItensCompra.CurrentRow == null) return;

            string precoTexto = txtPrecoUnitario.Text.Replace(',', '.');
            if (!decimal.TryParse(precoTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precoUnitario) || precoUnitario < 0)
            {
                MessageBox.Show("Por favor, introduza um preço unitário válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int itemId = (int)dgvItensCompra.CurrentRow.Cells["ID"].Value;

                _controller.AtualizarItemAdquirido(itemId, (int)numQtdAdquirida.Value, precoUnitario, _compraId);

                AtualizarGrelhaItens();
                CalcularOrcamentoDisponivel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar item: {ex.Message}");
            }
        }

        private void BtnAdicionarExtra_Click(object sender, EventArgs e)
        {
            if (cmbArtigoExtra.SelectedValue == null)
            {
                MessageBox.Show("Selecione um artigo válido para adicionar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string precoTexto = txtPrecoExtra.Text.Replace(',', '.');
            if (!decimal.TryParse(precoTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precoExtra) || precoExtra <= 0)
            {
                MessageBox.Show("Por favor, introduza um preço válido para o artigo extra.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int artigoId = (int)cmbArtigoExtra.SelectedValue;

                _controller.AdicionarItemExtra(_compraId, artigoId, (int)numQtdExtra.Value, precoExtra, txtObservacoes.Text);

                txtPrecoExtra.Clear();
                txtObservacoes.Clear();
                numQtdExtra.Value = 1;

                AtualizarGrelhaItens();
                CalcularOrcamentoDisponivel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir artigo não previsto: {ex.Message}");
            }
        }

        private void CalcularOrcamentoDisponivel()
        {
            try
            {
                decimal saldoFinal = _controller.CalcularSaldoDisponivel(_compraId);

                lblOrcamentoDisponivel.Text = $"Saldo Disponível: {saldoFinal.ToString("C2", CultureInfo.GetCultureInfo("pt-PT"))}";

                if (saldoFinal < 0)
                    lblOrcamentoDisponivel.ForeColor = System.Drawing.Color.Red;
                else
                    lblOrcamentoDisponivel.ForeColor = System.Drawing.Color.ForestGreen;
            }
            catch (Exception)
            {
                lblOrcamentoDisponivel.Text = "Saldo Disponível: Indisponível";
            }
        }

        private void BtnFecharCompra_Click(object sender, EventArgs e)
        {
            var confirmacao = MessageBox.Show("Tem a certeza de que deseja finalizar e fechar esta compra?",
                "Confirmar Fecho", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                try
                {
                    _controller.FecharCompra(_compraId);

                    MessageBox.Show("Compra concluída com sucesso! Carrinho fechado.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao fechar a compra: {ex.Message}");
                }
            }
        }
    }
}