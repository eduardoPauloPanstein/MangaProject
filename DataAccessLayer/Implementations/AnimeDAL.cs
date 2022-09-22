using DataAccessLayer.Interfaces.IAnimeInterfaces;
using Entities.AnimeS;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementations
{
    public class AnimeDAL :IAnimeDAL
    {
        private readonly MangaProjectDbContext _db;
        public AnimeDAL(MangaProjectDbContext db)
        {
            this._db = db;
        }

        public Task<Response> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SingleResponse<Anime>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Anime>> Get(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Anime>> Get(string name)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Anime>> GetByFavorites(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Anime>> GetByUserCount(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetLastIndexAnime()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetLastIndexCategory()
        {
            throw new NotImplementedException();
        }

        public Task<Response> Insert(Anime Item)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(Anime Item)
        {
            throw new NotImplementedException();
        }
    }
}
