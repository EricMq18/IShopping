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
            var user = new user { username = "admin", password = "admin" };
            context.users.Add(user);

            var categoriaComida = new TipoArtigo { Categoria = "Comida" };
            context.tipos.Add(categoriaComida);

            var artigoTeste = new Artigo { Nome = "Arroz", TipoArtigo = categoriaComida };
            context.artigos.Add(artigoTeste);

            var compraAberta = new Compra
            {
                nome = "Compras Mensais Continente",
                estado = Estado.aberto,
                dataCriacao = DateTime.Now,
                DataAlteracao = DateTime.Now,
                userCriador = user
            };                      
            context.compras.Add(compraAberta);

            var item = new itemCompra
            {
                compra = compraAberta,   
                artigo = artigoTeste,    
                quantidadePrevista = 4,
                quantidadeAdquirida = 0,
                precoUnitario = 1.10m,
                IsPrevisto = true,
                userCriador = user,
                userAlterador = user
            };                       
            context.itemCompras.Add(item);

            var orcamento = new orcamento
            {
                mes = DateTime.Now,
                userCriador = user,
                valor_max = 1.1m
            };
            context.orcamentos.Add(orcamento);

            context.SaveChanges();

            base.Seed(context);
        }

    }
}
