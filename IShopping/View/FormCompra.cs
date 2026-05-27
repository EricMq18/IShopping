using IShopping.Model;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace IShopping.View
{
    public partial class FormCompra : Form
    {
        private int _utilizadorId;
        private int _compraId;

        public FormCompra(int utilizadorId, int compraId)
        {
            InitializeComponent();
            _utilizadorId = utilizadorId;
            _compraId = compraId;

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
                using (var context = new ShoppingContext())
                {
                    var compra = context.compras.Find(_compraId);
                    if (compra != null)
                    {
                        lblNomeCompra.Text = $"Carrinho Atual: {compra.nome}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar cabeçalho da compra: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarTiposArtigoExtra()
        {
            try
            {
                using (var context = new ShoppingContext())
                {
                    var categorias = context.tipos.ToList();
                    cmbTipoArtigoExtra.DataSource = categorias;
                    cmbTipoArtigoExtra.DisplayMember = "categoria";
                    cmbTipoArtigoExtra.ValueMember = "id"; // Corrigido para minúscula, igual ao teu modelo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar categorias: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbTipoArtigoExtra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoArtigoExtra.SelectedValue != null && int.TryParse(cmbTipoArtigoExtra.SelectedValue.ToString(), out int tipoId))
            {
                try
                {
                    using (var context = new ShoppingContext())
                    {
                        var artigosFiltrados = context.artigos.Where(a => a.TipoArtigoId == tipoId).ToList();

                        if (artigosFiltrados.Count > 0)
                        {
                            cmbArtigoExtra.DataSource = artigosFiltrados;
                            cmbArtigoExtra.DisplayMember = "nome";
                            cmbArtigoExtra.ValueMember = "id"; // Corrigido para minúscula
                        }
                        else
                        {
                            cmbArtigoExtra.DataSource = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar os artigos desta categoria: {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void AtualizarGrelhaItens()
        {
            try
            {
                using (var context = new ShoppingContext())
                {
                    var itensDestaCompra = context.itemCompras
                        .Include("artigo")
                        .Where(i => i.compra.id == _compraId)
                        .Select(i => new
                        {
                            ID = i.id,
                            Tipo = i.IsPrevisto ? "Previsto" : "Não Previsto",
                            Artigo = i.artigo != null ? i.artigo.Nome : "Artigo Desconhecido",
                            Qtd_Prevista = i.quantidadePrevista,
                            Qtd_Adquirida = i.quantidadeAdquirida,
                            Preco_Unitario = i.precoUnitario,
                            Subtotal = i.quantidadeAdquirida * i.precoUnitario,
                            Observacoes = i.Observacoes
                        }).ToList();

                    dgvItensCompra.DataSource = itensDestaCompra;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar tabela de itens: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (var context = new ShoppingContext())
                {
                    var itemParaAtualizar = context.itemCompras.Find(itemId);
                    if (itemParaAtualizar != null)
                    {
                        itemParaAtualizar.quantidadeAdquirida = (int)numQtdAdquirida.Value;
                        itemParaAtualizar.precoUnitario = precoUnitario;
                        itemParaAtualizar.DataAlteracao = DateTime.Now;

                        var compra = context.compras.Find(_compraId);
                        if (compra != null) compra.DataAlteracao = DateTime.Now;

                        context.SaveChanges();
                    }
                }

                AtualizarGrelhaItens();
                CalcularOrcamentoDisponivel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                using (var context = new ShoppingContext())
                {
                    var compraAtual = context.compras.Find(_compraId);
                    var artigoSelecionado = context.artigos.Find(artigoId);

                    var novoItemExtra = new itemCompra
                    {
                        compra = compraAtual,
                        artigo = artigoSelecionado,
                        quantidadePrevista = 0, // Como é por impulso, a previsão era zero
                        quantidadeAdquirida = (int)numQtdExtra.Value,
                        precoUnitario = precoExtra,
                        IsPrevisto = false,
                        Observacoes = string.IsNullOrWhiteSpace(txtObservacoes.Text) ? "Compra por impulso" : txtObservacoes.Text,
                        DataCriacao = DateTime.Now,
                        DataAlteracao = DateTime.Now
                    };

                    context.itemCompras.Add(novoItemExtra);

                    if (compraAtual != null) compraAtual.DataAlteracao = DateTime.Now;

                    context.SaveChanges();
                }

                txtPrecoExtra.Clear();
                txtObservacoes.Clear();
                numQtdExtra.Value = 1;

                AtualizarGrelhaItens();
                CalcularOrcamentoDisponivel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir artigo não previsto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularOrcamentoDisponivel()
        {
            try
            {
                using (var context = new ShoppingContext())
                {
                    int mesAtual = DateTime.Now.Month;
                    int anoAtual = DateTime.Now.Year;

                    // Ajustado para lidar com DateTime da propriedade "mes"
                    var orcamentoMes = context.orcamentos
                        .FirstOrDefault(o => o.mes.Month == mesAtual && o.mes.Year == anoAtual);

                    decimal valorDisponivel = orcamentoMes != null ? orcamentoMes.valor_max : 250.00m;

                    // Somatório do que já foi gasto em todos os itens do carrinho
                    decimal totalGastoCompra = context.itemCompras
                        .Where(i => i.compra.id == _compraId)
                        .Sum(i => (decimal?)(i.quantidadeAdquirida * i.precoUnitario)) ?? 0;

                    decimal saldoFinal = valorDisponivel - totalGastoCompra;

                    lblOrcamentoDisponivel.Text = $"Saldo Disponível: {saldoFinal.ToString("C2", CultureInfo.GetCultureInfo("pt-PT"))}";

                    if (saldoFinal < 0)
                        lblOrcamentoDisponivel.ForeColor = System.Drawing.Color.Red;
                    else
                        lblOrcamentoDisponivel.ForeColor = System.Drawing.Color.ForestGreen;
                }
            }
            catch (Exception)
            {
                lblOrcamentoDisponivel.Text = "Saldo Disponível: Indisponível";
            }
        }

        private void BtnFecharCompra_Click(object sender, EventArgs e)
        {
            var confirmacao = MessageBox.Show("Tem a certeza de que deseja finalizar e fechar esta compra? Não poderá efetuar mais alterações.",
                "Confirmar Fecho", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                try
                {
                    using (var context = new ShoppingContext())
                    {
                        var compra = context.compras.Find(_compraId);
                        if (compra != null)
                        {
                            compra.estado = Estado.fechado; // Ajustado para usar o enum
                            compra.DataAlteracao = DateTime.Now;
                            compra.dataFechar = DateTime.Now; // Regista a data exata do fecho
                            context.SaveChanges();
                        }
                    }

                    MessageBox.Show("Compra concluída com sucesso! Carrinho fechado.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao fechar a compra: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}