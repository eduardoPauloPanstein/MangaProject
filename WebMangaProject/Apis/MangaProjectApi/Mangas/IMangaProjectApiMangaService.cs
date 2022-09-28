using Entities.MangaS;
using Shared;
using Shared.Interfaces;
using Shared.Responses;

namespace MvcPresentationLayer.Apis.MangaProjectApi.Mangas
{
    public interface IMangaProjectApiMangaService : IMangaProjectApiService<Manga>, IUsualGetInterfaces<Manga>
    {
    
    }
}
