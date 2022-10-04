using Shared.Responses;

namespace MvcPresentationLayer.Apis.MangaProjectApi.ItemComentary.AnimeComentary
{
    public interface IMangaProjectApiAnimeComentary : IMangaProjectApiService<Entities.AnimeS.AnimeComentary>
    {
        Task<DataResponse<Entities.AnimeS.AnimeComentary>> GetByUser(int userid);

    }
}
