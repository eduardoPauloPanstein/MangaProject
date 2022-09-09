using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.IUSerInterfaces;
using Entities.UserS;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.Responses;

namespace DataAccessLayer.Implementations
{
    public class UserDAL : IUserDAL
    {
        private readonly MangaProjectDbContext _db;
        public UserDAL(MangaProjectDbContext db)
        {
            this._db = db;
        }
        public async Task<Response> Delete(int id)
        {
            User? user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                return new Response("Usuario não encontrado no banco de dados.", false,null);
            }

            _db.Users.Remove(user);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSingleSuccessResponse(user);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateSingleFailedResponse<User>(ex, null);
            }
        }
        public Task<Response> FavoriteManga(int idmanga, int idusuario)
        {
            throw new NotImplementedException();
        }
        public Task<DataResponse<UserMangaItem>> GetUserFavorites(int UserID)
        {
            throw new NotImplementedException();
        }
        public async Task<Response> Insert(User user)
        {
            _db.Users.Add(user);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }
        public async Task<SingleResponse<User>> Login(UserLogin user)
        {
            try
            {
                User? userLogged = await _db.Users.FirstOrDefaultAsync(u =>( u.Email == user.EmailOrNickname || u.Nickname == user.EmailOrNickname) && u.Password == user.Password);
                if (userLogged == null)
                {
                    return ResponseFactory.CreateInstance().CreateSingleFailedResponse<User>(null, null, "User not found");
                }

                UpdateLastLoginAsync(userLogged.Id);

                return ResponseFactory.CreateInstance().CreateSingleSuccessResponse<User>(userLogged);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateSingleFailedResponse<User>(ex, null);
            }
        }
        public async Task<SingleResponse<User>> Select(int id)
        {
            try
            {
                User? user = await _db.Users.FindAsync(id);
                if (user == null)
                {
                    return ResponseFactory.CreateInstance().CreateSingleNotFoundIdResponse<User>(user);
                }
                return ResponseFactory.CreateInstance().CreateSingleSuccessResponse(user);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateSingleFailedResponse<User>(ex,null);
            }
        }
        public async Task<DataResponse<User>> Select(int skip, int take)
        {
            try
            {
                List<User> users = await _db.Users
                    .AsNoTracking()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
                return ResponseFactory.CreateInstance().CreateDataSuccessResponse(users);

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateDataFailedResponse<User>(ex);
            }
        }
        public async Task<Response> Update(User user)
        {
            //_db.Users.Update(user);

            User? userDb = await _db.Users.FindAsync(user.Id);
            if (userDb == null)
                return ResponseFactory.CreateInstance().CreateNotFoundIdResponse();
            userDb.Nickname = user.Nickname;
            userDb.About = user.About;

            if (user.AvatarImageFileLocation != null)
                userDb.AvatarImageFileLocation = user.AvatarImageFileLocation;

            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }
        public async void UpdateLastLoginAsync(int id)
        {
            User? userDb = await _db.Users.FindAsync(id);
            userDb.LastLogin = DateTime.Now;
            try
            {
                await _db.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
            }
        }
    }
}
