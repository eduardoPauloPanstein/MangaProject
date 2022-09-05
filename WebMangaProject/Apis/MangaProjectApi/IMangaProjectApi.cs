using Entities;
using Shared;

namespace MvcPresentationLayer.Apis.MangaProjectApi
{
    public interface IMangaProjectApiService<T>
    {
        Task<Response> Insert(T item);
        Task<SingleResponse<T>> Select(int? id);
        Task<DataResponse<T>> SelectAll();
        Task<Response> Update(T item);
        Task<Response> Delete(int? id);
    }
    public interface IMangaProjectApiUserService : IMangaProjectApiService<User>
    {
        Task<SingleResponse<User>> Login(User user);
    }
}
