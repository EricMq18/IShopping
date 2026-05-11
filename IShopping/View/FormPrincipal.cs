using System;
using System.Windows.Forms;

namespace IShopping.View
{
    public partial class FormPrincipal : Form
    {
        // Variável para armazenar o ID do utilizador logado conforme requisito 3.a 
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
            // Placeholder para ligação dos forms específicos conforme pedido
            Form formDestino = null;

            switch (tipo)
            {
                case "Utilizadores":
                    //formDestino = new FormUtilizadores(); 
                    break;
                case "TiposArtigo":
                    // formDestino = new FormTiposArtigo(); 
                    break;
                case "Artigos":
                    // formDestino = new FormArtigos(); 
                    break;
                case "Orcamentos":
                    // formDestino = new FormOrcamentos(); 
                    break;
                case "Planeamento":
                    // formDestino = new FormPlaneamento(); 
                    break;
                case "ModoCompra":
                    // formDestino = new FormModoCompra(compraId); 
                    break;
                case "Estatisticas":
                    // formDestino = new FormEstatisticas();
                    break;
            }

            if (formDestino != null)
            {
                formDestino.ShowDialog();
                AtualizarListaComprasAbertas(); // Atualiza a lista caso algo tenha mudado
            }
        }
    }
}