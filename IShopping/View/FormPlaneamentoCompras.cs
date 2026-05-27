using IShopping.Model;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace IShopping.View
{
    public partial class FormPlaneamentoCompras : Form
    {
        private int _utilizadorId;

        public FormPlaneamentoCompras(int utilizadorId)
        {
            InitializeComponent();
            _utilizadorId = utilizadorId;
        }

        private void FormPlaneamentoCompras_Load(object sender, EventArgs e)
        {
            if (cmbFiltroEstado.Items.Count > 0)
            {
                cmbFiltroEstado.SelectedIndex = 0;
            }

            AtualizarGrelhaCompras();
        }

        private void CmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarGrelhaCompras();
        }

        private void AtualizarGrelhaCompras()
        {
            try
            {
                using (var context = new ShoppingContext())
                {
                    var query = context.compras.Include("userCriador").AsQueryable();

                    if (cmbFiltroEstado.SelectedItem != null)
                    {
                        string filtro = cmbFiltroEstado.SelectedItem.ToString();

                        if (filtro == "Abertas")
                        {
                            query = query.Where(c => c.estado == Estado.aberto);
                        }
                        else if (filtro == "Fechadas")
                        {
                            query = query.Where(c => c.estado == Estado.fechado);
                        }
                    }

                    var listaCompras = query.Select(c => new
                    {
                        ID = c.id,
                        Nome = c.nome,
                        Estado = c.estado.ToString(),
                        Data_Criacao = c.dataCriacao,
                        Data_Alteracao = c.DataAlteracao, // <-- A tua nova coluna aqui!
                        Criador = c.userCriador != null ? c.userCriador.username : "Desconhecido"
                    }).ToList();

                    dgvCompras.DataSource = listaCompras;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar a lista de compras: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNovaCompra_Click(object sender, EventArgs e)
        {
            var formCriacao = new FormCriacaoCompra(_utilizadorId);
            formCriacao.ShowDialog();

            AtualizarGrelhaCompras();
        }

        private void BtnEditarCompra_Click(object sender, EventArgs e)
        {
            if (dgvCompras.CurrentRow != null)
            {
                int compraIdSelecionada = (int)dgvCompras.CurrentRow.Cells["ID"].Value;

                var formCriacao = new FormCriacaoCompra(_utilizadorId, compraIdSelecionada);
                formCriacao.ShowDialog();

                AtualizarGrelhaCompras();
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma compra na lista para ver ou editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}