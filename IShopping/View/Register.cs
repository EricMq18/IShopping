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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            int passar = new UserController().UtilizadorValido(txtNewUser.Text, txtNewPass.Text);

            if (passar == 0)
            {
                new UserController().registarUser(txtNewUser.Text, txtNewPass.Text);
                MessageBox.Show("Registo Efetuado com sucesso");
                Program.forms(this, new Login());
            }
        }
    }
}
