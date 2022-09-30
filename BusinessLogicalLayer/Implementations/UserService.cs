using BLL.Extensions;
using BusinessLogicalLayer.Interfaces.IUserInterfaces;
using BusinessLogicalLayer.Utilities;
using BusinessLogicalLayer.Validators.User;
using DataAccessLayer.Interfaces.IUSerInterfaces;
using Entities.Enums;
using Entities.MangaS;
using Entities.UserS;
using Shared;
using Shared.Responses;

namespace BusinessLogicalLayer.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserDAL _userDAL;

        public UserService(IUserDAL userDAL)
        {
            this._userDAL = userDAL;
        }

        public void CreateAdmin()
        {
            string password = HashGenerator.ComputeSha256Hash("admin");

            User adm = new()
            {
                Nickname = "admin",
                Password = password,
                ConfirmPassword = password,
                Email = "admin@gmail.com",

                Role = UserRoles.Admin,
            };
            _userDAL.CreateAdmin(adm);
        }
        public async Task<Response> Delete(int id)
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

        public async Task<SingleResponse<User>> Get(int id)
        {

            return await _userDAL.Get(id);
        }

        public async Task<DataResponse<User>> Get(int skip, int take)
        {
            return await _userDAL.Get(skip, take);
        }

        public async Task<Response> Update(User user)
        {
            Response response = new UserUpdateValidator().Validate(user).ConvertToResponse();
            if (!response.HasSuccess)
                return response;

            return await _userDAL.Update(user);
        }

        public async Task<SingleResponse<User>> Login(UserLogin user)
        {
            user.Password = HashGenerator.ComputeSha256Hash(user.Password);
            return await _userDAL.Login(user);
        }

        public async Task<DataResponse<Manga>> GetUserList(int userid)
        {
            return await _userDAL.GetUserList(userid);
        }

        public async Task<Response> AddUserMangaItem(UserMangaItem item)
        {
            int score = ((int)item.Score);
            return await _userDAL.AddUserMangaItem(item,score);
        }

        public async Task<DataResponse<Manga>> GetUserFavorites(int userid)
        {
            return await _userDAL.GetUserFavorites(userid);
        }

        public async Task<DataResponse<Manga>> GetUserRecommendations(int userid)
        {
            return await _userDAL.GetUserRecommendations(userid);
        }

        public async Task<Response> AddUserAnimeItem(UserAnimeItem item)
        {
            int score = ((int)item.Score);
            return await _userDAL.AddUserAnimeItem(item, score);
        }
    }
}
