using Entities.UserS;
using Shared;

namespace MvcPresentationLayer.Apis.MangaProjectApi
{
    public interface IMangaProjectApiUserService : IMangaProjectApiService<User>
    {
        Task<SingleResponse<User>> Login(UserLogin user);
    }
}
