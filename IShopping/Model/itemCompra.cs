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

        public int quantidadePrevista { get; set; } 
        public int quantidadeAdquirida { get; set; } 
        public decimal precoUnitario { get; set; } 
        public bool IsPrevisto { get; set; } = true; 
        public string Observacoes { get; set; }
        public int ArtigoId { get; set; }
        public virtual Artigo Artigo { get; set; }
        public int CompraID { get; set; }
        public virtual Compra compra { get; set; }      
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;
        public int CriadoPorUserId { get; set; }
        public int AlteradoPorUserId { get; set; }
    }
}
