using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShopping.Model
{    
    public class TipoArtigo
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150), Required]
        public string Categoria { get; set; }
    }
}
