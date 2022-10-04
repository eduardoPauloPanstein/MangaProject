using BusinessLogicalLayer.Interfaces.IUserComentaryService;
using DataAccessLayer.Interfaces.IUserComentary;
using Entities.AnimeS;
using Shared.Responses;

namespace BusinessLogicalLayer.Implementations.UserComentaryService
{
    public class AnimeComentaryService : IAnimeComentary
    {
        private readonly IAnimeComentaryDAL _AnimeComentaryDAL;
        public AnimeComentaryService(IAnimeComentaryDAL AnimeComentaryDAL)
        {
            this._AnimeComentaryDAL = AnimeComentaryDAL;
        }
        public async Task<Response> Delete(int id)
        {
            return await _AnimeComentaryDAL.Delete(id);
        }

        public async Task<SingleResponse<AnimeComentary>> Get(int id)
        {
            return await _AnimeComentaryDAL.Get(id);
        }

        public async Task<DataResponse<AnimeComentary>> Get(int skip, int take)
        {
            return await _AnimeComentaryDAL.Get(skip,take);
        }

        public async Task<DataResponse<AnimeComentary>> GetByUser(int userid)
        {
            return await _AnimeComentaryDAL.GetByUser(userid);

        }

        public async Task<Response> Insert(AnimeComentary Item)
        {
            return await _AnimeComentaryDAL.Insert(Item);
        }

        public async Task<Response> Update(AnimeComentary Item)
        {
            return await _AnimeComentaryDAL.Update(Item);
        }
    }
}
