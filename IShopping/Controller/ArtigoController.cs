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
        
        public object ObterArtigosParaGrelha(int idTipoFiltro)
        {
            using (var db = new ShoppingContext())
            {
                var query = db.artigos.Include(a => a.TipoArtigo).AsQueryable();

                if (idTipoFiltro > 0)
                {
                    query = query.Where(a => a.TipoArtigoId == idTipoFiltro);
                }

                return query.Select(a => new
                {
                    a.Id,
                    a.Nome,
                    Categoria = a.TipoArtigo.Categoria
                }).ToList();
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
