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
                return new Response()
                {
                    HasSuccess = true,
                    Message = "Manga cadastrado com sucesso."
                };
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    HasSuccess = false,
                    Message = "Erro no banco de dados, contate o administrador.",
                    Exception = ex
                };
            }

        }
        public async Task<DataResponse<Manga>> GetAll()
        {
            DataResponse<Manga> response = new();

            try
            {
                List<Manga> mangas = await _db.Mangas.ToListAsync();
                response.HasSuccess = true;
                response.Message = "Mangas selecionados com sucesso!";
                response.Data = mangas;
                return response;
            }
            catch (Exception ex)
            {
                response.HasSuccess = false;
                response.Message = "Erro no banco, contate o administrador.";
                response.Exception = ex;
                return response;
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
            MangaProjectDbContext db = new();

            //var tableNames = db.Model.GetEntityTypes()
            //                         .Select(t => t.GetTableName())
            //                         .Distinct()
            //                         .ToList();

            try
            {
                db.Database.ExecuteSqlRaw($"DELETE FROM RatingFrequencies; DELETE FROM MANGAS; DELETE FROM MangaTitles");
                return new Response()
                {
                    HasSuccess = true,
                    Message = "Dados deletados com sucesso."
                };
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    HasSuccess = false,
                    Message = "Erro.",
                    Exception = ex
                };
            }
        }

        public async Task<DataResponse<Manga>> GetSix()
        {
            DataResponse<Manga> response = new();

            try
            {
                List<Manga> mangas = await _db.Mangas.Where(m => m.Id < 118).ToListAsync();
                response.HasSuccess = true;
                response.Message = "Mangas selecionados com sucesso!";
                response.Data = mangas;
                return response;
            }
            catch (Exception ex)
            {
                response.HasSuccess = false;
                response.Message = "Erro no banco, contate o administrador.";
                response.Exception = ex;
                return response;
            }
        }
    }
}
