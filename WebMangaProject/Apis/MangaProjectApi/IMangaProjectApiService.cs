using Entities.UserS;
using Shared.Responses;

namespace MvcPresentationLayer.Apis.MangaProjectApi
{
    public interface IMangaProjectApiService<T>
    {
        Task<Response> Insert(T item, string token);
        Task<SingleResponse<T>> Select(int? id, string? token);
        Task<DataResponse<T>> Select(string? token, int skip = 0, int take = 25);
        Task<Response> Update(T item, string token);
        Task<Response> Delete(int? id, string token);
    }
   
}
