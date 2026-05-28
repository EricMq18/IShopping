using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShopping.Model
{
    public class itemCompra
    {
        [Key]
        public int id { get; set; }
        public int quantidadeAdquirida { get; set; }
        public decimal precoUnitario { get; set; }

        // ADICIONAR VIRTUAL AQUI:
        public virtual Artigo artigo { get; set; }
        public virtual Compra compra { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;

        // ADICIONAR VIRTUAL AQUI:
        public virtual user userCriador { get; set; }
        public virtual user userAlterador { get; set; }
    }
}
