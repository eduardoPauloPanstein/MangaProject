using DataAccessLayer.Interfaces.IUserComentary;
using Entities.MangaS;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.Responses;

namespace DataAccessLayer.Implementations.UserComentaryDAL
{
    internal class MangaComentaryDAL : IMangaComentaryDAL
    {
        private readonly MangaProjectDbContext _db;
        public MangaComentaryDAL(MangaProjectDbContext db)
        {
            _db = db;
        }
        public async Task<Response> Delete(int id)
        {
            MangaComentary? MangaDB = await _db.MangaComentaries.FindAsync(id);
            if (MangaDB == null)
                return ResponseFactory.CreateInstance().CreateFailedResponseNotFoundId();
            try
            {
                _db.MangaComentaries.Remove(MangaDB);
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }

        public async Task<SingleResponse<MangaComentary>> Get(int id)
        {
            try
            {
                MangaComentary? Select = _db.MangaComentaries.FirstOrDefault(m => m.Id == id);
                return ResponseFactory.CreateInstance().CreateSuccessSingleResponse<MangaComentary>(Select);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedSingleResponseNotFoundItem<MangaComentary>(ex);
            }
        }

        public async Task<DataResponse<MangaComentary>> Get(int skip, int take)
        {
            try
            {
                List<MangaComentary> mangas = await _db.MangaComentaries
                    .AsNoTracking()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
                return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(mangas);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedDataResponse<MangaComentary>(ex);
            }
        }

        public async Task<Response> Insert(MangaComentary Item)
        {
            try
            {
                _db.MangaComentaries.Add(Item);
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }

        public async Task<Response> Update(MangaComentary Item)
        {
            MangaComentary? MangaDB = await _db.MangaComentaries.FindAsync(Item.Id);
            if (MangaDB == null)
                return ResponseFactory.CreateInstance().CreateFailedResponseNotFoundId();
            try
            {
                _db.MangaComentaries.Update(Item);
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
