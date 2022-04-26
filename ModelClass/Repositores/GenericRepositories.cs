using ModelClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.Repositores
{
    public class GenericRepositories
    {
        public List<Usuario> GetUsuarios()
        {

            return new List<Usuario>
            {
                new Usuario(){ UserName = "leandro",Password = "7c797267692e79c2dc513c8ca6b757d153617013a46ddbd69c21e74237d3c007", AdminUser = true },
                new Usuario(){ UserName = "santander",Password = "138df632fd0de2067dfcd75b6dbc543d8d66da31a79a39358216aa6ef63ad437", AdminUser = false }
            };
        }

        public bool Autorizado(string nombre, string password)
        {
            Usuario usr = GetUsuarios().FirstOrDefault(u => u.UserName.ToLower() == nombre.ToLower() && u.Password == password);

            return usr != null;
        }

        public Usuario GetUsuario(string nombre, string password)
        {
            Usuario usr = GetUsuarios().FirstOrDefault(u => u.UserName.ToLower() == nombre.ToLower() && u.Password == password);

            return usr;
        }
    }
}
