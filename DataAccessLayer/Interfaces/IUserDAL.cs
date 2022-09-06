using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface IUserDAL
    {
        Task<Response> Insert(User user);
        Task<SingleResponse<User>> Select(int id);
        Task<DataResponse<User>> SelectAll();
        Task<Response> Update(User user);
        Task<Response> Delete(int id);
        Task<SingleResponse<User>> Login(User user);
    }
}
