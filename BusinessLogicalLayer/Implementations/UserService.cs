using BLL.Extensions;
using BusinessLogicalLayer.Interfaces.IUserInterfaces;
using BusinessLogicalLayer.Utilities;
using BusinessLogicalLayer.Validators.User;
using DataAccessLayer.Interfaces.IUSerInterfaces;
using DataAccessLayer.UnitOfWork;
using Entities.Enums;
using Entities.MangaS;
using Entities.UserS;
using Shared;
using Shared.Responses;

namespace BusinessLogicalLayer.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
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
            adm.EnableEntity();
            _unitOfWork.UserRepository.CreateAdmin(adm);
            _unitOfWork.Commit();
        }
        public async Task<Response> Delete(int id)
        {
            if (id == null)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(null);
            }

            return await _unitOfWork.UserRepository.Delete((int)id);
        }

        public async Task<Response> Insert(User user)
        {
            Response response = new UserInsertValidator().Validate(user).ConvertToResponse();
            if (!response.HasSuccess)
                return response;
            user.Password = HashGenerator.ComputeSha256Hash(user.Password);
            //Tirar ConfirmPassword

            user.EnableEntity();
            response = await _unitOfWork.UserRepository.Insert(user);
            return response;
        }

        public async Task<SingleResponse<User>> Get(int id)
        {

            return await _unitOfWork.UserRepository.Get(id);
        }

        public async Task<DataResponse<User>> Get(int skip, int take)
        {
            return await _unitOfWork.UserRepository.Get(skip, take);
        }

        public async Task<Response> Update(User user)
        {
            Response response = new UserUpdateValidator().Validate(user).ConvertToResponse();
            if (!response.HasSuccess)
                return response;

            return await _unitOfWork.UserRepository.Update(user);
        }

        public async Task<SingleResponse<User>> Login(UserLogin user)
        {
            user.Password = HashGenerator.ComputeSha256Hash(user.Password);
            return await _unitOfWork.UserRepository.Login(user);
        }

        public async Task<DataResponse<Manga>> GetUserList(int userid)
        {
            return await _unitOfWork.UserRepository.GetUserList(userid);
        }

        public async Task<Response> AddUserMangaItem(UserMangaItem item)
        {
            int score = ((int)item.Score);
            return await _unitOfWork.UserRepository.AddUserMangaItem(item,score);
        }

        public async Task<DataResponse<Manga>> GetUserFavorites(int userid)
        {
            return await _unitOfWork.UserRepository.GetUserFavorites(userid);
        }

        public async Task<DataResponse<Manga>> GetUserRecommendations(int userid)
        {
            return await _unitOfWork.UserRepository.GetUserRecommendations(userid);
        }

        public async Task<Response> AddUserAnimeItem(UserAnimeItem item)
        {
            int score = ((int)item.Score);
            return await _unitOfWork.UserRepository.AddUserAnimeItem(item, score);
        }
    }
}
