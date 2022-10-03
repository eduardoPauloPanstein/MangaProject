using DataAccessLayer.Interfaces.IUserItem;
using Entities.UserS;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.Responses;

namespace DataAccessLayer.Implementations.UserItemDAL
{
    public class UserMangaItemDAL : IUserMangaItemDAL
    {
        private readonly MangaProjectDbContext _db;
        public UserMangaItemDAL(MangaProjectDbContext db)
        {
            _db = db;
        }
        public async Task<Response> Delete(int id)
        {
            UserMangaItem? MangaDB = await _db.UserManga.FindAsync(id);
            if (MangaDB == null)
                return ResponseFactory.CreateInstance().CreateFailedResponseNotFoundId();
            try
            {
                _db.UserManga.Remove(MangaDB);
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }

        public async Task<SingleResponse<UserMangaItem>> Get(int id)
        {
            try
            {
                UserMangaItem? Select = _db.UserManga.FirstOrDefault(m => m.Id == id);
                return ResponseFactory.CreateInstance().CreateSuccessSingleResponse<UserMangaItem>(Select);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedSingleResponseNotFoundItem<UserMangaItem>(ex);
            }
        }

        public async Task<DataResponse<UserMangaItem>> Get(int skip, int take)
        {
            try
            {
                List<UserMangaItem> mangas = await _db.UserManga
                    .AsNoTracking()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
                return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(mangas);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedDataResponse<UserMangaItem>(ex);
            }
        }

        public async Task<Response> Insert(UserMangaItem Item)
        {
            try
            {
                _db.UserManga.Add(Item);
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }

        public async Task<Response> Update(UserMangaItem Item)
        {
            UserMangaItem? MangaDB = await _db.UserManga.FindAsync(Item.Id);
            if (MangaDB == null)
                return ResponseFactory.CreateInstance().CreateFailedResponseNotFoundId();
            try
            {
                _db.UserManga.Update(Item);
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }
    }
}
