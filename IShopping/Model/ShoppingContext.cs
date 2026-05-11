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
    }
}
