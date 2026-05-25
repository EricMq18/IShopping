using IShopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IShopping.Controller
{
    public class ArtigoController
    {
        // Alterado para servir a ListBox
        public object ObterArtigosParaLista(int idTipoFiltro, string termoPesquisa = "")
        {
            using (var db = new ShoppingContext())
            {
                var query = db.artigos.Include(a => a.TipoArtigo).AsQueryable();

                // 1. Filtro pela ComboBox (Categoria)
                if (idTipoFiltro > 0)
                {
                    query = query.Where(a => a.TipoArtigoId == idTipoFiltro);
                }

                // 2. NOVO: Filtro pela TextBox (Texto Parcial)
                // Só filtra se a caixa de texto não estiver vazia
                if (!string.IsNullOrWhiteSpace(termoPesquisa))
                {
                    // O .Contains() encontra artigos que tenham aquele texto em qualquer parte do nome
                    query = query.Where(a => a.Nome.Contains(termoPesquisa));
                }

                return query.Select(a => new
                {
                    a.Id,
                    DisplayText = a.Nome + " (" + a.TipoArtigo.Categoria + ")"
                }).ToList();
            }
        }

        // NOVO: Para nos ajudar a ler os dados para as caixas de texto ao clicar na lista
        public Artigo ObterArtigoPorId(int id)
        {
            using (var db = new ShoppingContext())
            {
                return db.artigos.FirstOrDefault(a => a.Id == id);
            }
        }

        public void AdicionarArtigo(string nome, int categoriaId)
        {
            using (var db = new ShoppingContext())
            {
                db.artigos.Add(new Artigo { Nome = nome, TipoArtigoId = categoriaId });
                db.SaveChanges();
            }
        }

        public void AtualizarArtigo(int id, string novoNome, int novaCategoriaId)
        {
            using (var db = new ShoppingContext())
            {
                var artigo = db.artigos.FirstOrDefault(a => a.Id == id);
                if (artigo != null)
                {
                    artigo.Nome = novoNome;
                    artigo.TipoArtigoId = novaCategoriaId;
                    db.SaveChanges();
                }
            }
        }

        public void EliminarArtigo(int id)
        {
            using (var db = new ShoppingContext())
            {
                var artigo = db.artigos.FirstOrDefault(a => a.Id == id);
                if (artigo != null)
                {
                    db.artigos.Remove(artigo);
                    db.SaveChanges();
                }
            }
        }
    }
}