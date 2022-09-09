using Entities.MangaS;
using Shared;
using Shared.Responses;

namespace MvcPresentationLayer.Apis.MangaProjectApi.Mangas
{
    public interface IMangaProjectApiMangaService : IMangaProjectApiService<Manga>
    {
        Task<DataResponse<Manga>> Select(string title);
    }
}
