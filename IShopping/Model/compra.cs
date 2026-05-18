using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IShopping.Model
{
    public enum Estado { aberto = 1, fechado = 2, padrao = 0 }
    public class Compra
    {
        public int id { get; set; }

        [StringLength(150), Required]
        public string nome { get; set; }

        [EnumDataType(typeof(Estado)), Required]
        public Estado estado { get; set; }

        public DateTime dataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; }
        public DateTime dataFechar { get; set; }

        public List<itemCompra> listaCompra { get; set; } = new List<itemCompra>();
    }
}
