using BLL.Extensions;
using BusinessLogicalLayer.Interfaces.IMangaInterfaces;
using BusinessLogicalLayer.Validators.Manga;
using DataAccessLayer.Interfaces.IMangaInterfaces;
using Entities;
using Entities.MangaS;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Implementations
{
    public class MangaService : IMangaService
    {
        private readonly IMangaDAL _mangaDAL;
        public MangaService(IMangaDAL mangaDAL)
        {
            this._mangaDAL = mangaDAL;
        }
        public async Task<Response> DeleteAllDatas()
        {
            return await _mangaDAL.DeleteAllDatas();
        }
        public async Task<DataResponse<Manga>> Select(int skip, int take)
        {
            //politica de cache!
            return await _mangaDAL.Select(skip,take);
        }
        public async Task<DataResponse<Manga>> GetAllByFavorites()
        {
            return await _mangaDAL.GetAllByFavorites();
        }
        public async Task<SingleResponse<Manga>> Select(int id)
        {
            return await _mangaDAL.Select(id);
        }
        public async Task<DataResponse<Manga>> GetByName(string name)
        {
            return await _mangaDAL.GetByName(name);
        }
        public async Task<DataResponse<Manga>> GetMorePopular()
        {
            return await _mangaDAL.GetMorePopular();
        }
        public async Task<DataResponse<Manga>> GetPerPage(int page)
        {
            return await _mangaDAL.GetPerPage(page);
        }
        public async Task<DataResponse<Manga>> GetTopSixFavorites()
        {
            return await _mangaDAL.GetTopSixFavorites();
        }
        //public async Task<DataResponse<UserToManga>> GetUserFavorites(int UserID)
        //{
        //    return await _mangaDAL.GetUserFavorites(UserID);
        //}
        public async Task<Response> Insert(Manga manga)
        {
            Response response = new MangaInsertValidator().Validate(manga).ConvertToResponse();
            if (!response.HasSuccess)
                return response;
            response = await _mangaDAL.Insert(manga);
            return response;
        }
        public async Task<Response> Update(Manga Item)
        {
            return await _mangaDAL.Update(Item);
        }
        public async Task<Response> Delete(int id)
        {
            return await _mangaDAL.Delete(id);
        }
    }
}
