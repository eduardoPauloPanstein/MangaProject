using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Validators.User
{
    internal class UserSelectValidator : UserValidator
    {
        public UserSelectValidator()
        {
            base.ValidateID();
        }
    }
}
