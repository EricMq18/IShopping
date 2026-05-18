using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShopping.Model
{
    public class ArtigoPrevisto
    {
        [Key]
        public int id { get; set; }
        public int qntPrevista {  get; set; }
    }
}
