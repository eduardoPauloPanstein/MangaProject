using Shared.Responses;

namespace MvcPresentationLayer.Apis.MangaProjectApi.UserItem.UserMangaItem
{
    public interface IMangaProjectApiMangaItem : IMangaProjectApiService<Entities.UserS.UserMangaItem>
    {
        Task<DataResponse<Entities.UserS.UserMangaItem>> GetByUser(int userid);

    }
}
