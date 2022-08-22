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
            //_db.Mangas.AddAsync(manga); //WHY?
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

                List<Manga> mangas = await _db.Mangas.OrderByDescending(m => m.FavoritesCount).Take(5).ToListAsync();
                return ResponseFactory.CreateInstance().CreateDataSuccessResponse(mangas);
=======
                List<Manga> mangas = await _db.Mangas.OrderByDescending(m => m.FavoritesCount).Take(6).ToListAsync();
                return new DataResponse<Manga>()
                {   
                    HasSuccess = true,
                    Message = "Mangas selecionados com sucesso!",
                    Data = mangas
                };

            }
            catch (Exception ex)
            {
                return new DataResponse<Manga>()
                {
                    HasSuccess = false,
                    Message = "Erro no banco, contate o administrador.",
                    Exception = ex
                };

            }
        }
        public async Task<DataResponse<Manga>> GetAllByFavorites()
        {
            DataResponse<Manga> response = new();

            try
            {
                List<Manga> mangas = await _db.Mangas.OrderByDescending(m => m.FavoritesCount).ToListAsync();
                return new DataResponse<Manga>()
                {
                    HasSuccess = true,
                    Message = "Mangas selecionados com sucesso!",
                    Data = mangas
                };

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateDataFailedResponse<Manga>(ex);

            }
        }
    }
}
