using IShopping.Controller;
using System;
using System.Windows.Forms;

namespace IShopping.View
{
    public partial class FormEstatisticas : Form
    {
        private EstatisticasController _controller;

        public FormEstatisticas()
        {
            InitializeComponent();
            _controller = new EstatisticasController();
        }

        private void FormEstatisticas_Load(object sender, EventArgs e)
        {
            CarregarListagensGerais();
        }

        private void CarregarListagensGerais()
        {
            try
            {
                // Requisito 21.a: Orçamentos vs Gastos
                dgvOrcamentosMensais.DataSource = _controller.ObterEstatisticasOrcamentos();

                // Requisito 21.b: Percentagem de artigos previstos/não previstos
                dgvPercentagensCompras.DataSource = _controller.ObterEstatisticasComprasFechadas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar estatísticas: {ex.Message}");
            }
        }

        private void btnGerarSugestao_Click(object sender, EventArgs e)
        {
            try
            {
                // Requisito 21.c: Sugestão de Orçamento e Lista com base na semana do mês
                decimal orcamentoSugerido = _controller.CalcularOrcamentoSugerido();
                lblOrcamentoSugerido.Text = $"Orçamento Sugerido para o Próximo Mês: {orcamentoSugerido:C2}";

                dgvSugestaoCompras.DataSource = _controller.GerarListaSugestaoSemanal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar sugestões inteligentes: {ex.Message}");
            }
        }
    }
}