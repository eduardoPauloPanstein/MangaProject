using Entities;
using Shared;
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
        Task<DataResponse<User>> SelectAll();
        Task<Response> Update(User user);
        Task<Response> Delete(int id);
    }
}
