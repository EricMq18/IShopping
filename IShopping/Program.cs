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
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Database.SetInitializer(new AppDbInitializer());
            using (var db = new ShoppingContext())
            {
                var User = new user { username = "tester", password = "12345" };
                var Tipo = new TipoArtigo { Categoria = "Teste" };
                var Compra = new Compra { DataAlteracao = DateTime.Now, dataCriacao = DateTime.Now, dataFechar = DateTime.Now, estado = Estado.fechado, nome = "Teste2" };
                //Verificar Se Existe o Item correspondente
                bool existe = db.users.Any(c => c.username == User.username && c.password == User.password);
                bool existe2 = db.tipos.Any(c => c.Categoria == Tipo.Categoria && c.Categoria == Tipo.Categoria);
                
                if (!existe && !existe2)
                {
                    db.users.Add(User);
                    db.tipos.Add(Tipo);
                    db.SaveChanges();
                }
            }



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GestaoCategorias());
        }

        public static void forms(Form formAtual, Form formNovo)
        {
            formAtual.Hide();
            formNovo.ShowDialog();
            formAtual.Close();
        }
    }
}
