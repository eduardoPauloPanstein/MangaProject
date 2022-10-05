﻿using DataAccessLayer.ErrorHandling;
using DataAccessLayer.Interfaces.IUSerInterfaces;
using Entities.AnimeS;
using Entities.MangaS;
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

        public UserDAL()
        {
        }

        public void CreateAdmin(User adm)
        {
            var user = _db.Users.Where(u => u.Id > -1).FirstOrDefault();
            string s = "";
            if (user == null)
            {
                _db.Add(adm);
                _db.SaveChanges();
            }
        }

        public async Task<Response> Delete(int id)
        {
            User? user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                return new Response("Usuario não encontrado no banco de dados.", false, null);
            }

            _db.Users.Remove(user);
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

        public async Task<DataResponse<Manga>> GetUserFavorites(int userid)
        {
            List<Manga> mangas = new();
            try
            {
                List<UserMangaItem> user = await _db.UserManga.Where(u => u.UserId == userid && u.Favorite == true).ToListAsync();

                foreach (UserMangaItem item in user)
                {
                    mangas.Add(_db.Mangas.FirstOrDefault(m => m.Id == item.MangaId));
                }


                return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(mangas);

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedDataResponse<Manga>(ex);
            }
        }

        public async Task<DataResponse<Manga>> GetUserList(int userid)
        {
            List<Manga> mangas = new();
            try
            {
                List<UserMangaItem> user = await _db.UserManga.Where(u => u.UserId == userid).ToListAsync();

                foreach (UserMangaItem item in user)
                {
                    mangas.Add(_db.Mangas.FirstOrDefault(m => m.Id == item.MangaId));
                }
                return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(mangas);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedDataResponse<Manga>(ex);
            }
        }

        public async Task<Response> Insert(User user)
        {
            try
            {
                _db.Users.Add(user);
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return UserDbFailed.Handle(ex);
            }
        }

        public async Task<SingleResponse<User>> Login(UserLogin user)
        {
            try
            {
                User? userLogged = await _db.Users.FirstOrDefaultAsync(u => (u.Email == user.EmailOrNickname || u.Nickname == user.EmailOrNickname) && u.Password == user.Password);
                if (userLogged == null)
                {
                    return ResponseFactory.CreateInstance().CreateFailedSingleResponseNotFoundItem<User>();
                }

                UpdateLastLoginAsync(userLogged.Id);

                return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(userLogged);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedSingleResponse<User>(ex);
            }
        }

        public async Task<SingleResponse<User>> Get(int id)
        {
            try
            {
                User? user = await _db.Users.FindAsync(id);
                if (user == null)
                {
                    return ResponseFactory.CreateInstance().CreateFailedSingleResponseNotFoundItem<User>();
                }
                return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(user);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedSingleResponseNotFoundItem<User>(ex);
            }
        }

        public async Task<DataResponse<User>> Get(int skip, int take)
        {
            try
            {
                List<User> users = await _db.Users
                    .AsNoTracking()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
                return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(users);

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedDataResponse<User>(ex);
            }
        }

        public async Task<Response> Update(User user)
        {
            //_db.Users.Update(user);

            User? userDb = await _db.Users.FindAsync(user.Id);
            if (userDb == null)
                return ResponseFactory.CreateInstance().CreateFailedResponseNotFoundId();
            userDb.Nickname = user.Nickname;
            userDb.About = user.About;

            if (user.AvatarImageFileLocation != null)
                userDb.AvatarImageFileLocation = user.AvatarImageFileLocation;
            if (user.CoverImageFileLocation != null)
                userDb.CoverImageFileLocation = user.CoverImageFileLocation;


            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return UserDbFailed.Handle(ex);
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

        public async Task<DataResponse<Manga>> GetUserRecommendations(int userid)
        {

            List<int> IdsUsuarios = new();
            List<UserMangaItem> Fav = new();
            List<Manga> Mangas = new();
            try
            {
                List<UserMangaItem> userFav = await _db.UserManga.Where(u => u.UserId == userid && u.Favorite == true).ToListAsync();
                foreach (UserMangaItem item in userFav)
                {
                    UserMangaItem user = _db.UserManga.FirstOrDefault(m => m.MangaId == item.MangaId && m.UserId != userid);
                    if (user == null)
                    {

                    }
                    else
                    {
                        if (IdsUsuarios.Contains(user.UserId))
                        {

                        }
                        else
                        {
                            IdsUsuarios.Add(user.UserId);
                        }
                    }
                }

                foreach (int item in IdsUsuarios)
                {
                    List<UserMangaItem> user = _db.UserManga.Where(u => u.UserId == item).ToList();
                    foreach (UserMangaItem i in user)
                    {
                        Fav.Add(i);
                    }
                }

                foreach (UserMangaItem item in Fav)
                {
                    Mangas.Add(_db.Mangas.FirstOrDefault(m => m.Id == item.MangaId));
                }

                return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(Mangas);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedDataResponse<Manga>(ex);
            }
        }
    }
}
