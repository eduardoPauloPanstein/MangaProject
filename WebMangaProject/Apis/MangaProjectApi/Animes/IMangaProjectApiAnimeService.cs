using Entities.AnimeS;
using Shared.Interfaces;
using Shared.Responses;

namespace MvcPresentationLayer.Apis.MangaProjectApi.Animes
{
    public interface IMangaProjectApiAnimeService : IMangaProjectApiService<Anime>, IUsualGetInterfaces<Anime>
    {

    }
}
