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
        private CategoriaController _controller; // Instância do Controller
        private int idCategoriaSelecionada = 0;

        public GestaoCategorias()
        {
            InitializeComponent();
            _controller = new CategoriaController(); // Inicializar o controller
        }

        private void GestaoCategorias_Load_1(object sender, EventArgs e)
        {
            CarregarCategorias();
        }

        private void CarregarCategorias()
        {
            dgvCategorias.DataSource = null;
            // A View pede os dados ao Controller!
            dgvCategorias.DataSource = _controller.ObterCategorias();
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idCategoriaSelecionada = (int)dgvCategorias.Rows[e.RowIndex].Cells["Id"].Value;
                txtNameCategoria.Text = dgvCategorias.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();
            }
        }

        private void btnAddCategoria_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNameCategoria.Text)) return;

            _controller.AdicionarCategoria(txtNameCategoria.Text); // Delega para o Controller

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
        }

    }   
}
