﻿using Entities;
using Entities.MangaS;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IMangaService
    {
        Task<Response> Insert(Manga manga);

        Task<DataResponse<Manga>> GetAll();
        Task<DataResponse<Manga>> GetTopSixFavorites();
        Task<DataResponse<Manga>> GetAllByFavorites();

        Task<DataResponse<Manga>> GetPerPage(int page);
        Task<SingleResponse<Manga>> GetByID(int id);
        Task<DataResponse<Manga>> GetMorePopular();
        Task<DataResponse<Manga>> GetByName(string name);
        Task<Response> DeleteAllDatas();
        //Task<DataResponse<UserToManga>> GetUserFavorites(int UserID);

    }
}
