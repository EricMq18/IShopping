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
            // Pede as categorias ao CategoriaController
            var categoriasParaFormulario = _categoriaController.ObterCategorias();

            // 1. ComboBox de Adicionar/Editar Artigo
            cbSelectCategoria.DataSource = categoriasParaFormulario;
            cbSelectCategoria.DisplayMember = "Categoria";
            cbSelectCategoria.ValueMember = "Id";

            // 2. ComboBox do Filtro (Topo) - Precisamos de adicionar a opção "Todos"
            // Fazemos uma nova lista para não misturar com a ComboBox de baixo
            var categoriasParaFiltro = _categoriaController.ObterCategorias();
            categoriasParaFiltro.Insert(0, new TipoArtigo { Id = 0, Categoria = "Todos" });

            cbPesquisar.DataSource = categoriasParaFiltro;
            cbPesquisar.DisplayMember = "Categoria";
            cbPesquisar.ValueMember = "Id";
        }

        private void CarregarArtigos(int idTipoFiltro)
        {
            dgvArtigos.DataSource = null;
            // Pede os dados formatados ao ArtigoController
            dgvArtigos.DataSource = _artigoController.ObterArtigosParaGrelha(idTipoFiltro);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisar.SelectedValue != null)
            {
                int idFiltro = (int)cbPesquisar.SelectedValue;
                CarregarArtigos(idFiltro);
            }
        }

        private void dgvArtigos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Guarda o ID e preenche os campos
                idArtigoSelecionado = (int)dgvArtigos.Rows[e.RowIndex].Cells["Id"].Value;
                txtNameArtigo.Text = dgvArtigos.Rows[e.RowIndex].Cells["Nome"].Value.ToString();

                // Tenta selecionar a categoria correta na ComboBox com base no nome que está na grelha
                string nomeCategoria = dgvArtigos.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();
                cbSelectCategoria.SelectedIndex = cbSelectCategoria.FindStringExact(nomeCategoria);
            }
        }

        private void btnAddArtigo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNameArtigo.Text) || cbSelectCategoria.SelectedValue == null)
            {
                MessageBox.Show("Preencha o nome e selecione uma categoria.");
                return;
            }   

            // Delega para o Controller
            _artigoController.AdicionarArtigo(txtNameArtigo.Text, (int)cbSelectCategoria.SelectedValue);

            LimparFormulario();
            CarregarArtigos((int)cbPesquisar.SelectedValue); // Mantém o filtro atual
        }

        private void btnEditArtigo_Click(object sender, EventArgs e)
        {
            if (idArtigoSelecionado == 0 || string.IsNullOrWhiteSpace(txtNameArtigo.Text)) return;

            // Assumindo que tens um método AtualizarArtigo no teu controller
            _artigoController.AtualizarArtigo(idArtigoSelecionado, txtNameArtigo.Text, (int)cbSelectCategoria.SelectedValue);

            LimparFormulario();
            CarregarArtigos((int)cbPesquisar.SelectedValue);
        }

        private void btnDeleteArtigo_Click(object sender, EventArgs e)
        {
            if (idArtigoSelecionado == 0) return;

            // Delega para o Controller
            _artigoController.EliminarArtigo(idArtigoSelecionado);

            LimparFormulario();
            CarregarArtigos((int)cbPesquisar.SelectedValue);
        }

        private void LimparFormulario()
        {
            txtNameArtigo.Clear();
            idArtigoSelecionado = 0;
            if (cbSelectCategoria.Items.Count > 0) cbSelectCategoria.SelectedIndex = 0;
        }

    }
}
