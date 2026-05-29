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
            var users = new List<user>
            {
                new user { username = "admin", password = "admin" },
                new user { username = "eric", password = "123" },
                new user { username = "martim", password = "123" },
                new user { username = "dinis", password = "123" },
                new user { username = "maria", password = "123" },
                new user { username = "joao", password = "123" },
                new user { username = "ana", password = "123" },
                new user { username = "pedro", password = "123" },
                new user { username = "sara", password = "123" },
                new user { username = "rui", password = "123" },
                new user { username = "carlos", password = "123" }
            };
            context.users.AddRange(users);

            var categorias = new List<TipoArtigo>
            {
                new TipoArtigo { Categoria = "Comida" },
                new TipoArtigo { Categoria = "Higiene Pessoal" },
                new TipoArtigo { Categoria = "Limpeza Doméstica" },
                new TipoArtigo { Categoria = "Talho" },
                new TipoArtigo { Categoria = "Peixaria" },
                new TipoArtigo { Categoria = "Frutaria" },
                new TipoArtigo { Categoria = "Padaria / Pastelaria" },
                new TipoArtigo { Categoria = "Congelados" },
                new TipoArtigo { Categoria = "Bebidas" },
                new TipoArtigo { Categoria = "Laticínios" },
                new TipoArtigo { Categoria = "Snacks" }
            };
            context.tipos.AddRange(categorias);

            var artigos = new List<Artigo>
            {
                new Artigo { Nome = "Arroz", TipoArtigo = categorias[0] },
                new Artigo { Nome = "Gel de Banho Doce", TipoArtigo = categorias[1] },
                new Artigo { Nome = "Lixívia Perfumada", TipoArtigo = categorias[2] },
                new Artigo { Nome = "Bife de Peru", TipoArtigo = categorias[3] },
                new Artigo { Nome = "Posta de Salmão", TipoArtigo = categorias[4] },
                new Artigo { Nome = "Maçã Riscadinha", TipoArtigo = categorias[5] },
                new Artigo { Nome = "Pão de Forma Integral", TipoArtigo = categorias[6] },
                new Artigo { Nome = "Douradinhos 15 un.", TipoArtigo = categorias[7] },
                new Artigo { Nome = "Água Mineral 1.5L", TipoArtigo = categorias[8] },
                new Artigo { Nome = "Leite Meio Gordo", TipoArtigo = categorias[9] },
                new Artigo { Nome = "Batatas Fritas", TipoArtigo = categorias[10] }
            };
            context.artigos.AddRange(artigos);

            var orcamentos = new List<orcamento>
            {
                new orcamento { mes = DateTime.Now, userCriador = users[0], valor_max = 1.1m }
            };
            for (int i = 1; i <= 10; i++)
            {
                orcamentos.Add(new orcamento
                {
                    mes = new DateTime(DateTime.Now.Year, i, 1),
                    valor_max = 200m + (i * 15.5m),
                    userCriador = users[0],
                    userAlterador = users[0]
                });
            }
            context.orcamentos.AddRange(orcamentos);

            var compras = new List<Compra>
            {
                new Compra { nome = "Compras Mensais Continente", estado = Estado.aberto, dataCriacao = DateTime.Now, DataAlteracao = DateTime.Now, userCriador = users[0] },
                new Compra { nome = "Compras Mensais FECHADO Continente", estado = Estado.fechado, dataCriacao = DateTime.Now, DataAlteracao = DateTime.Now, userCriador = users[0] }
            };
            for (int i = 1; i <= 10; i++)
            {
                bool isFechado = (i % 2 == 0);
                compras.Add(new Compra
                {
                    nome = $"Compra Adicional {i}",
                    estado = isFechado ? Estado.fechado : Estado.aberto,
                    dataCriacao = DateTime.Now.AddDays(-i * 5),
                    DataAlteracao = DateTime.Now.AddDays(-i * 2),
                    dataFechar = isFechado ? (DateTime?)DateTime.Now.AddDays(-i * 1) : null,
                    userCriador = users[i % 3 + 1],
                    userFechou = isFechado ? users[0] : null
                });
            }
            context.compras.AddRange(compras);

            var itensPrevistos = new List<ArtigoPrevisto>
            {
                new ArtigoPrevisto { compra = compras[0], artigo = artigos[0], qntPrevista = 4, quantidadeAdquirida = 0, precoUnitario = 1.10m, userCriador = users[0], userAlterador = users[0] }
            };
            for (int i = 0; i < 10; i++)
            {
                itensPrevistos.Add(new ArtigoPrevisto
                {
                    compra = compras[i + 2],
                    artigo = artigos[i + 1],
                    qntPrevista = (i % 3) + 2,
                    quantidadeAdquirida = compras[i + 2].estado == Estado.fechado ? ((i % 3) + 2) : 0,
                    precoUnitario = 1.10m + (i * 0.45m),
                    DataCriacao = DateTime.Now,
                    DataAlteracao = DateTime.Now,
                    userCriador = users[0],
                    userAlterador = users[0]
                });
            }
            context.itemCompras.AddRange(itensPrevistos);

            var itensNaoPrevistos = new List<ArtigoNaoPrevisto>();
            for (int i = 0; i < 10; i++)
            {
                itensNaoPrevistos.Add(new ArtigoNaoPrevisto
                {
                    compra = compras[i + 2],
                    artigo = artigos[(i + 2) % artigos.Count],
                    descricao = $"Desejo do momento {i + 1}",
                    quantidadeAdquirida = 1 + (i % 2),
                    precoUnitario = 2.00m + (i * 1.20m),
                    DataCriacao = DateTime.Now,
                    DataAlteracao = DateTime.Now,
                    userCriador = users[1],
                    userAlterador = users[1]
                });
            }
            context.itemCompras.AddRange(itensNaoPrevistos);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
