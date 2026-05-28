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
    public partial class GestaoArtigos : Form
    {
        private ArtigoController _artigoController;
        private CategoriaController _categoriaController;

        private int idArtigoSelecionado = 0;

        public GestaoArtigos()
        {
            InitializeComponent();
            _artigoController = new ArtigoController();
            _categoriaController = new CategoriaController();            
        }

        private void GestaoArtigos_Load(object sender, EventArgs e)
        {
            CarregarComboBoxes();
            CarregarArtigos(0); // 0 = Todos
        }
        
        private void CarregarComboBoxes()
        {
            var categoriasParaFormulario = _categoriaController.ObterCategorias();

            cbSelectCategoria.DataSource = categoriasParaFormulario;
            cbSelectCategoria.DisplayMember = "Categoria";
            cbSelectCategoria.ValueMember = "Id";

            var categoriasParaFiltro = _categoriaController.ObterCategorias();
            categoriasParaFiltro.Insert(0, new TipoArtigo { Id = 0, Categoria = "Todos" });

            cbPesquisar.DataSource = categoriasParaFiltro;
            cbPesquisar.DisplayMember = "Categoria";
            cbPesquisar.ValueMember = "Id";
        }

        private void CarregarArtigos(int idTipoFiltro, string termoPesquisa = "")
        {
            lstArtigos.DataSource = null;

            // Passamos o ID e o Texto para o Controller
            lstArtigos.DataSource = _artigoController.ObterArtigosParaLista(idTipoFiltro, termoPesquisa);
            lstArtigos.DisplayMember = "DisplayText";
            lstArtigos.ValueMember = "Id";

            // NOVO: Remove o destaque/seleção do primeiro item da lista
            lstArtigos.ClearSelected();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            int idFiltro = 0;

            // Vê qual é a categoria selecionada (se existir)
            if (cbPesquisar.SelectedValue != null)
            {
                idFiltro = (int)cbPesquisar.SelectedValue;
            }

            // Lê o texto que o utilizador escreveu (Muda 'txtPesquisa' para o nome da tua caixa de texto!)
            string textoPesquisa = txtPesquisar.Text;

            // Chama a função com os dois filtros
            CarregarArtigos(idFiltro, textoPesquisa);
        }

        // NOVO EVENTO: Substitui o CellClick
        private void lstArtigos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstArtigos.SelectedItem != null && lstArtigos.SelectedValue is int)
            {
                idArtigoSelecionado = (int)lstArtigos.SelectedValue;

                // Vamos ao Controller buscar o nome real e a categoria para preencher os controlos
                var artigoDetalhe = _artigoController.ObterArtigoPorId(idArtigoSelecionado);
                if (artigoDetalhe != null)
                {
                    txtNameArtigo.Text = artigoDetalhe.Nome;
                    cbSelectCategoria.SelectedValue = artigoDetalhe.TipoArtigoId;
                }
            }
        }

        private void btnAddArtigo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNameArtigo.Text) || cbSelectCategoria.SelectedValue == null)
            {
                MessageBox.Show("Preencha o nome e selecione uma categoria.");
                return;
            }

            _artigoController.AdicionarArtigo(txtNameArtigo.Text, (int)cbSelectCategoria.SelectedValue);

            LimparFormulario();
            CarregarArtigos((int)cbPesquisar.SelectedValue);
        }

        private void btnEditArtigo_Click(object sender, EventArgs e)
        {
            if (idArtigoSelecionado == 0 || string.IsNullOrWhiteSpace(txtNameArtigo.Text)) return;

            _artigoController.AtualizarArtigo(idArtigoSelecionado, txtNameArtigo.Text, (int)cbSelectCategoria.SelectedValue);

            LimparFormulario();
            CarregarArtigos((int)cbPesquisar.SelectedValue);
        }

        private void btnDeleteArtigo_Click(object sender, EventArgs e)
        {
            if (idArtigoSelecionado == 0) return;

            _artigoController.EliminarArtigo(idArtigoSelecionado);

            LimparFormulario();
            CarregarArtigos((int)cbPesquisar.SelectedValue);
        }

        private void LimparFormulario()
        {
            txtNameArtigo.Clear();
            idArtigoSelecionado = 0;
            if (cbSelectCategoria.Items.Count > 0) cbSelectCategoria.SelectedIndex = 0;
            lstArtigos.ClearSelected(); // Tira a seleção visual da lista
        }

    }
}