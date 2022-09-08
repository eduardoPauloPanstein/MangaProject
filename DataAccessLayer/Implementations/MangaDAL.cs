using DataAccessLayer.Interfaces.IMangaInterfaces;
using Entities;
using Entities.MangaS;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.Responses;

namespace DataAccessLayer.Implementations
{
    public class MangaDAL : IMangaDAL
    {
        private readonly MangaProjectDbContext _db;
        public MangaDAL(MangaProjectDbContext db)
        {
            this._db = db;
        }

        public async Task<Response> Insert(Manga manga)
        {
            _db.Mangas.Add(manga);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }
        public async Task<DataResponse<Manga>> GetMorePopular()
        {
            throw new NotImplementedException();
        }
        public async Task<DataResponse<Manga>> GetPerPage(int page)
        {
            int pageSize = 10;
            List<Manga> mangas = await _db.Mangas.Skip(page * pageSize).Take(pageSize).ToListAsync();
            return ResponseFactory.CreateInstance().CreateDataSuccessResponse(mangas);
        }
        public async Task<Response> DeleteAllDatas()
        {
            //var tableNames = db.Model.GetEntityTypes()
            //                         .Select(t => t.GetTableName())
            //                         .Distinct()
            //                         .ToList();
            try
            {
                _db.Database.ExecuteSqlRaw($"DELETE FROM MangasRatingFrequencies; DELETE FROM MANGAS; DELETE FROM MangaTitles");
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }
        public async Task<DataResponse<Manga>> GetTopSixFavorites()
        {
            try
            {
                List<Manga> mangas = await _db.Mangas.OrderByDescending(m => m.FavoritesCount).Take(6).ToListAsync();
                return ResponseFactory.CreateInstance().CreateDataSuccessResponse(mangas);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateDataFailedResponse<Manga>(ex);
            }
        }
        public async Task<DataResponse<Manga>> GetAllByFavorites()
        {
            try
            {
                List<Manga> mangas = await _db.Mangas.OrderByDescending(m => m.FavoritesCount).ToListAsync();
                return ResponseFactory.CreateInstance().CreateDataSuccessResponse(mangas);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateDataFailedResponse<Manga>(ex);
            }
        }
        public async Task<DataResponse<Manga>> GetByName(string name)
        {
            try
            {
                List<Manga> mangas = _db.Mangas.Where(M => M.Name.StartsWith(name)).ToList();
                return ResponseFactory.CreateInstance().CreateDataSuccessResponse<Manga>(mangas);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateDataFailedResponse<Manga>(ex);
            }
        }

        public async Task<SingleResponse<Manga>> Select(int id)
        {
            try
            {
                Manga Select = _db.Mangas.FirstOrDefault(m => m.Id == id);
                return ResponseFactory.CreateInstance().CreateSingleSuccessResponse<Manga>(Select);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateSingleFailedResponse<Manga>(ex, null);
            }
        }

        public async Task<DataResponse<Manga>> Select()
        {
            try
            {
                List<Manga> mangas = await _db.Mangas.ToListAsync();
                return ResponseFactory.CreateInstance().CreateDataSuccessResponse(mangas);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateDataFailedResponse<Manga>(ex);
            }
        }

        public async Task<Response> Update(Manga Item)
        {
            Manga? MangaDB = await _db.Mangas.FindAsync(Item.Id);
            if (MangaDB == null)
                return ResponseFactory.CreateInstance().CreateNotFoundIdResponse();
            try
            {
                _db.Mangas.Update(Item);
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }

        public async Task<Response> Delete(int id)
        {
            Manga? MangaDB = await _db.Mangas.FindAsync(id);
            if (MangaDB == null)
                return ResponseFactory.CreateInstance().CreateNotFoundIdResponse();
            try
            {
                _db.Mangas.Remove(MangaDB);
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
