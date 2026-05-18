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
            var userAdmin = new user { username = "admin", password = "admin" };
            context.users.Add(userAdmin);
            context.SaveChanges();

            var categoriaComida = new TipoArtigo { Categoria = "Comida" };
            context.tipos.Add(categoriaComida);
            context.SaveChanges();

            var artigoTeste = new Artigo { Nome = "Arroz", TipoArtigoId = categoriaComida.Id };
            context.artigos.Add(artigoTeste);
            context.SaveChanges();
            
            var orcamentoMensal = new orcamento
            {
                mes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                valor_max = 300.00m,
                CriadoPorUserId = userAdmin.id,
                AlteradoPorUserId = userAdmin.id
            };
            context.orcamentos.Add(orcamentoMensal);
            context.SaveChanges();

            var compraAberta = new Compra
            {
                nome = "Compras Mensais",
                estado = Estado.aberto,
                dataCriacao = DateTime.Now,
                DataAlteracao = DateTime.Now,
                CriadoPorUserId = userAdmin.id
            };
            context.compras.Add(compraAberta);
            context.SaveChanges();

            var item = new itemCompra
            {
                CompraID = compraAberta.id,
                ArtigoId = artigoTeste.Id,
                quantidadePrevista = 4,
                quantidadeAdquirida = 0,
                precoUnitario = 1.10m,
                IsPrevisto = true,
                CriadoPorUserId = userAdmin.id,
                AlteradoPorUserId = userAdmin.id
            };
            context.itemCompras.Add(item);            
            context.SaveChanges();

            base.Seed(context);
        }

    }
}
