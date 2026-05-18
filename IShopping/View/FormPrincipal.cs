using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IShopping
{
    public partial class FormPrincipal : Form
    {
        private int userId;       
        public FormPrincipal()
        {
            InitializeComponent();
        }

        public FormPrincipal(int userId, string text)
        {            
            this.userId = userId;
            Text = text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
