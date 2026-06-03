using IShopping.Controller;
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
    public partial class UserForm : Form
    {
        private int _utilizadorId;
        public UserForm()
        {
            InitializeComponent();
        }

        public UserForm(int utilizadorId, string nomeUsuario)
        {
            InitializeComponent();
            lblUserAtual.Text = $"Usuario: {nomeUsuario}";
        }

        private void CarregarUsers()
        {
            lstUsers.DataSource = null;
            lstUsers.DisplayMember = "username";
            lstUsers.ValueMember = "Id";
            lstUsers.DataSource = new UserController().AtualizarLista();
            lstUsers.ClearSelected();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            CarregarUsers();
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUsers.SelectedItem != null)
            {
                txtUser.Text = lstUsers.GetItemText(lstUsers.SelectedItem);                
                dynamic usuario = lstUsers.SelectedItem;

                string senha = usuario.password;
                int idOculto = usuario.Id;
                txtPass.Text = senha;
            }
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            int userId = new UserController().UtilizadorValido(txtUser.Text, txtPass.Text);

            if (userId == -1)
            {
                new UserController().registarUser(txtUser.Text, txtPass.Text);
                CarregarUsers();
                MessageBox.Show("Registo Efetuado com sucesso");
            }
            else
            {
                MessageBox.Show("Credenciais inválidas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {            
            if (lstUsers.SelectedItem != null && lstUsers.SelectedValue is int idSelecionado)
            {                
                var confirmacao = MessageBox.Show("Tem a certeza que deseja eliminar este utilizador?",
                    "Confirmar Eliminação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacao == DialogResult.Yes)
                {
                    try
                    {                        
                        new UserController().eliminarUser(idSelecionado);                        
                        txtUser.Clear();
                        txtPass.Clear();
                        
                        CarregarUsers();

                        MessageBox.Show("Utilizador removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao remover utilizador: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um utilizador na lista para o remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
