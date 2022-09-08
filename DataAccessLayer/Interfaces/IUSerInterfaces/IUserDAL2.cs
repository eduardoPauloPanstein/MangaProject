using Entities.UserS;
using Shared;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IUSerInterfaces
{
    public interface IUserDAL2 :IUserGet , IUserPost ,ICRUD<User>
    {
        Task<SingleResponse<User>> Login(UserLogin user);
    }
}
