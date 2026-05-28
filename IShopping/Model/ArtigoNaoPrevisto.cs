using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IShopping.Model
{
    public class ArtigoNaoPrevisto : itemCompra
    {
        public string descricao {  get; set; }
    }
}
