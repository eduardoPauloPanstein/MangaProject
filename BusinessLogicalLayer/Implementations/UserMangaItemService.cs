using BusinessLogicalLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Entities.UserS;
using Shared.Responses;

namespace BusinessLogicalLayer.Implementations
{
    public class UserMangaItemService : IUserMangaItemService
    {
        private readonly IUserMangaItemDAL _UserMangaItemDAL;
        public UserMangaItemService(IUserMangaItemDAL UserMangaItemDAL)
        {
            this._UserMangaItemDAL = UserMangaItemDAL;
        }
        public async Task<Response> Delete(int id)
        {
            return await _UserMangaItemDAL.Delete(id);
        }

        public async Task<SingleResponse<UserMangaItem>> Get(int id)
        {
            return await _UserMangaItemDAL.Get(id);
        }

        public async Task<DataResponse<UserMangaItem>> Get(int skip, int take)
        {
            return await _UserMangaItemDAL.Get(skip, take);
        }

        public async Task<Response> Insert(UserMangaItem Item)
        {
            return await _UserMangaItemDAL.Insert(Item);
        }

        public async Task<Response> Update(UserMangaItem Item)
        {
            return await _UserMangaItemDAL.Update(Item);
        }
    }
}
