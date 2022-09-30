using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.UserS
{
    public class UserLogin
    {
        public UserLogin(string emailOrNickname, string password)
        {
            this.EmailOrNickname = emailOrNickname;
            this.Password = password;
        }
        public UserLogin()
        {

        }

        public string EmailOrNickname { get; set; }
        public string Password { get; set; }
    }
}
