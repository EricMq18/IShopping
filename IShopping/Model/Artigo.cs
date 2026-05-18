using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShopping.Model
{
    public class Artigo
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        public string Nome { get; set; }
        public int TipoArtigoId {  get; set; }
        public TipoArtigo TipoArtigo { get; set; }
    }
}
