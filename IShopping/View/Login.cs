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
            int passar = new UserController().UtilizadorValido(txtUser.Text, txtPass.Text);

            if(passar == 1)
            {
                Program.forms(this, new FormPrincipal());
            }
        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            Program.forms(this, new Register());
        }
    }
}
