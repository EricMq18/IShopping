using IShopping.Controller;
using IShopping.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IShopping.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            int userId = new UserController().UtilizadorValido(txtUser.Text, txtPass.Text);

            if (userId != -1)
            {
                // Define a sessão global antes de abrir o painel principal
                Program.UtilizadorLogadoId = userId;
                Program.UtilizadorLogadoNome = txtUser.Text;

                Program.forms(this, new FormPrincipal(userId, txtUser.Text));
            }
            else
            {
                MessageBox.Show("Credenciais inválidas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            int userId = new UserController().UtilizadorValido(txtUser.Text, txtPass.Text);

            if (userId == -1)
            {
                new UserController().registarUser(txtUser.Text, txtPass.Text);
                MessageBox.Show("Registo Efetuado com sucesso");
            }
            else
            {
                MessageBox.Show("Credenciais inválidas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
