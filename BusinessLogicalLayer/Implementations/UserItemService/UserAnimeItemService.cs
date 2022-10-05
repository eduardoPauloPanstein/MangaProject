﻿using BusinessLogicalLayer.Interfaces.IUserItemService;
using DataAccessLayer.Interfaces.IUserItem;
using Entities.AnimeS;
using Entities.UserS;
using Shared.Responses;

namespace BusinessLogicalLayer.Implementations.UserItemService
{
    public class UserAnimeItemService : IUserAnimeItemService
    {
        private readonly IUserAnimeItemDAL _UserAnimeItemDAL;
        public UserAnimeItemService(IUserAnimeItemDAL UserAnimeItemDAL)
        {
            _UserAnimeItemDAL = UserAnimeItemDAL;
        }
        public async Task<Response> Delete(int id)
        {
            return await _UserAnimeItemDAL.Delete(id);
        }
        public async Task<SingleResponse<UserAnimeItem>> Get(int id)
        {
            return await _UserAnimeItemDAL.Get(id);
        }

        public async Task<DataResponse<UserAnimeItem>> Get(int skip, int take)
        {
            return await _UserAnimeItemDAL.Get(skip, take);
        }
        public async Task<DataResponse<UserAnimeItem>> GetByUser(int userid)
        {
            return await _UserAnimeItemDAL.GetByUser(userid);

        }
        public async Task<DataResponse<Anime>> GetUserFavorites(int userid)
        {
            return await _UserAnimeItemDAL.GetUserFavorites(userid);

        }
        public async Task<DataResponse<Anime>> GetUserList(int userid)
        {
            return await _UserAnimeItemDAL.GetUserList(userid);
        }
        public async Task<DataResponse<Anime>> GetUserRecommendations(int userid)
        {
            return await _UserAnimeItemDAL.GetUserRecommendations(userid);
        }
     
        public async Task<Response> Insert(UserAnimeItem Item, int Score)
        {
            return await _UserAnimeItemDAL.Insert(Item, Score);
        }
        public async Task<Response> Update(UserAnimeItem Item)
        {
            return await _UserAnimeItemDAL.Update(Item);
        }
    }
}
