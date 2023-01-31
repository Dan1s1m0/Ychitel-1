using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ychitel.Model;

namespace Ychitel.Controlers
{
    public class UsersController
    {
        Core db = new Core();
        /// <summary>
        /// Проверка авторизации 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Auth(string login, string password)
        {
            Users logUsers = db.context.Users.Where(
              x => x.Login == login && x.Password == password
              ).FirstOrDefault();
            if(logUsers!= null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
