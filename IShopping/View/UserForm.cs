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
    }
}
