﻿using DataAccessLayer.Interfaces.IMangaInterfaces;
using Entities;
using Entities.MangaS;
using Entities.UserS;
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
            foreach (var item in manga.Categoria)
            {
                _db.Entry<Category>(item).State = EntityState.Detached;
                //unchanged
            }

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
        

        public async Task<DataResponse<Manga>> GetByUserCount(int skip, int take)
        {
            try
            {
                List<Manga> mangas = await _db.Mangas
                    .OrderByDescending(m => m.UserCount)
                    .AsNoTracking()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
                return ResponseFactory.CreateInstance().CreateDataSuccessResponse(mangas);

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateDataFailedResponse<Manga>(ex);
            }
        }

        public async Task<DataResponse<Manga>> GetByFavorites(int skip, int take)
        {
            try
            {
                List<Manga> mangas = await _db.Mangas
                    .OrderByDescending(m => m.FavoritesCount)
                    .AsNoTracking()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
                return ResponseFactory.CreateInstance().CreateDataSuccessResponse(mangas);

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateDataFailedResponse<Manga>(ex);
            }
        }

        public async Task<DataResponse<Manga>> Get(string name)
        {
            try
            {
                List<Manga> mangas = await _db.Mangas.Where(M => M.CanonicalTitle.Contains(name)).ToListAsync();
                return ResponseFactory.CreateInstance().CreateDataSuccessResponse<Manga>(mangas);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateDataFailedResponse<Manga>(ex);
            }
        }

        public async Task<SingleResponse<Manga>> Get(int id)
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

        public async Task<DataResponse<Manga>> Get(int skip, int take)
        {
            try
            {
                List<Manga> mangas = await _db.Mangas
                    .AsNoTracking()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
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

        public async Task<Response> InsertCategory(Category id)
        {
            try
            {
                _db.Categories.Add(id);
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
