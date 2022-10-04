using BusinessLogicalLayer.Interfaces.IUserComentaryService;
using DataAccessLayer.Interfaces.IUserComentary;
using Entities.MangaS;
using Shared.Responses;

namespace BusinessLogicalLayer.Implementations.UserComentaryService
{
    public class MangaComentaryService : IMangaComentary
    {
        private readonly IMangaComentaryDAL _MangaComentaryDAL;
        public MangaComentaryService(IMangaComentaryDAL MangaComentaryDAL)
        {
            this._MangaComentaryDAL = MangaComentaryDAL;
        }
        public async Task<Response> Delete(int id)
        {
            return await _MangaComentaryDAL.Delete(id);
        }

        public async Task<SingleResponse<MangaComentary>> Get(int id)
        {
            return await _MangaComentaryDAL.Get(id);
        }

        public async Task<DataResponse<MangaComentary>> Get(int skip, int take)
        {
            return await _MangaComentaryDAL.Get(skip,take);
        }

        public async Task<DataResponse<MangaComentary>> GetByUser(int userid)
        {
            return await _MangaComentaryDAL.GetByUser(userid);

        }

        public async Task<Response> Insert(MangaComentary Item)
        {
            return await _MangaComentaryDAL.Insert(Item);
        }

        public async Task<Response> Update(MangaComentary Item)
        {
            return await _MangaComentaryDAL.Update(Item);
        }
    }
}
