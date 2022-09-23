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
        public async Task<DataResponse<Manga>> Get(int skip, int take)
        {
            //politica de cache!
            return await _mangaDAL.Get(skip,take);
        }
        public async Task<DataResponse<Manga>> GetByFavorites(int skip, int take)
        {
            return await _mangaDAL.GetByFavorites(skip, take);
        }
        public async Task<SingleResponse<Manga>> Get(int id)
        {
            return await _mangaDAL.Get(id);
        }
        public async Task<DataResponse<Manga>> Get(string name)
        {
            return await _mangaDAL.Get(name);
        }
        public async Task<DataResponse<Manga>> GetByUserCount(int skip, int take)
        {
            return await _mangaDAL.GetByUserCount(skip, take);
        }
        public async Task<Response> Insert(Manga manga)
        {
            //Response response = new MangaInsertValidator().Validate(manga).ConvertToResponse();
            //if (!response.HasSuccess)
            //    return response;
            return await _mangaDAL.Insert(manga);
        }
        public async Task<Response> Update(Manga Item)
        {
            return await _mangaDAL.Update(Item);
        }
        public async Task<Response> Delete(int id)
        {
            return await _mangaDAL.Delete(id);
        }

        public async Task<Response> InsertCategory(Category id)
        {
            return await _mangaDAL.InsertCategory(id);
        }
    }
}
