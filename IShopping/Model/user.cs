using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShopping.Model
{    
    public class user
    {
        [Key] public int id { get; set; }

        [StringLength(150)]
        [Index(IsUnique = true)] 
        public string username { get; set; }

        [StringLength(150)]
        public string password {  get; set; }

    }
}
