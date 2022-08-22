using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Validators.User
{
    internal class UserUpdateValidator : UserValidator
    { 
        public UserUpdateValidator()
        {
            base.ValidateNickname();
            base.ValidateID();
            //validate about?
        }
    }
}
