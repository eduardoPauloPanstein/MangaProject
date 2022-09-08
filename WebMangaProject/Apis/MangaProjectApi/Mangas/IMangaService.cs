using Entities.MangaS;
using Shared;
using Shared.Responses;

namespace MvcPresentationLayer.Apis.MangaProjectApi.Mangas
{
    public interface IMangaService : IMangaProjectApiService<Manga>
    {
        Task<DataResponse<Manga>> Select(string title);
    }
}
