using BusinessLogicalLayer.Interfaces.IAnimeInterfaces;
using DataAccessLayer.Interfaces.IAnimeInterfaces;
using Entities.AnimeS;
using Entities.MangaS;
using Shared.Responses;

namespace BusinessLogicalLayer.Implementations
{
    public class AnimeService : IAnimeService
    {
        private readonly IAnimeDAL _animeDAL;
        public AnimeService(IAnimeDAL animeDAL)
        {
            this._animeDAL = animeDAL;
        }
        public async Task<Response> Delete(int id)
        {
            return await _animeDAL.Delete(id);

        }

        public async Task<SingleResponse<Anime>> Get(int id)
        {
            return await _animeDAL.Get(id);

        }

        public async Task<DataResponse<Anime>> Get(int skip, int take)
        {
            return await _animeDAL.Get(skip, take);

        }

        public async Task<DataResponse<Anime>> Get(string name)
        {
            return await _animeDAL.Get(name);

        }

        public async Task<DataResponse<Anime>> GetByFavorites(int skip, int take)
        {
            return await _animeDAL.GetByFavorites(skip, take);

        }

        public async Task<DataResponse<Anime>> GetByUserCount(int skip, int take)
        {
            return await _animeDAL.GetByUserCount(skip,take);
        }

        public async Task<int> GetLastIndexAnime()
        {
            return await _animeDAL.GetLastIndexAnime();
        }

        public async Task<int> GetLastIndexCategory()
        {
            return await _animeDAL.GetLastIndexCategory();

        }

        public async Task<Response> Insert(Anime Item)
        {
            //Validacoes
            return await _animeDAL.Insert(Item);
        }

        public async Task<Response> Update(Anime Item)
        {
            return await _animeDAL.Update(Item);
        }
    }
}
