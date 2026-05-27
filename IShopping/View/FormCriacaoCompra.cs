using IShopping.Model;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace IShopping.View
{
    public partial class FormCriacaoCompra : Form
    {
        private int _utilizadorId;
        private int _compraId;
        private bool _modoLeitura;

        // Construtor 1 para nova compra
        public FormCriacaoCompra(int utilizadorId)
        {
            InitializeComponent();
            _utilizadorId = utilizadorId;
            _compraId = 0; // 0 significa que ainda não foi guardada na Base de Dados
            _modoLeitura = false;
        }

        // Construtor 2 para editar compra existente
        public FormCriacaoCompra(int utilizadorId, int compraId)
        {
            InitializeComponent();
            _utilizadorId = utilizadorId;
            _compraId = compraId;
            _modoLeitura = false;
        }

        private void FormCriacaoCompra_Load(object sender, EventArgs e)
        {
            CarregarTiposArtigo();

            if (_compraId != 0)
            {
                CarregarDadosCompra();
            }
            else
            {
                txtNomeCompra.Text = $"Nova Lista - {DateTime.Now.ToString("dd/MM/yyyy")}";
            }
        }

        private void CarregarTiposArtigo()
        {
            try
            {
                using (var context = new ShoppingContext())
                {
                    cmbTipoArtigo.DataSource = context.tipos.ToList();
                    cmbTipoArtigo.DisplayMember = "Categoria";
                    cmbTipoArtigo.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar categorias: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbTipoArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoArtigo.SelectedValue != null && int.TryParse(cmbTipoArtigo.SelectedValue.ToString(), out int tipoId))
            {
                try
                {
                    using (var context = new ShoppingContext())
                    {
                        var artigosFiltrados = context.artigos.Where(a => a.TipoArtigoId == tipoId).ToList();

                        if (artigosFiltrados.Count > 0)
                        {
                            cmbArtigo.DataSource = artigosFiltrados;
                            cmbArtigo.DisplayMember = "Nome";
                            cmbArtigo.ValueMember = "Id";
                        }
                        else
                        {
                            cmbArtigo.DataSource = null;
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        private void CarregarDadosCompra()
        {
            using (var context = new ShoppingContext())
            {
                var compra = context.compras.Find(_compraId);
                if (compra != null)
                {
                    txtNomeCompra.Text = compra.nome;

                    if (compra.estado == Estado.fechado)
                    {
                        _modoLeitura = true;
                        DesativarControlosParaLeitura();
                    }

                    AtualizarGrelhaItens();
                }
            }
        }

        private void DesativarControlosParaLeitura()
        {
            txtNomeCompra.Enabled = false;
            cmbTipoArtigo.Enabled = false;
            cmbArtigo.Enabled = false;
            numQuantidadePrevista.Enabled = false;
            btnAdicionarItem.Enabled = false;
            btnRemoverItem.Enabled = false;
            btnGuardarCompra.Enabled = false;
            this.Text += " (Modo Leitura - Fechada)";
        }

        private void BtnAdicionarItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomeCompra.Text))
            {
                MessageBox.Show("Por favor, dê um nome à lista antes de adicionar artigos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbArtigo.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecione um artigo válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new ShoppingContext())
                {
                    Compra compraAtual;

                    // Se a lista ainda não existe, cria-a silenciosamente primeiro
                    if (_compraId == 0)
                    {
                        var utilizadorAtual = context.users.Find(_utilizadorId);
                        compraAtual = new Compra
                        {
                            nome = txtNomeCompra.Text.Trim(),
                            estado = Estado.aberto,
                            dataCriacao = DateTime.Now,
                            DataAlteracao = DateTime.Now,
                            userCriador = utilizadorAtual
                        };

                        context.compras.Add(compraAtual);
                        context.SaveChanges();
                        _compraId = compraAtual.id;
                    }
                    else
                    {
                        compraAtual = context.compras.Find(_compraId);
                    }

                    int artigoId = (int)cmbArtigo.SelectedValue;
                    var artigoSelecionado = context.artigos.Find(artigoId);
                    var utilizadorAcao = context.users.Find(_utilizadorId);

                    var novoItem = new itemCompra
                    {
                        compra = compraAtual,
                        artigo = artigoSelecionado,
                        quantidadePrevista = (int)numQuantidadePrevista.Value,
                        quantidadeAdquirida = 0,
                        precoUnitario = 0,
                        IsPrevisto = true,
                        DataCriacao = DateTime.Now,
                        DataAlteracao = DateTime.Now,
                        userCriador = utilizadorAcao
                    };

                    context.itemCompras.Add(novoItem);
                    if (compraAtual != null) compraAtual.DataAlteracao = DateTime.Now;
                    context.SaveChanges();
                }

                numQuantidadePrevista.Value = 1;
                AtualizarGrelhaItens();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRemoverItem_Click(object sender, EventArgs e)
        {
            if (dgvItensPlaneados.CurrentRow != null && !_modoLeitura)
            {
                try
                {
                    int itemId = (int)dgvItensPlaneados.CurrentRow.Cells["ID"].Value;

                    using (var context = new ShoppingContext())
                    {
                        var itemParaRemover = context.itemCompras.Find(itemId);
                        if (itemParaRemover != null)
                        {
                            context.itemCompras.Remove(itemParaRemover);

                            var compra = context.compras.Find(_compraId);
                            if (compra != null) compra.DataAlteracao = DateTime.Now;

                            context.SaveChanges();
                        }
                    }
                    AtualizarGrelhaItens();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (dgvItensPlaneados.CurrentRow == null)
            {
                MessageBox.Show("Selecione um artigo na tabela para o remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AtualizarGrelhaItens()
        {
            if (_compraId == 0) return;

            try
            {
                using (var context = new ShoppingContext())
                {
                    var itensPlaneados = context.itemCompras
                                       .Include(i => i.artigo)
                                       .Where(i => i.compra.id == _compraId && i.IsPrevisto == true)
                                       .Select(i => new
                                       {
                                           ID = i.id,
                                           Produto = i.artigo != null ? i.artigo.Nome : "Desconhecido",
                                           Qtd_Prevista = i.quantidadePrevista
                                       }).ToList();

                    dgvItensPlaneados.DataSource = itensPlaneados;
                }
            }
            catch (Exception) { }
        }

        private void BtnGuardarCompra_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomeCompra.Text))
            {
                MessageBox.Show("O nome da lista não pode estar vazio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new ShoppingContext())
                {
                    if (_compraId == 0)
                    {
                        var utilizadorAtual = context.users.Find(_utilizadorId);
                        var novaCompra = new Compra
                        {
                            nome = txtNomeCompra.Text.Trim(),
                            estado = Estado.aberto,
                            dataCriacao = DateTime.Now,
                            DataAlteracao = DateTime.Now,
                            userCriador = utilizadorAtual
                        };
                        context.compras.Add(novaCompra);
                        context.SaveChanges();
                    }
                    else if (!_modoLeitura)
                    {
                        var compraExistente = context.compras.Find(_compraId);
                        if (compraExistente != null)
                        {
                            compraExistente.nome = txtNomeCompra.Text.Trim();
                            compraExistente.DataAlteracao = DateTime.Now;
                            context.SaveChanges();
                        }
                    }
                }

                MessageBox.Show("Lista de compras guardada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao guardar a lista: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método que é chamado quando clicas numa linha da grelha
        private void DgvItensPlaneados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvItensPlaneados.CurrentRow != null && !_modoLeitura)
            {
                try
                {
                    int itemId = (int)dgvItensPlaneados.CurrentRow.Cells["ID"].Value;

                    using (var context = new ShoppingContext())
                    {
                        var item = context.itemCompras.Include(i => i.artigo).FirstOrDefault(i => i.id == itemId);

                        if (item != null && item.artigo != null)
                        {
                            // Puxa os dados para cima para o utilizador editar
                            cmbTipoArtigo.SelectedValue = item.artigo.TipoArtigoId;
                            cmbArtigo.SelectedValue = item.artigo.Id;
                            numQuantidadePrevista.Value = item.quantidadePrevista;
                        }
                    }
                }
                catch { }
            }
        }

        // Método que é chamado quando clicas no botão "Atualizar Selecionado"
        private void BtnAtualizarItem_Click(object sender, EventArgs e)
        {
            if (dgvItensPlaneados.CurrentRow == null)
            {
                MessageBox.Show("Selecione um artigo na tabela primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int itemId = (int)dgvItensPlaneados.CurrentRow.Cells["ID"].Value;
                int novoArtigoId = (int)cmbArtigo.SelectedValue;

                using (var context = new ShoppingContext())
                {
                    var itemParaAtualizar = context.itemCompras.Find(itemId);
                    var novoArtigo = context.artigos.Find(novoArtigoId);

                    if (itemParaAtualizar != null && novoArtigo != null)
                    {
                        itemParaAtualizar.artigo = novoArtigo;
                        itemParaAtualizar.quantidadePrevista = (int)numQuantidadePrevista.Value;
                        itemParaAtualizar.DataAlteracao = DateTime.Now;

                        var compra = context.compras.Find(_compraId);
                        if (compra != null) compra.DataAlteracao = DateTime.Now;

                        context.SaveChanges();
                    }
                }

                AtualizarGrelhaItens();
                MessageBox.Show("Artigo atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar item: {ex.Message}");
            }
        }
    }
}