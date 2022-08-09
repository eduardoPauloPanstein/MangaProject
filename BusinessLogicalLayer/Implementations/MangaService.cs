using BLL.Extensions;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Validators.Manga;
using DataAccessLayer.Interfaces;
using Entities.Manga;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Implementations
{
    public class MangaService : IMangaService
    {
        private readonly IMangaDAL mangaDAL;

        public MangaService(IMangaDAL mangaDAL)
        {
            this.mangaDAL = mangaDAL;
        }
        public Task<Response> DeleteAllDatas()
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<Manga>> GetAll()
        {
            //politica de cache!
            return await mangaDAL.GetAll();
        }

        public Task<DataResponse<Manga>> GetMorePopular()
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Manga>> GetPerPage(int page)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<Manga>> GetSix()
        {
            return await mangaDAL.GetSix();
        }

        public async Task<Response> Insert(Manga manga)
        {
            Response response = new MangaInsertValidator().Validate(manga).ConvertToResponse();
            if (!response.HasSuccess)
                return response;
            response = await mangaDAL.Insert(manga);
            return response;
        }
    }
}
