using IShopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShopping.Controller
{
    public class UserController
    {
        public int UtilizadorValido(string username, string pass)
        {
            using (var db = new ShoppingContext())
            {
                bool existe = db.users.Any(u => u.username == username && u.password == pass);

                return existe ? 1 : 0;
            }
        }

        public  void registarUser(string user, string pass) 
        {
            using (var db = new ShoppingContext()) 
            {
                var novoUser = new user { username = user, password = pass};
                db.users.Add(novoUser);
                db.SaveChanges();
            }
        }

    }
}
