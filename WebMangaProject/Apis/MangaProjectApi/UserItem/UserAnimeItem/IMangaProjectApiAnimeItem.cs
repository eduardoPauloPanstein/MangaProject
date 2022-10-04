﻿using Entities.UserS;
using Shared.Interfaces;
using Shared.Responses;

namespace MvcPresentationLayer.Apis.MangaProjectApi.UserItem.UserAnimeItem
{
    public interface IMangaProjectApiAnimeItem : IMangaProjectApiService<Entities.UserS.UserAnimeItem>
    {
        Task<DataResponse<Entities.UserS.UserAnimeItem>> GetByUser(int userid);

    }
}
