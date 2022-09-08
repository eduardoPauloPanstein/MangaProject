using BLL.Extensions;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Utilities;
using BusinessLogicalLayer.Validators.User;
using DataAccessLayer.Interfaces;
using Entities.UserS;
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
        public async Task<SingleResponse<User>> Select(int? id)
        {
            if (id == null)
            {
                return ResponseFactory.CreateInstance().CreateSingleFailedResponse<User>(null, null, "Id is null.");
            }

            return await _userDAL.Select((int)id);
        }
        public async Task<DataResponse<User>> SelectAll()
        {
            return await _userDAL.SelectAll();
        }
        public async Task<Response> Update(User user)
        {
            //validar
            return await _userDAL.Update(user);
        }
        public async Task<SingleResponse<User>> Login(UserLogin user)
        {
            user.Password = HashGenerator.ComputeSha256Hash(user.Password);
            return await _userDAL.Login(user);
        }
        public async Task<DataResponse<UserMangaItem>> GetUserFavorites(int UserID)
        {
            return await _userDAL.GetUserFavorites(UserID);
        }
        public async Task<Response> FavoriteManga(int idmanga, int idusuario)
        {
            return await _userDAL.FavoriteManga(idmanga,idusuario);
        }
    }
}
