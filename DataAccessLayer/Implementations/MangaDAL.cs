using DataAccessLayer.Interfaces;
using Entities.Manga;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<DataResponse<Manga>> GetAll()
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
        public async Task<DataResponse<Manga>> GetMorePopular()
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<Manga>> GetPerPage(int page)
        {
            throw new NotImplementedException();
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

        public async Task<SingleResponse<Manga>> GetByID(int id)
        {
            try
            {
                Manga Select = _db.Mangas.FirstOrDefault(m => m.Id == id);
                return ResponseFactory.CreateInstance().CreateSingleSuccessResponse<Manga>(Select);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
