using DataAccessLayer.Interfaces.IAnimeInterfaces;
using Entities.AnimeS;
using Entities.MangaS;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementations
{
    public class AnimeDAL :IAnimeDAL
    {
        private readonly MangaProjectDbContext _db;
        public AnimeDAL(MangaProjectDbContext db)
        {
            this._db = db;
        }
        public async Task<Response> Insert(Anime Anime)
        {
            List<Category> Cate = new();
            try
            {
                foreach (var item in Anime.Categories)
                {
                    Cate.Add(await _db.Categories.FindAsync(item.ID));
                }
                Anime.Categories = Cate;
                _db.Animes.Add(Anime);
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }

        public async Task<Response> Update(Anime Item)
        {
            Anime? AnimeDB = await _db.Animes.FindAsync(Item.Id);
            if (AnimeDB == null)
                return ResponseFactory.CreateInstance().CreateNotFoundIdResponse();
            try
            {
                _db.Animes.Update(Item);
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }

        public async Task<SingleResponse<Anime>> Get(int id)
        {
            try
            {
                Anime? Select = _db.Animes.Include(c=> c.Categories).FirstOrDefault(m => m.Id == id);
                return ResponseFactory.CreateInstance().CreateSingleSuccessResponse<Anime>(Select);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateSingleFailedResponse<Anime>(ex, null);
            }
        }

        public async Task<Response> Delete(int id)
        {
            Anime? AnimeDB = await _db.Animes.FindAsync(id);
            if (AnimeDB == null)
                return ResponseFactory.CreateInstance().CreateNotFoundIdResponse();
            try
            {
                _db.Animes.Remove(AnimeDB);
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }

        public async Task<DataResponse<Anime>> Get(int skip, int take)
        {
            try
            {
                List<Anime> anime = await _db.Animes
                    .AsNoTracking()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
                return ResponseFactory.CreateInstance().CreateDataSuccessResponse(anime);

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateDataFailedResponse<Anime>(ex);
            }
        }

        public async Task<DataResponse<Anime>> Get(string name)
        {
            try
            {
                List<Anime> anime = await _db.Animes.Where(M => M.name.Contains(name)).ToListAsync();
                return ResponseFactory.CreateInstance().CreateDataSuccessResponse<Anime>(anime);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateDataFailedResponse<Anime>(ex);
            }
        }

        public async Task<SingleResponse<Anime>> GetComplete(int ID)
        {
            try
            {
                Anime? Select = _db.Animes.Include(c => c.Categories).FirstOrDefault(m => m.Id == ID);
                return ResponseFactory.CreateInstance().CreateSingleSuccessResponse<Anime>(Select);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateSingleFailedResponse<Anime>(ex, null);
            }
        }

        public async Task<int> GetLastIndex()
        {
            try
            {
                Anime? a = _db.Animes.OrderBy(c => c.Id).LastOrDefault();
                return a.Id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> GetLastIndexCategory()
        {
            try
            {
                Category? a = _db.Categories.OrderBy(c => c.ID).LastOrDefault();
                return a.ID;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<Response> LeaveComentary(AnimeComentary Leave)
        {
            Leave.Anime = await _db.Animes.FindAsync(3);
            Leave.User = await _db.Users.FindAsync(1);

            try
            {
                _db.AnimeComentaries.Add(Leave);
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }

        public async Task<DataResponse<Anime>> GetByFavorites(int skip, int take)
        {
            try
            {
                List<Anime> animes = await _db.Animes
                    .OrderByDescending(m => m.favoritesCount)
                    .AsNoTracking()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
                return ResponseFactory.CreateInstance().CreateDataSuccessResponse(animes);

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateDataFailedResponse<Anime>(ex);
            }
        }

        public async Task<DataResponse<Anime>> GetByRating(int skip, int take)
        {
            try
            {
                List<Anime> animes = await _db.Animes
                    .OrderBy(m => m.ratingRank)
                    .AsNoTracking()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
                return ResponseFactory.CreateInstance().CreateDataSuccessResponse(animes);

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateDataFailedResponse<Anime>(ex);
            }
        }

        public async Task<DataResponse<Anime>> GetByUserCount(int skip, int take)
        {
            try
            {
                List<Anime> Animes = await _db.Animes
                    .OrderByDescending(m => m.userCount)
                    .AsNoTracking()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
                return ResponseFactory.CreateInstance().CreateDataSuccessResponse(Animes);

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateDataFailedResponse<Anime>(ex);
            }
        }
    }
}
