using Entities.UserS;
using Shared.Responses;

namespace MvcPresentationLayer.Apis.MangaProjectApi
{
    public interface IMangaProjectApiService<T>
    {
        Task<Response> Insert(T item);
        Task<SingleResponse<T>> Select(int? id);
        Task<DataResponse<T>> Select(int skip = 0, int take = 25);
        Task<Response> Update(T item);
        Task<Response> Delete(int? id);
    }
   
}
