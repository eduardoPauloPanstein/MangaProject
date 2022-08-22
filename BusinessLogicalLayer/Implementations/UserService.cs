using BLL.Extensions;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Utilities;
using BusinessLogicalLayer.Validators.User;
using DataAccessLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserDAL _userDAL;

        public UserService(IUserDAL userDAL)
        {
            this._userDAL = userDAL;
        }

        public async Task<Response> Delete(int? id)
        {
            if (id == null)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(null);
            }

            return await _userDAL.Delete((int)id);
        }

        public async Task<Response> Insert(User user)
        {
            Response response = new UserInsertValidator().Validate(user).ConvertToResponse();
            if (!response.HasSuccess)
                return response;
            user.Password = HashGenerator.ComputeSha256Hash(user.Password);
            //Tirar ConfirmPassword
            response = await _userDAL.Insert(user);
            return response;
        }

        public async Task<SingleResponse<User>> Select(int id)
        {
            User user = new();
            user.Id = id;
            Response response = new UserSelectValidator().Validate(user).ConvertToResponse();
            if (!response.HasSuccess)
            {
                return ResponseFactory.CreateInstance().CreateSingleFailedResponse<User>(null,null);
            }

            return await _userDAL.Select((int)id);
        }

        public async Task<DataResponse<User>> SelectAll()
        {
            return await _userDAL.SelectAll();
        }

        public async Task<Response> Update(User user)
        {


            return await _userDAL.Update(user);
        }

        public async Task<Response> Login(User user)
        {
            user.Password = HashGenerator.ComputeSha256Hash(user.Password);
            return await _userDAL.Login(user);
        }
    }
}
