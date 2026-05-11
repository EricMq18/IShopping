using IShopping.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace IShopping.Controller
{
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<ShoppingContext>
    {
        protected override void Seed(ShoppingContext context)
        {
            
            using (var db = context)
            {
                var User = new user { username = "admin", password = "admin" };
                db.users.Add(User);
                db.SaveChanges();
            }
            base.Seed(context);
        }

    }
}
