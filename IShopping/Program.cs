using IShopping.Controller;
using IShopping.Model;
using IShopping.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IShopping
{
    internal static class Program
    {
        public static int UtilizadorLogadoId { get; set; }
        public static string UtilizadorLogadoNome { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Database.SetInitializer(new AppDbInitializer());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GestaoOrcamento());
        }

        public static void forms(Form formAtual, Form formNovo)
        {
            formAtual.Hide();
            formNovo.ShowDialog();
            formAtual.Close();
        }
    }
}
