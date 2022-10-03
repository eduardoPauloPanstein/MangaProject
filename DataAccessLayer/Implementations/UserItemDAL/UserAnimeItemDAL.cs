using DataAccessLayer.Interfaces.IUserItem;
using Entities.UserS;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.Responses;

namespace DataAccessLayer.Implementations.UserItemDAL
{
    public class UserAnimeItemDAL : IUserAnimeItemDAL
    {
        private readonly MangaProjectDbContext _db;
        public UserAnimeItemDAL(MangaProjectDbContext db)
        {
            _db = db;
        }
        public async Task<Response> Delete(int id)
        {
            UserAnimeItem? MangaDB = await _db.UserAnime.FindAsync(id);
            if (MangaDB == null)
                return ResponseFactory.CreateInstance().CreateFailedResponseNotFoundId();
            try
            {
                _db.UserAnime.Remove(MangaDB);
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }

        public async Task<SingleResponse<UserAnimeItem>> Get(int id)
        {
            try
            {
                UserAnimeItem? Select = _db.UserAnime.FirstOrDefault(m => m.Id == id);
                return ResponseFactory.CreateInstance().CreateSuccessSingleResponse<UserAnimeItem>(Select);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedSingleResponseNotFoundItem<UserAnimeItem>(ex);
            }
        }

        public async Task<DataResponse<UserAnimeItem>> Get(int skip, int take)
        {
            try
            {
                List<UserAnimeItem> mangas = await _db.UserAnime
                    .AsNoTracking()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
                return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(mangas);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedDataResponse<UserAnimeItem>(ex);
            }
        }

        public async Task<Response> Insert(UserAnimeItem Item)
        {
            try
            {
                _db.UserAnime.Add(Item);
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }

        public async Task<Response> Update(UserAnimeItem Item)
        {
            UserAnimeItem? MangaDB = await _db.UserAnime.FindAsync(Item.Id);
            if (MangaDB == null)
                return ResponseFactory.CreateInstance().CreateFailedResponseNotFoundId();
            try
            {
                _db.UserAnime.Update(Item);
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
