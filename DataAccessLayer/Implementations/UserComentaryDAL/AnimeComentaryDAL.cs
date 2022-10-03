using DataAccessLayer.Interfaces.IUserComentary;
using Entities.AnimeS;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.Responses;

namespace DataAccessLayer.Implementations.UserComentaryDAL
{
    public class AnimeComentaryDAL : IAnimeComentaryDAL
    {
        private readonly MangaProjectDbContext _db;
        public AnimeComentaryDAL(MangaProjectDbContext db)
        {
            _db = db;
        }
        public async Task<Response> Delete(int id)
        {
            AnimeComentary? MangaDB = await _db.AnimeComentaries.FindAsync(id);
            if (MangaDB == null)
                return ResponseFactory.CreateInstance().CreateFailedResponseNotFoundId();
            try
            {
                _db.AnimeComentaries.Remove(MangaDB);
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }

        public async Task<SingleResponse<AnimeComentary>> Get(int id)
        {
            try
            {
                AnimeComentary? Select = _db.AnimeComentaries.FirstOrDefault(m => m.Id == id);
                return ResponseFactory.CreateInstance().CreateSuccessSingleResponse<AnimeComentary>(Select);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedSingleResponseNotFoundItem<AnimeComentary>(ex);
            }
        }

        public async Task<DataResponse<AnimeComentary>> Get(int skip, int take)
        {
            try
            {
                List<AnimeComentary> mangas = await _db.AnimeComentaries
                    .AsNoTracking()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
                return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(mangas);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedDataResponse<AnimeComentary>(ex);
            }
        }

        public async Task<Response> Insert(AnimeComentary Item)
        {
            try
            {
                _db.AnimeComentaries.Add(Item);
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }

        public async Task<Response> Update(AnimeComentary Item)
        {
            AnimeComentary? MangaDB = await _db.AnimeComentaries.FindAsync(Item.Id);
            if (MangaDB == null)
                return ResponseFactory.CreateInstance().CreateFailedResponseNotFoundId();
            try
            {
                _db.AnimeComentaries.Update(Item);
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
