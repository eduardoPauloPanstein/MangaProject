using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Entities.UserS;
using Shared.Responses;

namespace BusinessLogicalLayer.Implementations
{
    public class UserAnimeItemService : IUserAnimeItemService
    {
        private readonly IUserAnimeItemDAL _UserAnimeItemDAL;
        public UserAnimeItemService(IUserAnimeItemDAL UserAnimeItemDAL)
        {
            this._UserAnimeItemDAL = UserAnimeItemDAL;
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

        public async Task<Response> Insert(UserAnimeItem Item)
        {
            return await _UserAnimeItemDAL.Insert(Item);
        }

        public async Task<Response> Update(UserAnimeItem Item)
        {
            return await _UserAnimeItemDAL.Update(Item);
        }
    }
}
