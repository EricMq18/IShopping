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
        public int id {  get; set; } 

        public int quantidadeAdquirida {  get; set; }
        public decimal precoUnitario { get; set; }
        public int CompraID { get; set; }
        public Compra compra { get; set; }
    }
}
