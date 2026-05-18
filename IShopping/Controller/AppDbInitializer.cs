using IShopping.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace IShopping.Controller
{
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<ShoppingContext>
    {
        protected override void Seed(ShoppingContext context)
        {
            // NÃO use 'using (var db = context)'. Use o 'context' que vem no parâmetro.
            var userAdmin = new user { username = "admin", password = "admin" };
            context.users.Add(userAdmin);

            var categoriaComida = new TipoArtigo { Categoria = "Comida" };
            context.tipos.Add(categoriaComida);

            var Compra = new Compra { DataAlteracao = DateTime.Now, dataCriacao = DateTime.Now, dataFechar = DateTime.Now, estado = Estado.fechado, nome = "Teste" };
            var itemCompra = new itemCompra { compra = Compra, CompraID = Compra.id, precoUnitario = 0, quantidadeAdquirida = 0 };
            context.SaveChanges();

            // O base.Seed deve ser chamado, mas geralmente é a última coisa
            base.Seed(context);
        }

    }
}
