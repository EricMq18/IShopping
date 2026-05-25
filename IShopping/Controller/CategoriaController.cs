using IShopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShopping.Controller
{
    public class CategoriaController
    {
        //READ
        public List<TipoArtigo> ObterCategorias()
        {
            using (var db = new ShoppingContext())
            {
                return db.tipos.ToList();
            }
        }

        //CREATE
        public void AdicionarCategoria(string nome)
        {
            using (var db = new ShoppingContext())
            {
                db.tipos.Add(new TipoArtigo { Categoria = nome });
                db.SaveChanges();
            }
        }

        //UPDATE
        public void AtualizarCategoria(int id, string novoNome)
        {
            using (var db = new ShoppingContext())
            {
                var categoria = db.tipos.FirstOrDefault(t => t.Id == id);
                if (categoria != null)
                {
                    categoria.Categoria = novoNome;
                    db.SaveChanges();
                }
            }
        }

        //DELETE
        public void EliminarCategoria(int id)
        {
            using (var db = new ShoppingContext())
            {
                var categoria = db.tipos.FirstOrDefault(t => t.Id == id);
                if (categoria != null)
                {
                    db.tipos.Remove(categoria);
                    db.SaveChanges();
                }
            }
        }
    }
}
