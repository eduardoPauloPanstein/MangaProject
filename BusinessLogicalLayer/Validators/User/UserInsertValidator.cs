using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Validators.User
{
    internal class UserInsertValidator : UserValidator
    {
        public UserInsertValidator()
        {
            base.ValidateNickname();
            base.ValidateEmail();
            base.ValidatePassword();
            base.ValidateConfirmPassword();
        }
    }

    internal class UsesUpdateValidator : UserValidator
    {
        public UsesUpdateValidator()
        {
            base.ValidateNickname();
            //validate about?
        }
    }
}
