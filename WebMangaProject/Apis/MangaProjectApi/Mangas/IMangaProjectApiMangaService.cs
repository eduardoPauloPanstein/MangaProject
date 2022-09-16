using Entities.MangaS;
using Shared;
using Shared.Responses;

namespace MvcPresentationLayer.Apis.MangaProjectApi.Mangas
{
    public interface IMangaProjectApiMangaService : IMangaProjectApiService<Manga>
    {
        Task<DataResponse<Manga>> Select(string title);
        Task<DataResponse<Manga>> SelectByFavorites(int skip = 0, int take = 25);
        Task<DataResponse<Manga>> SelectByUserCount(int skip = 0, int take = 25);
    }
}
