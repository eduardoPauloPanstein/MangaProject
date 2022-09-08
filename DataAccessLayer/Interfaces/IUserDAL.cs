using Entities.UserS;
using Shared;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUserDAL
    {
        Task<Response> Insert(User user);
        Task<SingleResponse<User>> Select(int id);
        Task<DataResponse<User>> Select(int skip, int take);
        Task<Response> Update(User user);
        Task<Response> Delete(int id);
        Task<SingleResponse<User>> Login(UserLogin user);
    }
}
