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
                var utilizador = db.users.FirstOrDefault(u => u.username == username && u.password == pass);
                return utilizador != null ? utilizador.id : -1;
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

        public object AtualizarLista()
        {
            using (var db = new ShoppingContext())
            {                
                return db.users.Select(a => new
                {
                    Id = a.id,           
                    username = a.username,
                    password = a.password
                }).ToList();
            }
        }

        public void eliminarUser(int id)
        {
            using (var db = new ShoppingContext())
            {
                var utilizador = db.users.FirstOrDefault(u => u.id == id);
                if (utilizador != null)
                {
                    db.users.Remove(utilizador);
                    db.SaveChanges();
                }
            }
        }

    }
}
