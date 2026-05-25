using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IShopping.Model
{
    public class ShoppingContext: DbContext
    {
        public DbSet<user> users { get; set; }
        public DbSet<TipoArtigo> tipos { get; set; }

        public DbSet<Artigo> artigos { get; set; }
        public DbSet<itemCompra> itemCompras { get; set; }
        public DbSet<Compra> compras { get; set; }
        public DbSet<orcamento> orcamentos { get; set; }
        public DbSet<ArtigoPrevisto> artigoPrevistos { get; set; }
        public DbSet<ArtigoNaoPrevisto> artigoNaoPrevistos { get; set; }

    }
}
