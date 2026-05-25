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
    public partial class GestaoCategorias : Form
    {
        private CategoriaController _controller;
        private int idCategoriaSelecionada = 0;

        public GestaoCategorias()
        {
            InitializeComponent();
            _controller = new CategoriaController();
        }

        private void GestaoCategorias_Load_1(object sender, EventArgs e)
        {
            CarregarCategorias();
        }

        private void CarregarCategorias()
        {
            lstCategorias.DataSource = null;
            lstCategorias.DataSource = _controller.ObterCategorias();
            lstCategorias.DisplayMember = "Categoria";
            lstCategorias.ValueMember = "Id";

            // Adiciona esta linha para não selecionar a primeira categoria:
            lstCategorias.ClearSelected();
        }

        // NOVO EVENTO: Substitui o CellClick
        private void lstCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCategorias.SelectedItem != null && lstCategorias.SelectedValue is int)
            {
                // Guarda o ID
                idCategoriaSelecionada = (int)lstCategorias.SelectedValue;

                // Converte o item selecionado de volta para "TipoArtigo" para ler o nome
                var tipoSelecionado = (TipoArtigo)lstCategorias.SelectedItem;
                txtNameCategoria.Text = tipoSelecionado.Categoria;
            }
        }

        private void btnAddCategoria_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNameCategoria.Text)) return;

            _controller.AdicionarCategoria(txtNameCategoria.Text);

            LimparFormulario();
            CarregarCategorias();
        }

        private void btnEditCategoria_Click(object sender, EventArgs e)
        {
            if (idCategoriaSelecionada == 0 || string.IsNullOrWhiteSpace(txtNameCategoria.Text)) return;

            _controller.AtualizarCategoria(idCategoriaSelecionada, txtNameCategoria.Text);

            LimparFormulario();
            CarregarCategorias();
        }

        private void btnDeleteCategoria_Click(object sender, EventArgs e)
        {
            if (idCategoriaSelecionada == 0) return;

            _controller.EliminarCategoria(idCategoriaSelecionada);

            LimparFormulario();
            CarregarCategorias();
        }

        private void LimparFormulario()
        {
            txtNameCategoria.Clear();
            idCategoriaSelecionada = 0;
            lstCategorias.ClearSelected(); // Tira a seleção visual da lista
        }

    }
}